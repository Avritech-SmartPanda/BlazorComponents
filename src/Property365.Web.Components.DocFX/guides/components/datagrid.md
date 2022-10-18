# DataGrid component
This article demonstrates how to use the DataGrid component.

## Data-binding
To display data in DataGrid component you need to set collection of items (`IEnumerable<>`) to `Data` property and define collection of `Property365DataGridColumn` in `Columns`. DataGrid component can perform server-side sorting, paging and filtering when bound to __IQueryable__ or using `LoadData` event. Grouping will not be performed server-side - only on current page data if paging is enabled.

### Populate data when initialized

```
<Property365DataGrid Data="@customers" TItem="Customer">
    <Columns>
        <Property365DataGridColumn TItem="Customer" Property="CustomerID" Title="Customer ID"  />
        <Property365DataGridColumn TItem="Customer" Property="CompanyName" Title="Company Name" />
        <Property365DataGridColumn TItem="Customer" Property="ContactName" Title="Contact Name" />
    </Columns>
</Property365DataGrid>
@code {
    IEnumerable<Customer> customers;

    protected override void OnInitialized()
    {
        customers = dbContext.Customers.ToList();
    }
}
```

### Populate data on demand using LoadData event.

```
@using System.Linq.Dynamic.Core
@inject NorthwindContext dbContext

<Property365DataGrid Data="@customers" Count="@count" TItem="Customer" LoadData="@LoadData">
    <Columns>
        <Property365DataGridColumn TItem="Customer" Property="CustomerID" Title="Customer ID"  />
        <Property365DataGridColumn TItem="Customer" Property="CompanyName" Title="Company Name" />
        <Property365DataGridColumn TItem="Customer" Property="ContactName" Title="Contact Name" />
    </Columns>
</Property365DataGrid>

@code {
    IEnumerable<Customer> customers;
    int count;

    void LoadData(LoadDataArgs args)
    {
        // This demo is using https://dynamic-linq.net
        var query = dbContext.Customers.AsQueryable();

        if (!string.IsNullOrEmpty(args.Filter))
        {
            // Filter via the Where method
            query = query.Where(args.Filter);
        }

        if (!string.IsNullOrEmpty(args.OrderBy))
        {
            // Sort via the OrderBy method
            query = query.OrderBy(args.OrderBy);
        }

        // Important!!! Make sure the Count property of Property365DataGrid is set.
        count = query.Count();

        // Perform paging via Skip and Take.
        customers = query.Skip(args.Skip.Value).Take(args.Top.Value).ToList();
        
        // Add StateHasChanged(); for DataGrid to update if your LoadData method is async.
    }
}
```

## Sorting

Use `AllowSorting` and `AllowMultiColumnSorting` properties to allow and control sorting.
```
<Property365DataGrid AllowSorting="true" AllowMultiColumnSorting="true" ...
```

By default DataGrid component will perform sorting using `Property` of the column, use `SortProperty` to specify different sort property from the property used to display data in the column. Use `Sortable` column property to enable/disable sorting for specific column. You can use dot notation to specify sub property.

```
...
<Columns>
        <Property365DataGridColumn TItem="Order" Property="CustomerID" Title="Customer ID" Sortable="false"  />
        <Property365DataGridColumn TItem="Order" Property="Customer.CompanyName" Title="Company Name" SortProperty="Customer.ContactName" />
        ...
```

## Paging
Use `AllowPaging` and `PageSize` properties to allow and control paging.
```
<Property365DataGrid AllowPaging="true" PageSize="5" ...
```

## Filtering
Use `AllowFiltering`, `FilterMode`, `FilterCaseSensitivity` and `LogicalFilterOperator` properties to allow and control filtering. 
```
<Property365DataGrid AllowFiltering="true" FilterMode="FilterMode.Advanced" LogicalFilterOperator="LogicalFilterOperator.Or" ...
```

By default DataGrid component will perform filtering using `Property` of the column, use `FilterProperty` to specify different filter property from the property used to display data in the column. Use `Filterable` column property to enable/disable filtering for specific column. You can use dot notation to specify sub property.

