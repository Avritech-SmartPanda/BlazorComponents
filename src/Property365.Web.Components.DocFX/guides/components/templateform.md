# TemplateForm component
This article demonstrates how to use Property365TemplateForm

## Basic usage
Property365TemplateForm is a wrapper of the HTML `<form>` element and provides validation capabilites through various validator components.

To use Property365TemplateForm you need to:
1. Set `TItem` and `Data` of Property365TemplateForm to set its model.
1. Add input components. Use `@bind-Value` to data-bind their value to model properties.
1. Add validator components.
1. Add a submit button that will trigger form submission and validation.
1. Handle the `Submit event`.
```
<Property365TemplateForm TItem="Person" Data=@model Submit=@OnSubmit>
  <p>
    <Property365Label Component="FirstName" Text="First name" />
    <Property365TextBox Name="FirstName" @bind-Value=@model.FirstName />
    <Property365RequiredValidator Component="FirstName" Text="First name is required!" />
  </p>
  <p>
    <Property365Label Component="LastName" Text="Last name" />
    <Property365TextBox Name="LastName" @bind-Value=@model.LastName />
    <Property365RequiredValidator Component="LastName" Text="Last name is required!" />
  </p>
  <Property365Button ButtonType="ButtonType.Submit" Text="Save" />
</Property365TemplateForm>
@code {
  class Person
  {
      public string FirstName { get; set; }
      public string LastName { get; set; }
  }

  Person model = new Person();

  void OnSubmit(Person person)
  {
  }
}
```
## Set default values
Setting default form values is easy - just set your model's properties to the desired values.
```
Person model = new Person { FirstName = "Jane", LastName = "Doe" };
```
## Submit form to URL
A common requirement is to submit a form to a URL - third party application, custom login action etc. Property365TemplateForm supports
this out of the box via the `Action` and `Method` properties. 
```
<Property365TemplateForm Action="/user/update" Method="post" TItem="Person" Data=@model>
  <p>
    <Property365Label Component="FirstName" Text="First name" />
    <Property365TextBox Name="FirstName" @bind-Value=@model.FirstName />
    <Property365RequiredValidator Component="FirstName" Text="First name is required!" />
  </p>
  <p>
    <Property365Label Component="LastName" Text="Last name" />
    <Property365TextBox Name="LastName" @bind-Value=@model.LastName />
    <Property365RequiredValidator Component="LastName" Text="Last name is required!" />
  </p>
  <Property365Button ButtonType="ButtonType.Submit" Text="Save" />
</Property365TemplateForm>
```
## Troubleshooting
Here are a few common issues and what could be causing them.
### Property365TemplateForm does not fire the Submit event
This could happen in the following cases:
- There is a validation error.
- The form does not have a submit button.
### I have added validators to my form but they do not work
This could happen in the following cases:
- The `Name` of the validated component does not match the `Component` of the validator.
- The component value is not data-bound e.g. it uses `Value=@model.Property` instead of `@bind-Value=@model.Property`.
- The `Data` property of the form is not set.
- The form does not have a submit button.