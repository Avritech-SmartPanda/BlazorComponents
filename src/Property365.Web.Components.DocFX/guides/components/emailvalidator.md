# EmailValidator component
This article demonstrates how to use Property365EmailValidator.

## Basic usage
Property365EmailValidator checks if the user input is a valid email address.

To use it perform these steps:
1. Add an input component and set its `Name`. Data-bind its value to a model property via `@bind-Value=@model.Email`.
1. Add Property365EmailValidator and set its `Component` property to the `Name` of the input component. 

> [!IMPORTANT]
> Property365EmailValidator works only inside [Property365TemplateForm](templateform.md). 

Here is a typical user registration form which checks if the user entered the same password.
```
<Property365TemplateForm TItem="Registration" Data=@model>
    <p>
      <Property365Label Text="Email" />
      <Property365TextBox Name="Email" @bind-Value=@model.Email />
      <Property365EmailValidator Component="Email" Text="Enter email" />
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
## Conditional validation
To make the validator conditional you can set its `Visible` property. When set to `false` the validator will not run.
## Appearance
By default Property365EmailValidator appears next to the component it validates.

To make it appear below set its `Style` to `"display:block"`. 
```
<Property365TextBox Name="Email" @bind-Value=@model.Email />
<Property365EmailValidator Component="Email" Text="Enter email" Style="display:block" />
```
To make it appear as a styled popup set its `Popup` property to `true` and set its CSS position to `absolute`. The validated component should have `display: block` so the validation message appears right below it.
```
<Property365TextBox Name="Email" @bind-Value=@model.Email Style="display:block" />
<Property365EmailValidator Component="Email" Text="Enter email" Style="position:absolute" Popup="true" />
```