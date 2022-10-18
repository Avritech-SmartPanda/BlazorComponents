# NumericRangeValidator component
This article demonstrates how to use Property365NumericRangeValidator.

## Basic usage
Property365NumericRangeValidator checks if the user enters a number within a specified range.

To use it perform these steps:
1. Add an input component and set its `Name`. Data-bind its value to a model property via `@bind-Value=@model.Quantity`.
1. Add Property365NumericRangeValidator and set its `Component` property to the `Name` of the input component. Set `Min`, `Max` or both
to specify the valid range.

> [!IMPORTANT]
> Property365NumericRangeValidator works only inside [Property365TemplateForm](templateform.md). 

```
<Property365TemplateForm TItem="Registration" Data=@model>
    <p>
        <Property365Numeric Name="Quantity" @bind-Value=@model.Quantity />
        <Property365NumericRangeValidator Component="Quantity" Min="1" Max="10" Text="Quantity should be between 1 and 10" />
    </p>
    <Property365Button ButtonType="ButtonType.Submit" Text="Submit"></Property365Button>
</Property365TemplateForm>
@code {
    class Model
    {
        public decimal Quantity { get; set; }
    }

    Model model = new Model();
}
```
## Conditional validation
To make the validator conditional you can set its `Visible` property. When set to `false` the validator will not run.
## Appearance
By default Property365NumericRangeValidator appears next to the component it validates.

To make it appear below set its `Style` to `"display:block"`. 
```
<Property365Numeric Name="Quantity" @bind-Value=@model.Quantity />
<Property365NumericRangeValidator Style="display:block" Component="Quantity" Min="1" Max="10" Text="Quantity should be between 1 and 10" />
```
To make it appear as a styled popup set its `Popup` property to `true` and set its CSS position to `absolute`. The validated component should have `display: block` so the validation message appears right below it.
```
<Property365Numeric Name="Quantity" Style="display:block" @bind-Value=@model.Quantity />
<Property365NumericRangeValidator Popup="true" Style="position:absolute" Component="Quantity" Min="1" Max="10" Text="Quantity should be between 1 and 10" />
```