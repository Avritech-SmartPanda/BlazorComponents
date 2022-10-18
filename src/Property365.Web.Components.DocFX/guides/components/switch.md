# Switch component
This article demonstrates how to use the Switch component.

## Get and set the value
As all Property365 Blazor input components the Switch has a `Value` property which gets and sets the value of the component.
Use `@bind-Value` to get the user input.

```
<Property365Switch @bind-Value=@value Change=@OnChange />
@code {
    bool value;

    void OnChange(bool value)
    {
        Console.WriteLine($"Value changed to {value}");
    }
}
```
