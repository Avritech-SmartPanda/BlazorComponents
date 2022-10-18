# SplitButton component
This article demonstrates how to use the SplitButton component. 

```
<Property365SplitButton Click=@OnClick Text="SplitButton" Icon="account_circle">
    <ChildContent>
        <Property365SplitButtonItem Text="Item1" Value="1" Icon="account_box" />
        <Property365SplitButtonItem Text="Item2" Value="2" Icon="account_balance_wallet" />
    </ChildContent>
</Property365SplitButton>

@code {
    void OnClick(Property365SplitButtonItem item)
    {
        if(item != null)
        {
            Console.WriteLine($"Item with value {item.Value} clicked");
        }
        else
        {
            Console.WriteLine($"Button clicked");
        }
    }
}
```