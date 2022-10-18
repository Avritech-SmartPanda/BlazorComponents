# How to use a Property365 Blazor component
This article will show you how to add a Property365 Blazor component to a page, sets its properties and handle its events.

## Add component 
To add a Property365 Blazor component type its tag name in a `.razor` file e.g. `<Property365Button>`. All Property365 components
start with a common prefix `Property365` to make it easier for you to find in auto complete.
```
<Property365Button />
```
## Set properties
To set a component property assign the corresponding attribute to the desired value.

### [Constant](#tab/constant)
```
<Property365Button Text="Hello world!" />
```
### [Property or field](#tab/property)
```
<Property365Button Text=@text />
@code {
    string text = "Hello World!";
}
```
***
## Handle events
To handle an event create a method and assign the corresponding attribute to the method name. 
```
<Property365Button Text="Hello World!" Click=@OnButtonClick />
@code {
    void OnButtonClick()
    {

    }
}
```
## Common properties
The Property365 Blazor components share a few common properties that are often used.
### Style
The `Style` property is used to specify inline CSS settings. It renders as the `style` HTML attribute. Use it to set the width and height of a component.
```
<Property365Button Style="width: 100px; height: 20px" />
```
### Visible
The `Visible` property is used to toggle a component. If it is set to `false` the component will not render.
```
<Property365TextBox Visible=@visible />
<Property365Button Text="Toggle" Click=@ToggleVisible />
@code {
   bool visible = true;
   void ToggleVisible()
   {
       visible = !visible;
   }
}
```
### Value
All Property365 input components (e.g. Property365TextBox, Property365DropDown, Property365ListBox) have a `Value` property. It is used to get and set the value of the component. It can also be used to data-bind the value to a property or field. Data-binding means that changing the component value (e.g. typing text) also updates a property or field. Use `@bind-Value` for this case.
```
<Property365TextBox @bind-Value=@firstName />
@code {
    // The initial Property365TextBox value is "Jane". Typing in Property365TextBox will update firstName.
    string firstName = "Jane";
}
```
### Disabled
It is a common requirement to disable input components or buttons. The `Disabled` property allows that.
```
<Property365Button Disabled="true" />
```
### Data
Some Property365 Blazor components display a collection of items. All of them have a `Data` property which must be set to that collection.
```
<Property365DropDown Data=@items TextProperty="Name" />
@code {
    class DataItem
    {
        public string Name { get; set; }
        public int Value { get; set; }
    }

    IEnumerable<DataItem> items = new List<DataItem>()
    {
        new DataItem { Name = "Jane Doe", Value = 1},
        new DataItem { Name = "John Doe", Value = 2},
    };
}
```