```
...
<Columns>
        <Property365DataGridColumn TItem="Order" Property="CustomerID" Title="Customer ID" Filterable="false"  />
        <Property365DataGridColumn TItem="Order" Property="Customer.CompanyName" Title="Company Name" FilterProperty="Customer.ContactName" />
        ...
```

Advanced filter mode (`FilterMode.Advanced`) allows you to to apply complex filter for each column with two filter values and filter operators while simple filter mode (`FilterMode.Simple`) allows you to apply single `FilterValue` and `FilterOperator`. `LogicalFilterOperator` column property can be used to specify how the two column filters will be applied - with `and` or `or`. 

```
...
<Columns>
    <Property365DataGridColumn TItem="Employee" Property="FirstName" Title="First Name" 
        FilterValue=@("Nan") FilterOperator="FilterOperator.StartsWith" 
        LogicalFilterOperator="LogicalFilterOperator.Or" />
    <Property365DataGridColumn TItem="Employee" Property="FirstName" Title="First Name" 
        FilterValue=@("Nan") FilterOperator="FilterOperator.StartsWith" 
        SecondFilterValue=@("Nan") SecondFilterOperator="FilterOperator.EndsWith"
        LogicalFilterOperator="LogicalFilterOperator.And" />
    ...
```

Use `FilterTemplate` column property to define your own custom filtering template for specific column

```
...
<Columns>
    <Property365DataGridColumn TItem="Employee" Property="TitleOfCourtesy" Title="Title Of Courtesy" FilterValue="@currentTOC">
        <FilterTemplate>
            <Property365DropDown @bind-Value="@currentTOC" ... />
        </FilterTemplate>
    </Property365DataGridColumn>
        ...
```

## Grouping
Use `AllowGrouping` property to allow grouping and Groups collection to add/remove groups using `GroupDescriptor` class. By default DataGrid component will perform grouping using `Property` of the column, use `GroupProperty` to specify different group property from the property used to display data in the column. Use `Groupable` column property to enable/disable grouping for specific column. You can use dot notation to specify sub property.
```
<Property365DataGrid AllowGrouping="true" Data="@employees" TItem="Employee" Render="@OnRender">
    <Columns>
        <Property365DataGridColumn TItem="Employee" Property="EmployeeID" Filterable="false" Title="ID" Frozen="true" Width="70px" />
        <Property365DataGridColumn TItem="Employee" Title="Photo" Sortable="false" Filterable="false" Groupable="false" Width="200px" >
            <Template Context="data">
                <Property365Image Path="@data.Photo" style="width: 40px; height: 40px; border-radius: 8px;" />
            </Template>
        </Property365DataGridColumn>
        <Property365DataGridColumn TItem="Employee" Property="FirstName" Title="First Name" />
        <Property365DataGridColumn TItem="Employee" Property="LastName" Title="Last Name" Width="150px"/>
    </Columns>
</Property365DataGrid>

@code {
    IEnumerable<Employee> employees;

    protected override void OnInitialized()
    {
        employees = dbContext.Employees;
    }

    void OnRender(DataGridRenderEventArgs<Employee> args)
    {
        if(args.FirstRender)
        {
            args.Grid.Groups.Add(new GroupDescriptor(){ Property = "Title" });
            StateHasChanged();
        }
    }
}    
```

Use `GroupHeaderTemplate` to customize group headers. The context in this template is `Group` class.

```
<Property365DataGrid AllowGrouping="true" Data="@employees" TItem="Employee" Render="@OnRender">
    <GroupHeaderTemplate>
        @context.GroupDescriptor.GetTitle(): @context.Data.Key, Group items count: @context.Data.Count, Last order date: @(context.Data.Items.Cast<Order>().OrderByDescending(o => o.OrderDate).FirstOrDefault()?.OrderDate)
    </GroupHeaderTemplate>
    ...
```

Use `GroupFooterTemplate` to customize group footers for columns. The context in this template is `Group` class.

