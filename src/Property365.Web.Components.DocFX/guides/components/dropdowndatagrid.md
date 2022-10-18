# DropDownDataGrid component
This article demonstrates how to use the DropDownDataGrid component.
 
## Get and set the value
As all Property365 Blazor input components the CheckBoxList has a `Value` property which gets and sets the value of the component.
Use `@bind-Value` to get the user input. The `TValue` property should be set to the `Value` property type.

## Data-binding
To display data in DropDownDataGrid component you need to set collection of items (`IEnumerable<>`) to `Data` property. Optionally you can set `TextProperty` to the string property name of the item in the collection and  `ValueProperty` to the property name with unique values in the collection or define collection of `Property365DataGridColumn` in `Columns`.

### Binding to simple collection

```
<Property365DropDownDataGrid TValue="string" Data=@(customers.Select(c => c.CompanyName).Distinct()) Change="@OnChange" />

@code {
    IEnumerable<Customer> customers;

    protected override void OnInitialized()
    {
        customers = dbContext.Customers.ToList();
    }

    void OnChange(object value)
    {
        var str = value is IEnumerable<object> ? string.Join(", ", (IEnumerable<object>)value) : value;

        Console.WriteLine($"Value changed to {str}");
    }
}
```

### Binding to list of objects

```
<Property365DropDownDataGrid TValue="string" Data=@customers TextProperty="CompanyName" ValueProperty="CustomerID" Change="@OnChange" />

@code {
    IEnumerable<Customer> customers;

    protected override void OnInitialized()
    {
        customers = dbContext.Customers.ToList();
    }

    void OnChange(object value)
    {
        var str = value is IEnumerable<object> ? string.Join(", ", (IEnumerable<object>)value) : value;

        Console.WriteLine($"Value changed to {str}");
    }
}
```

### Binding using LoadData event with filtering.

```
<Property365DropDownDataGrid TValue="string" Data=@customers TextProperty="CompanyName" ValueProperty="CustomerID" LoadData=@LoadData AllowFiltering="true" />

@code {
    IEnumerable<Customer> customers;

    void LoadData(LoadDataArgs args)
    {
        var query = dbContext.Customers.AsQueryable();

        if (!string.IsNullOrEmpty(args.Filter))
        {
            query = query.Where(c => c.CustomerID.ToLower().Contains(args.Filter.ToLower()) || c.ContactName.ToLower().Contains(args.Filter.ToLower()));
        }

        customers = query.ToList();

        InvokeAsync(StateHasChanged);
    }
}
```

### Virtualization using IQueryable.

```
<Property365DropDownDataGrid TValue="string" AllowVirtualization="true" AllowFiltering="true" Data=@customers TextProperty="CompanyName" ValueProperty="CustomerID" />

@code {
    IEnumerable<Customer> customers;

    protected override void OnInitialized()
    {
        customers = dbContext.Customers.ToList();
    }
}
```

### Virtualization using LoadData event.

```
<Property365DropDownDataGrid TValue="string" AllowVirtualization="true" LoadData=@LoadDataVirtualization AllowFiltering="true" Count="@count"
                                Data=@customers TextProperty="CompanyName" ValueProperty="CustomerID" />

@code {
    IEnumerable<Customer> customers;

    void LoadDataVirtualization(LoadDataArgs args)
    {
        var query = dbContext.Customers.AsQueryable();

        if (!string.IsNullOrEmpty(args.Filter))
        {
            query = query.Where(c => c.CustomerID.ToLower().Contains(args.Filter.ToLower()) || c.ContactName.ToLower().Contains(args.Filter.ToLower()));
        }

        count = query.Count();

        customers = query.Skip(args.Skip.Value).Take(args.Top.Value).ToList();

        InvokeAsync(StateHasChanged);
    }
}
```

### Columns
Define columns in `Columns` tag.
```
<Property365DropDownDataGrid TValue="string" Data=@customers TextProperty="CompanyName" ValueProperty="CustomerID">
    <Columns>
        <Property365DropDownDataGridColumn Property="CustomerID" Title="CustomerID" Width="100px" />
        <Property365DropDownDataGridColumn Property="CompanyName" Title="CompanyName" Width="200px" />
        <Property365DropDownDataGridColumn Property="City" Title="City" Width="100px" />
        <Property365DropDownDataGridColumn Property="Country" Title="Country" Width="100px" />
    </Columns>
</Property365DropDownDataGrid>

@code {
    IEnumerable<Customer> customers;

    protected override void OnInitialized()
    {
        customers = dbContext.Customers.ToList();
    }
}
```

### Filtering
Use `AllowFiltering`, `AllowFilteringByAllStringColumns`, `FilterCaseSensitivity` and `FilterOperator` properties to allow and control filtering. 
```
<Property365DropDownDataGrid TValue="string" Data=@customers TextProperty="CompanyName" ValueProperty="CustomerID" 
    AllowFiltering="true" AllowFilteringByAllStringColumns="true"
    FilterCaseSensitivity="FilterCaseSensitivity.CaseInsensitive" FilterOperator="StringFilterOperator.StartsWith">
    <Columns>
        <Property365DropDownDataGridColumn Property="CustomerID" Title="CustomerID" Width="100px" />
        <Property365DropDownDataGridColumn Property="CompanyName" Title="CompanyName" Width="200px" />
        <Property365DropDownDataGridColumn Property="City" Title="City" Width="100px" />
        <Property365DropDownDataGridColumn Property="Country" Title="Country" Width="100px" />
    </Columns>
</Property365DropDownDataGrid>

@code {
    IEnumerable<Customer> customers;

    protected override void OnInitialized()
    {
        customers = dbContext.Customers.ToList();
    }
}
```

### Multiple selection
Bind `Value` property and use `Multiple` property to control if selection is multiple or not. 
```
<Property365DropDownDataGrid @ref="grid" @bind-Value=@multipleValues Multiple="true"  
                        Data=@customers TextProperty="CompanyName" ValueProperty="CustomerID"
                        Change=@OnChange Style="width:100%">
    <Columns>
        <Property365DropDownDataGridColumn Width="40px" Sortable="false">
            <HeaderTemplate>
                <Property365CheckBox TriState="false" TValue="bool" Value="@(customers.Any(c => multipleValues != null && multipleValues.Contains(c.CustomerID)))"
                                Change="@(args => multipleValues = args ? grid.View.Cast<Customer>().Select(c => c.CustomerID) : multipleValues = Enumerable.Empty<string>())" />
            </HeaderTemplate>
            <Template Context="data">
                <Property365CheckBox TriState="false" Value="@(multipleValues != null && multipleValues.Contains(((Customer)data).CustomerID))" />
            </Template>
        </Property365DropDownDataGridColumn>
        <Property365DropDownDataGridColumn Property="CustomerID" Title="CustomerID" Width="100px" />
        <Property365DropDownDataGridColumn Property="CompanyName" Title="CompanyName" Width="200px" />
        <Property365DropDownDataGridColumn Property="City" Title="City" Width="100px" />
        <Property365DropDownDataGridColumn Property="Country" Title="Country" Width="100px" />
    </Columns>
</Property365DropDownDataGrid>

@code {
    IEnumerable<Customer> customers;
    IEnumerable<string> multipleValues;

    protected override void OnInitialized()
    {
        customers = dbContext.Customers.ToList();
    }

    void OnChange(object value)
    {
        var str = value is IEnumerable<object> ? string.Join(", ", (IEnumerable<object>)value) : value;

        console.Log($"Value changed to {str}");
    }
}
```