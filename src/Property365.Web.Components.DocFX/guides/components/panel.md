# Panel component
This article demonstrates how to use the Panel component.

## Templates
Use `HeaderTemplate`, `ChildContent` and `SummaryTemplate` to define custom content for Panel component parts.

```
<Property365Panel>
    <HeaderTemplate>
        Custom header
    </HeaderTemplate>
    <ChildContent>
        Custom content
    </ChildContent>
    <SummaryTemplate>
        Custom summary
    </SummaryTemplate>
</Property365Panel>
```

## Expand/Collapse
Use `AllowCollapse` property to allow expand/collapse and `Expand` and `Collapse` callbacks to catch if Panel component is expanded or collapsed.

```
<Property365Panel AllowCollapse="true" Expand=@(() => Change("Panel expanded")) Collapse=@(() => Change("Panel collapsed"))>
    <HeaderTemplate>
        Custom header
    </HeaderTemplate>
    <ChildContent>
        Custom content
    </ChildContent>
    <SummaryTemplate>
        Custom summary
    </SummaryTemplate>
</Property365Panel>

@code {
    void Change(string text)
    {
        Console.WriteLine($"{text}");
    }
}
```