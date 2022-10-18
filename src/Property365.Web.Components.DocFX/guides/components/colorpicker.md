# ColorPicker component
This article demonstrates how to use the ColorPicker component.

## Get and set the value
As all Property365 Blazor input components the ColorPicker has a `Value` property which gets and sets the value of the component.
Use `@bind-Value` to get the user input.

```
<Property365ColorPicker @bind-Value=@color Change=@OnChange />
@code {
    string color = "rgb(68, 58, 110)";

    void OnChange(string value)
    {
        Console.WriteLine($"Value changed to {value}");
    }
}
```
