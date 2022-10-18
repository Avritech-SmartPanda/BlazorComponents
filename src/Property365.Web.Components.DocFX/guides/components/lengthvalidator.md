# LengthValidator component
This article demonstrates how to use Property365LengthValidator.

## Basic usage
Property365LengthValidator checks if the user input is within specified length.

To use it perform these steps:
1. Add an input component and set its `Name`. Data-bind its value to a model property via `@bind-Value=@model.FirstName`.
1. Add Property365LengthValidator and set its `Component` property to the `Name` of the input component. Set `Min`, `Max` or both
to specify the valid string length.

> [!IMPORTANT]
> Property365LengthValidator works only inside [Property365TemplateForm](templateform.md). 

```
<Property365TemplateForm TItem="Registration" Data=@model>
    <p>
      <Property365TextBox style="display: block" Name="FirstName" @bind-Value=@model.FirstName />
      <Property365LengthValidator Component="FirstName" Min="3" Text="First name should be at least 3 characters" />
      <Property365LengthValidator Component="FirstName" Max="10" Text="First name should be at most 10 characters" />
    </p>
    <Property365Button ButtonType="ButtonType.Submit" Text="Submit"></Property365Button>
</Property365TemplateForm>
@code {
    class Registration
    {
        public string FirstName { get; set; }
    }

    Registration model = new Registration();
}
```
## Conditional validation
To make the validator conditional you can set its `Visible` property. When set to `false` the validator will not run.
## Appearance
By default Property365LengthValidator appears next to the component it validates.

To make it appear below set its `Style` to `"display:block"`. 
```
<Property365TextBox Name="FirstName" @bind-Value=@model.FirstName />
<Property365LengthValidator Style="display:block" Component="FirstName" Min="3" Text="First name should be at least 3 characters" />
```
To make it appear as a styled popup set its `Popup` property to `true` and set its CSS position to `absolute`. The validated component should have `display: block` so the validation message appears right below it.
```
<Property365TextBox Name="FirstName" @bind-Value=@model.FirstName Style="display:block" />
<Property365LengthValidator Popup="true" Style="position:absolute" Component="FirstName" Min="3" Text="First name should be at least 3 characters" />
```