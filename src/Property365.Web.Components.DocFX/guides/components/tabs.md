# Tabs component
This article demonstrates how to use Tabs.

## Server render mode
Only selected tab content will be rendered.
```
<Property365Tabs @bind-SelectedIndex=@selectedIndex Change=@OnChange>
    <Tabs>
        <Property365TabsItem Text="Customers">
            Customers
        </Property365TabsItem>
        <Property365TabsItem Text="Orders">
            Orders
        </Property365TabsItem>
        <Property365TabsItem Text="Order Details">
            Order Details
        </Property365TabsItem>
    </Tabs>
</Property365Tabs>

@code {
    int selectedIndex = 0;

    void OnChange(int index)
    {
        console.Log($"Tab with index {index} was selected.");
    }
}
```

## Client render mode
All tabs will be rendered initially and tab change will be performed completely using JavaScript
```
<Property365Tabs RenderMode="TabRenderMode.Client" @bind-SelectedIndex=@selectedIndex Change=@OnChange>
    <Tabs>
        <Property365TabsItem Text="Customers">
            Customers
        </Property365TabsItem>
        <Property365TabsItem Text="Orders">
            Orders
        </Property365TabsItem>
        <Property365TabsItem Text="Order Details">
            Order Details
        </Property365TabsItem>
    </Tabs>
</Property365Tabs>

@code {
    int selectedIndex = 0;

    void OnChange(int index)
    {
        console.Log($"Tab with index {index} was selected.");
    }
}
```