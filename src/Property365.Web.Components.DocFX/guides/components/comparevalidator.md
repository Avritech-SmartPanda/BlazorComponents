# CompareValidator component
This article demonstrates how to use Property365CompareValidator.

## Basic usage
Property365CompareValidator compares the user input agains a predefined value or another component.

To use it perform these steps:
1. Add an input component and set its `Name`. Data-bind its value to a model property via `@bind-Value=@model.Property`.
1. Add Property365CompareValidator and set its `Component` property to the `Name` of the input component. Set its `Value` property to 
the value you want to compare with (usually another model property).

> [!IMPORTANT]
> Property365CompareValidator works only inside [Property365TemplateForm](templateform.md). 

Here is a typical user registration form which checks if the user entered the same password.
```
<Property365TemplateForm TItem="Registration" Data=@model>
    <p>
      <Property365Label Text="Password" />
      <Property365Password Name="Password" @bind-Value=@model.Password />
      <Property365RequiredValidator Component="Password" Text="Enter password" />
    </p>
    <p>
        <Property365Label Text="Repeat Password" />
        <Property365Password Name="RepeatPassword" @bind-Value=@model.RepeatPassword />
        <Property365RequiredValidator Component="RepeatPassword" Text="Repeat your password" />
        <Property365CompareValidator Visible=@(!string.IsNullOrEmpty(model.RepeatPassword)) Value=@model.Password Component="RepeatPassword" Text="Passwords should be the same" Popup=@popup Style="position: absolute" />
    </p>
    <Property365Button ButtonType="ButtonType.Submit" Text="Submit"></Property365Button>
</Property365TemplateForm>
@code {
    class Registration
    {
        public string Password { get; set; }
        public string RepeatPassword { get; set; }
    }

    Registration model = new Registration();
}
```
## Conditional validation
To make the validator conditional you can set its `Visible` property. When set to `false` the validator will not run.
In this example `Visible` is set to `!string.IsNullOrEmpty(model.RepeatPassword)` - the validator will not run if `RepeatPassword` is empty.
```
<Property365CompareValidator Visible=@(!string.IsNullOrEmpty(model.RepeatPassword)) Value=@model.Password Component="RepeatPassword" Text="Passwords should be the same" Popup=@popup Style="position: absolute" />
```
## Comparison operator
By default Property365CompareValidator checks if the component value is equal to `Value`. This can be changed via the `Operator` property.
```
<Property365Numeric Name="Count" @bind-Value=@model.Count />
<Property365CompareValidator Component="Count" Text="Count should be less than 10" Operator="CompareOperator.LessThan" Value="10" />
```
## Appearance
By default Property365CompareValidator appears next to the component it validates.

To make it appear below set its `Style` to `"display:block"`. 
```
<Property365Numeric Name="Count" @bind-Value=@model.Count />
<Property365CompareValidator Style="display:block" Component="Count" Text="Count should be less than 10" Operator="CompareOperator.LessThan" Value="10" />
```
To make it appear as a styled popup set its `Popup` property to `true` and set its CSS position to `absolute`. The validated component should have `display: block` so the validation message appears right below it.
```
<Property365Numeric Name="Count" @bind-Value=@model.Count Style="display:block" />
<Property365CompareValidator Style="position:absolute" Popup="true" Component="Count" Text="Count should be less than 10" Operator="CompareOperator.LessThan" Value="10" />
```