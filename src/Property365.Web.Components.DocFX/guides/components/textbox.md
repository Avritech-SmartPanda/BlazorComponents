# TextBox component
This article demonstrates how to use the TextBox component. 

## Get and set the value
As all Property365 Blazor input components the TextBox has a `Value` property which gets and sets the value of the component.
Use `@bind-Value` to get the user input.

```
<Property365TextBox @bind-Value=@firstEmployee.FirstName TValue="string" Change=@OnChange />
@code {
    Employee firstEmployee;

    protected override async Task OnInitializedAsync()
    {
        firstEmployee = await Task.FromResult(dbContext.Employees.FirstOrDefault());
    }

    void OnChange(string value)
    {
        Console.WriteLine($"Value changed to {value}");
    }
}
```

## Properties
Use `Disabled`, `ReadOnly`, `Placeholder`, `MaxLength` and `AutoComplete` properties to control various HTML input attributes. You can set also arbitrary attributes not exposed as properties.
```
<Property365TextBox Placeholder="Type here .." MaxLength="10" AutoComplete="false" @oninput=@(args => OnChange(args.Value.ToString())) />

@code {
    void OnChange(string value)
    {
        Console.WriteLine($"Value changed to {value}");
    }
}
```