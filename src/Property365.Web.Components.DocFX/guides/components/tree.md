# Tree component
This article demonstrates how to use Property365BlazorTree.

## Inline definition
The most straight forward way to configure a Property365Tree is to specify its items inline.
```
<Property365Tree>
    <Property365TreeItem Text="BMW">
        <Property365TreeItem Text="M3" />
        <Property365TreeItem Text="M5" />
    </Property365TreeItem>
    <Property365TreeItem Text="Audi">
        <Property365TreeItem Text="RS4" />
        <Property365TreeItem Text="RS6" />
    </Property365TreeItem>
    <Property365TreeItem Text="Mercedes">
        <Property365TreeItem Text="C63 AMG" />
        <Property365TreeItem Text="S63 AMG" />
    </Property365TreeItem>
</Property365Tree>
```
## Data-binding
Often you would like to data-bind Property365Tree to a collection of items. For example a collection of categories that has related products.
```
public class Category
{
   public string CategoryName { get; set; }
   public IEnumerable<Product> Products { get; set; }
}

public class Product
{
   public string ProductName { get; set; }
}
```
In this case you need to set the `Data` property of Property365Tree to your collection and add a few `Property365TreeLevel`s that specify how each level of items should be data-bound.

```
<Property365Tree Data="@Northwind.Categories.Include(c => c.Products)">
    <Property365TreeLevel TextProperty="CategoryName" ChildrenProperty="Products" />
    <Property365TreeLevel TextProperty="ProductName" HasChildren="@((product) => false)" />
</Property365Tree>
```
The first `Property365TreeLevel` says that the first (root) level of items have their `Text` set to the `CategoryName` property of the data. They also have children that are data-bound to the `Products` property.

The second `Property365TreeLevel` says that the second level of items have their `Text` set to the `ProductName` property of the data. The don't have children (specified via `HasChildren`).

> [!NOTE] 
> Check how this example uses the `Include` Entity Framework method to load the related products of a category. If this isn't done the children items won't populate.

### Load on demand
The previous example loads all tree items instantly. Sometimes you would like to have full control over when children data is loaded. In that case you should use the `Expand` event.

```
<Property365Tree Data="@Northwind.Categories" Expand="@OnExpand">
    <Property365TreeLevel TextProperty="CategoryName"/>
</Property365Tree>
@code {
    void OnExpand(TreeExpandEventArgs args)
    {
        var category = args.Value as Category;

        args.Children.Data = category.Include(c => c.Products).Products;
        args.Children.TextProperty = "ProductName";
        args.Children.HasChildren = (product) => false;
    }
}
```

Here we have only one level (for the categories). Children are populated in the `OnExpand` method that handles the `Expand` event.
To populate items on demand you need to configure the `Children` property of the `args` - set `Data`, `TextProperty` and `HasChildren`.

### Mixed data
The examples so far dealt with trees that had the same type of node per level - first level was categories and second level was products.
Here is how to have mixed types of nodes per level - files and directories in this case.

```
<Property365Tree Data="@entries" Expand="@LoadFiles">
    <Property365TreeLevel Text="@GetTextForNode" />
</Property365Tree>
@code {
    IEnumerable<string> entries = null;

    protected override void OnInitialized()
    {
        entries = Directory.GetDirectories(HostEnvironment.ContentRootPath);
    }

    string GetTextForNode(object data)
    {
        return Path.GetFileName((string)data);
    }

    void LoadFiles(TreeExpandEventArgs args)
    {
        var directory = args.Value as string;

        args.Children.Data = Directory.EnumerateFileSystemEntries(directory);
        args.Children.Text = GetTextForNode;
        args.Children.HasChildren = (path) => Directory.Exists((string)path);
    }
}
```

## Templates
To customize the way a tree item appears (e.g. add icons, images or other custom markup) you can use the `Template` option.

### Templates in inline definition

Here is an example how to define a tree item template using inline definition.

```
<Property365Tree>
    <Property365TreeItem Text="BMW">
        <Template>
            <strong>@context.Text</strong>
        </Template>
        <ChildContent>
            <Property365TreeItem Text="M3" />
            <Property365TreeItem Text="M5" />
        </ChildContent>
    </Property365TreeItem>
</Property365Tree>
```

The `context` is the current `Property365TreeItem`. You can use its properties as you see fit.