```
<Columns>
    <Property365DataGridColumn TItem="Order" Property="Freight" Title="Freight">
        <GroupFooterTemplate>
            Group amount: <b>@String.Format(new System.Globalization.CultureInfo("en-US"), "{0:C}", context.Data.Items.Cast<Order>().Sum(o => o.Freight))</b>
        </GroupFooterTemplate>
    </Property365DataGridColumn>
    ...
```

## Columns

Use `Template`, `FooterTemplate` and `HeaderTemplate` to specify custom template for data, footer and header cells. 

```
...
<Columns>
    <Property365DataGridColumn TItem="Order">
        <HeaderTemplate>
            Nr.
        </HeaderTemplate>
        <Template Context="data">
            @(orders.IndexOf(data) + 1)
        </Template>
            <FooterTemplate>
            Displayed orders: <b>@ordersGrid.View.Count()</b> of <b>@orders.Count()</b>
        </FooterTemplate>
    </Property365DataGridColumn>
    ...
```

Use `AllowColumnResize` and `AllowColumnReorder` to allow columns resize and reorder. Use column `Resizable` and `Reorderable` properties to enable/disable resize and/or reorder for specific column. Use `ColumnWidth` to specify width for all columns or column `Width` to specify width for specific column. Use `TextAlign` column property to specify column alignment for data, header and footer cells. Set `Frozen` column property to disable horizontal scroll for specific column. Use `OnColumnResized` and `ColumnReordered` events to catch if a column is resized or reordered. 

```
<Property365DataGrid AllowColumnResize="true" AllowColumnReorder="true" ColumnWidth="200px"
    ColumnResized=@OnColumnResized ColumnReordered="@OnColumnReordered">
    <Columns>
        <Property365DataGridColumn TItem="Employee" Property="EmployeeID" Title="ID" Resizable="true" Reorderable="false" Frozen="true" />
        <Property365DataGridColumn TItem="Employee" Property="FirstName" Title="FirstName" Width="50px" TextAlign="TextAlign.Center" />
        ...
```

## In-line editing

Use `EditTemplate` to specify cell template when the row is in edit mode. Use DataGrid `EditRow()`, `CancelEditRow()` and `UpdateRow()` to edit, update or cancel changes for specific data item/row. Use DataGrid `EditMode` property to specify if multiple rows or single row can be edited at once.

```
...
<Property365DataGrid @ref="ordersGrid" EditMode="DataGridEditMode.Single"
                Data="@orders" TItem="Order" RowUpdate="@OnUpdateRow" RowCreate="@OnCreateRow">
    <Columns>
        <Property365DataGridColumn Width="200px" TItem="Order" Property="Customer.CompanyName" Title="Customer">
            <EditTemplate Context="order">
                <Property365DropDown @bind-Value="order.CustomerID" Data="@customers" TextProperty="CompanyName" ValueProperty="CustomerID" />
            </EditTemplate>
        </Property365DataGridColumn>
        <Property365DataGridColumn TItem="Order" Context="order" Filterable="false" Sortable="false" TextAlign="TextAlign.Center" Width="100px">
            <Template Context="order">
                <Property365Button Icon="edit" Size="ButtonSize.Small" Click="@(args => EditRow(order))" @onclick:stopPropagation="true" />
            </Template>
            <EditTemplate Context="order">
                <Property365Button Icon="save" Size="ButtonSize.Small" Click="@((args) => SaveRow(order))" />
                <Property365Button Icon="cancel" Size="ButtonSize.Small" ButtonStyle="ButtonStyle.Secondary" Click="@((args) => CancelEdit(order))" />
            </EditTemplate>
        </Property365DataGridColumn>
        ...
```

## Virtualization

Use `AllowVirtualization` to allow virtualization. It is supported for both __IQueryable__ or using `LoadData` event data binding. It is important to specify height for the DataGrid component.

```
<Property365DataGrid Data="@orderDetails" TItem="OrderDetail" AllowVirtualization="true" Style="height:400px" ...
```


## Hierarchy

Use DataGrid `Template` property to define child content when the row is expanded. Use `RowRender` event to set if a row is expandable or not and use `ExpandRow()` method of the DataGrid to expand desired row/item. Use `ExpandMode` to specify if multiple or single rows can be expanded at once.

