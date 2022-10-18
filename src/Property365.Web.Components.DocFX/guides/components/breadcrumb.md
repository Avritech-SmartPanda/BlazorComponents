# Badge component
This article demonstrates how to use the BreadCrumb component. 

The Bread Crumb offers a Menu like experience, with an optional custom Template.

## Standard Bread Crumb Menu
```
<Property365BreadCrumb>
    <Items>
        <Property365BreadCrumbItem Text="Layout & Navigation" />
        <Property365BreadCrumbItem Text="Bread Crumb" />
    </Items>
</Property365BreadCrumb>
```

## Optional Template
The optional Template can be defined using the `Template` Property of the `Property365BreadCrumb` component.
The Context ist of Type `Property365BreadCrumbItem`.
```
<Property365BreadCrumb>
    <Template context="itm">
        <Property365Badge Text="@itm.Text" />
    </Template>
    <Items>
        <Property365BreadCrumbItem Text="Layout & Navigation" />
        <Property365BreadCrumbItem Text="Bread Crumb" />
    </Items>
</Property365BreadCrumb>
```
This template renders all items of the Menu in a `Property365Badge`.