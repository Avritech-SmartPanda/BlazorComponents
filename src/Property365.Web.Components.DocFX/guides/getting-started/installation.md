# Installation
This article shows you how to add Property365 Blazor components to your project.

1. [Install the Nuget package](#install-the-nuget-package)
1. [Import the namespaces](#import-the-namespaces)
1. [Include the CSS and JS](#include-the-css-and-js)

## Install the Nuget package
Property365 Blazor Components are distributed as the [Property365.Blazor](https://www.nuget.org/packages/Property365.Blazor)"> nuget package.

You can add them to your project in one of the following ways
- Install the package from command line by running `dotnet add package Property365.Blazor`.
- Add the project from the Visual Nuget Package Manager <img class="ml-0" src="../../../images/nuget-explorer.png">
- Manually edit the .csproj file and add a project reference ``

## Import the namespaces
Open the `_Imports.razor` file of your Blazor application and add these two lines:

```
@using Property365
@using Property365.Blazor
```

## Include the CSS and JS

### Include CSS
Open `Pages\_Layout.cshtml` (Blazor Server .NET 6+), `Pages\_Host.cshtml` (Blazor Server before .NET 6) or `wwwroot/index.html` (Blazor WebAssembly) and include a theme CSS file by adding this snippet:
```
<link rel="stylesheet" href="_content/Property365.Blazor/css/default-base.css">
```
Property365 also ships CSS files that include some vital parts of Bootstrap (mostly layout). To use a theme bundled with Bootstrap include the file without `-base` suffix:
```
<link rel="stylesheet" href="_content/Property365.Blazor/css/default.css">
```

### Include the JS
Open `Pages\_Layout.cshtml` (Blazor Server .NET 6+), `Pages\_Host.cshtml` (Blazor Server before .NET 6) or `wwwroot/index.html` (Blazor WebAssembly) and include a theme CSS file by adding this snippet:
```
<script src="_content/Property365.Blazor/Property365.Blazor.js"></script>
```

## Next steps

You are now ready to use Property365 Blazor components! Check [Using a component](use-component.md) to see how to add a Property365 Blazor component to your page.

Some components require additional setup:

- [Context menu](context-menu.md)
- [Dialog](dialog.md)
- [Notification](context-menu.md)
- [Tooltip](tooltip.md)