> [!IMPORTANT]
> Defining children requires a `ChildContent` element when a template is specified.

### Templates in data-binding
The `Property365TreeLevel` also supports templates.
```
<Property365Tree Data="@Northwind.Categories.Include(c => c.Products)">
    <Property365TreeLevel TextProperty="CategoryName" ChildrenProperty="Products">
        <Template>
            <strong>@(context as Category).CategoryName</strong>
        </Template>
    </Property365TreeLevel>
    <Property365TreeLevel TextProperty="ProductName" HasChildren="@((product) => false)" />
</Property365Tree>
```

Again the current `Property365TreeItem` is represented as the `context` variable. Use the `Value` property to get the
current data item.

### Templates in load on demand
One can specify templates even in load on demand scenarios. The template should either be a custom Blazor component, or
you should use a `RenderFragment`.

```
<Property365Tree Data="@entries" Expand="@LoadFiles">
    <Property365TreeLevel Text="@GetTextForNode" Template="@FileOrFolderTemplate" />
</Property365Tree>
@code {
    IEnumerable<string> entries = null;

    protected override void OnInitialized()
    {
        entries = Directory.GetDirectories(HostEnvironment.ContentRootPath);
    }

    string GetTextForNode(object data)
    {
        return Path.GetFileName((string)data);
    }

    RenderFragment<Property365TreeItem> FileOrFolderTemplate = (context) => builder =>
    {
        string path = context.Value as string;
        bool isDirectory = Directory.Exists(path);

        // Add a Property365Icon to the template

        builder.OpenComponent<Property365Icon>(0);
        builder.AddAttribute(1, "Icon", isDirectory ? "folder" : "insert_drive_file");

        // Set some margin if the current data item is a file (!isDirectory)

        if (!isDirectory)
        {
            builder.AddAttribute(2, "Style", "margin-left: 24px");
        }

        builder.CloseComponent();

        // Append the current item text
        builder.AddContent(3, context.Text);
    };

    void LoadFiles(TreeExpandEventArgs args)
    {
        var directory = args.Value as string;

        args.Children.Data = Directory.EnumerateFileSystemEntries(directory);
        args.Children.Text = GetTextForNode;
        args.Children.HasChildren = (path) => Directory.Exists((string)path);

        // Propagate the Template to the children
        args.Children.Template = FileOrFolderTemplate;
    }
}
```

## Selection
You can control the selection state of Property365Tree component via its `Value` property. The tree item whose Value property is equal to the specified value will be selected.

> [!IMPORTANT]
> The type of the value you set must be `object`. Property365Tree can be bound to items of different type has its Value needs to be an `object`.

```
<Property365Tree Data="@categories" @bind-Value=@selectedCategory Change=@OnChange>
    <Property365TreeLevel TextProperty="CategoryName"/>
</Property365Tree>
@code {
  IEnumerable<Category> categories;

  // Not that selectedCategory is object and not Category.
  object selectedCategory = null;

  protected override void OnInitialized()
  {
    categories = NorthwindDataContext.Categories;
    // Select the first category (if available)
    selectedCategory = categories.FirstOrDefault();
  }

  void OnChange()
  {
    // The selectedCategory field will contain the Category instance which the selected tree item represents

    var categoryName = (selectedCategory as Category).CategoryName;
  }
}
```

To clear the current selection set the Value property to `null`.

```
<Property365Tree Data="@categories" @bind-Value=@selectedCategory Change=@OnChange>
    <Property365TreeLevel TextProperty="CategoryName"/>
    <Property365Button Click=@ClearSelection Text="Clear selection" />
</Property365Tree>
@code {
  IEnumerable<Category> categories;
  object selectedCategory = null;

  void ClearSelection()
  {
     selectedCategory = null;
  }
}
```
## Checkboxes
Property365Tree supports checkboxes. To enable them set the `AllowCheckBoxes` property to `true`. To get or set the currently checked
items use `@bind-CheckedValues`.

```
<Property365Tree AllowCheckBoxes="true" @bind-CheckedValues="@CheckedValues">
</Property365Tree>
```

There are two more properties that are related to checkboxes:
- AllowCheckChildren - specifies what hapepens when a parent item is checked. If set to `true` checking parent items also checks all of its children.
- AllowCheckParents - specifies what hapepens with a parent item when one of its children is checked. If set to `true` checking a child item will affect the checked state of its parents.
