# RequiredValidator component
This article demonstrates how to use Property365RequiredValidator.

## Basic usage
Property365RequiredValidator checks if the user entered a required value.

To use it perform these steps:
1. Add an input component and set its `Name`. Data-bind its value to a model property via `@bind-Value=@model.Email`.
1. Add Property365RequiredValidator and set its `Component` property to the `Name` of the input component. 

> [!IMPORTANT]
> Property365RequiredValidator works only inside [Property365TemplateForm](templateform.md). 

Here is a typical user registration form which checks if the user entered the same password.
```
<Property365TemplateForm TItem="Registration" Data=@model>
    <p>
      <Property365Label Text="Email" />
      <Property365TextBox Name="Email" @bind-Value=@model.Email />
      <Property365RequiredValidator Component="Email" Text="Enter email" />
    </p>
    <Property365Button ButtonType="ButtonType.Submit" Text="Submit"></Property365Button>
</Property365TemplateForm>
@code {
    class Registration
    {
        public string Email { get; set; }
    }

    Registration model = new Registration();
}
```
## Default value
Sometimes the default property value is not `null`. Then Property365RequiredValidator will never trigger. In such cases you need to
set the `DefaultValue` property. A common use case are numeric properties whose default value is `0`. To validate such properties
with Property365RequiredValidator set its `DefaultValue` to `0`.
```
<Property365TemplateForm TItem="Registration" Data=@model>
    <p>
      <Property365Label Text="Age" />
      <Property365Numeric Name="Age" @bind-Value=@model.Age />
      <Property365RequiredValidator Component="Age" Text="Age is required" DefaultValue="0" />
    </p>
    <Property365Button ButtonType="ButtonType.Submit" Text="Submit"></Property365Button>
</Property365TemplateForm>
@code {
    class Registration
    {
        public string Email { get; set; }
        public int Age { get; set; } // Age is set to 0 by default
    }

    Registration model = new Registration();
}
```
## Conditional validation
To make the validator conditional you can set its `Visible` property. When set to `false` the validator will not run.
## Appearance
By default Property365RequiredValidator appears next to the component it validates.

To make it appear below set its `Style` to `"display:block"`. 
```
<Property365TextBox Name="Email" @bind-Value=@model.Email />
<Property365RequiredValidator Component="Email" Text="Enter email" Style="display:block" />
```
To make it appear as a styled popup set its `Popup` property to `true` and set its CSS position to `absolute`. The validated component should have `display: block` so the validation message appears right below it.
```
<Property365TextBox Name="Email" @bind-Value=@model.Email Style="display:block" />
<Property365RequiredValidator Component="Email" Text="Enter email" Style="position:absolute" Popup="true" />
```