```
<Property365DataGrid @ref="grid" RowRender="@RowRender" ExpandMode="DataGridExpandMode.Single" Data="@orders" TItem="Order">
    ...
    <Template Context="order">
        <Property365DataGrid Data="@order.OrderDetails" TItem="OrderDetail">
            <Columns>
                <Property365DataGridColumn TItem="OrderDetail" Property="Order.CustomerID" Title="Order" />
                <Property365DataGridColumn TItem="OrderDetail" Property="Product.ProductName" Title="Product" />
                <Property365DataGridColumn TItem="OrderDetail" Property="UnitPrice" Title="Unit Price">
                    <Template Context="detail">
                        @String.Format(new System.Globalization.CultureInfo("en-US"), "{0:C}", detail.UnitPrice)
                    </Template>
                </Property365DataGridColumn>
                <Property365DataGridColumn TItem="OrderDetail" Property="Quantity" Title="Quantity" />
                <Property365DataGridColumn TItem="OrderDetail" Property="Discount" Title="Discount">
                    <Template Context="detail">
                        @String.Format("{0}%", detail.Discount * 100)
                    </Template>
                </Property365DataGridColumn>
            </Columns>
        </Property365DataGrid>
        ...
@code {
    IEnumerable<Order> orders;
    Property365DataGrid<Order> grid;

    protected override void OnInitialized()
    {
        orders = dbContext.Orders.Include("Customer").Include("Employee").Include("OrderDetails").Include("OrderDetails.Product").ToList();
    }

    void RowRender(RowRenderEventArgs<Order> args)
    {
        args.Expandable = args.Data.ShipCountry == "France" || args.Data.ShipCountry == "Brazil";
    }

    protected override void OnAfterRender(bool firstRender)
    {
        if (firstRender)
        {
            grid.ExpandRow(orders.FirstOrDefault());
            StateHasChanged();
        }

        base.OnAfterRender(firstRender);
    }
}
```

## Selection

Bind DataGrid `Value` property or assign callback for `RowSelect` event to enable selection. Use `SelectionMode` to specify if selecting of single or multiple items is allowed.

```
<Property365DataGrid Data="@employees" TItem="Employee" SelectionMode="DataGridSelectionMode.Single" @bind-Value=@selectedEmployees>
        <Columns>
        ...
@code {
    IEnumerable<Employee> employees;
    IList<Employee> selectedEmployees;

    void ClearSelection()
    {
        selectedEmployees = null;
    }

    protected override void OnInitialized()
    {
        employees = dbContext.Employees;
        selectedEmployees = employees.Take(1).ToList();
    }
}        
```

## Conditional formatting

Use `RowRender` and `CellRender` events to specify various row/cell attributes.

```
<Property365DataGrid Data="@orderDetails" TItem="OrderDetail" RowRender="@RowRender" CellRender="@CellRender">
                ...
@code {
    IEnumerable<OrderDetail> orderDetails;

    protected override void OnInitialized()
    {
        orderDetails = dbContext.OrderDetails.Include("Product").ToList();
    }

    void RowRender(RowRenderEventArgs<OrderDetail> args)
    {
        args.Attributes.Add("style", $"font-weight: {(args.Data.Quantity > 20 ? "bold" : "normal")};");
    }

    void CellRender(DataGridCellRenderEventArgs<OrderDetail> args)
    {
        if (args.Column.Property == "Quantity")
        {
            args.Attributes.Add("style", $"background-color: {(args.Data.Quantity > 20 ? "#ff6d41" : "white")};");

            if (args.Data.Discount == 0)
            {
                args.Attributes.Add("colspan", 2);
            }
        }

        if (args.Column.Property == "OrderID")
        {
            if (args.Data.OrderID == 10248 && args.Data.ProductID == 11 || args.Data.OrderID == 10250 && args.Data.ProductID == 41)
            {
                args.Attributes.Add("rowspan", 3);
            }

            if (args.Data.OrderID == 10249 && args.Data.ProductID == 14 || args.Data.OrderID == 10251 && args.Data.ProductID == 22)
            {
                args.Attributes.Add("rowspan", 2);
            }
        }
    }
```
