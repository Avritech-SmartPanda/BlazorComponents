# RegexValidator component
This article demonstrates how to use Property365RegexValidator.

## Basic usage
Property365RegexValidator checks if the user input matches the specified regular expression.

To use it perform these steps:
1. Add an input component and set its `Name`. Data-bind its value to a model property via `@bind-Value=@model.Zip`.
1. Add Property365RegexValidator and set its `Component` property to the `Name` of the input component. Set the `Pattern` property to the regular expression you want to validate against.

> [!IMPORTANT]
> Property365RegexValidator works only inside [Property365TemplateForm](templateform.md). 

```
<Property365TemplateForm TItem="Registration" Data=@model>
    <p>
       <Property365TextBox Name="ZIP" @bind-Value=@model.Zip />
       <Property365RegexValidator Component="ZIP" Text="ZIP code must be 5 digits" Pattern="\d{5}" />
    </p>
    <Property365Button ButtonType="ButtonType.Submit" Text="Submit"></Property365Button>
</Property365TemplateForm>
@code {
    class Model
    {
        public string Zip { get; set; }
    }

    Model model = new Model();
}
```
## Conditional validation
To make the validator conditional you can set its `Visible` property. When set to `false` the validator will not run.
## Appearance
By default Property365RegexValidator appears next to the component it validates.

To make it appear below set its `Style` to `"display:block"`. 
```
<Property365TextBox Name="ZIP" @bind-Value=@model.Zip />
<Property365RegexValidator Style="display:block" Component="ZIP" Text="ZIP code must be 5 digits" Pattern="\d{5}" />
```
To make it appear as a styled popup set its `Popup` property to `true` and set its CSS position to `absolute`. The validated component should have `display: block` so the validation message appears right below it.
```
<Property365TextBox Style="display:block" Name="ZIP" @bind-Value=@model.Zip />
<Property365RegexValidator Popup="true" Style="position:absolute" Component="ZIP" Text="ZIP code must be 5 digits" Pattern="\d{5}" />
```