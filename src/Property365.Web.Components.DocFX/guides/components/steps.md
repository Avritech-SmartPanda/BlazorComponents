# Steps component
This article demonstrates how to use Steps.

```
<Property365Steps @bind-SelectedIndex=@selectedIndex Change=@OnChange>
    <Steps>
        <Property365StepsItem Text="Customers">
            Customers
        </Property365StepsItem>
        <Property365StepsItem Text="Orders" Disabled="@(selectedCustomers == null || selectedCustomers != null && !selectedCustomers.Any())">
            Orders
        </Property365StepsItem>
        <Property365StepsItem Text="Order Details" Disabled="@(selectedOrders == null || selectedOrders != null && !selectedOrders.Any())">
            Order Details
        </Property365StepsItem>
    </Steps>
</Property365Steps>

@code {
    int selectedIndex = 0;

    void OnChange(int index)
    {
        console.Log($"Step with index {index} was selected.");
    }
}
```