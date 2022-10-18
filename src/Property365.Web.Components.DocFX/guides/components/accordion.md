# Accordion component
This article demonstrates how to use the Accordion component.

## Single item expand

```
<Property365Accordion>
    <Items>
        <Property365AccordionItem Text="Orders" Icon="account_balance_wallet">
            Details for Orders
        </Property365AccordionItem>
        <Property365AccordionItem Text="Employees" Icon="account_box">
            Details for Employees
        </Property365AccordionItem>
        <Property365AccordionItem Text="Customers" Icon="accessibility">
            Details for Customers
        </Property365AccordionItem>
    </Items>
</Property365Accordion>
```

## Multiple items expand

```
<Property365Accordion Multiple="true">
    <Items>
        <Property365AccordionItem Text="Orders" Icon="account_balance_wallet">
            Details for Orders
        </Property365AccordionItem>
        <Property365AccordionItem Text="Employees" Icon="account_box">
            Details for Employees
        </Property365AccordionItem>
        <Property365AccordionItem Text="Customers" Icon="accessibility">
            Details for Customers
        </Property365AccordionItem>
    </Items>
</Property365Accordion>
```

## Expand/Collapse events

```
<Property365Accordion Collapse=@(args => Change(args, "collapsed"))
                 Expand=@(args => Change(args, "expanded"))>
    <Items>
        <Property365AccordionItem Text="Orders" Icon="account_balance_wallet">
            Details for Orders
        </Property365AccordionItem>
        <Property365AccordionItem Text="Employees" Icon="account_box">
            Details for Employees
        </Property365AccordionItem>
        <Property365AccordionItem Text="Customers" Icon="accessibility">
            Details for Customers
        </Property365AccordionItem>
    </Items>
</Property365Accordion>

@code {
    void Change(object value, string action)
    {
        Console.WriteLine($"Item with index {value} {action}");
    }
}
```
