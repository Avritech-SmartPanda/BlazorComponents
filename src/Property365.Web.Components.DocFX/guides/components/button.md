# Button component
This article demonstrates how to use Property365Button.

## Basic usage
The most basic configuration of Property365Button is to set its `Text` property and handle the `Click` event.
```
<Property365Button Click=@OnSave Text="Save" />
@code {
    void OnSave()
    {
        // Implementation
    }
}
```
## Button types
Property365Button can also submit or reset forms. Use the `ButtonType` property for that.
# [Submit Button](#tab/submit)
```
<Property365Button ButtonType="ButtonType.Submit" />
```
# [Reset Button](#tab/reset)
```
<Property365Button ButtonType="ButtonType.Reset" />
```
***
## Appearance
By default Property365Button renders as a regular button with text. You can change the appearance in various ways.
### Icons and images
You can specify an icon or a custom image which Property365Button will display before the text.
#### [Icon](#tab/icon)
```
<Property365Button Icon="account_circle" />
```
#### [Image](#tab/image)
```
<Property365Button Image="images/save.png" />
```
***
### Custom content
Property365Button can also have entirely custom child content.
```
<Property365Button>
    Some text
    <Property365Image Path="images/Property365-nuget.png" Style="width:20px;margin-left: 10px;" />
</Property365Button>
```
### Styles
Property365Button comes with a predefined set of styles (background and text colors):
#### [Primary](#tab/primary)
```
<Property365Button ButtonStyle="ButtonStyle.Primary" />
```
#### [Secondary](#tab/secondary)
```
<Property365Button ButtonStyle="ButtonStyle.Secondary" />
```
#### [Light](#tab/light)
```
<Property365Button ButtonStyle="ButtonStyle.Light" />
```
#### [Success](#tab/success)
```
<Property365Button ButtonStyle="ButtonStyle.Success" />
```
#### [Danger](#tab/danger)
```
<Property365Button ButtonStyle="ButtonStyle.Danger" />
```
#### [Warning](#tab/warning)
```
<Property365Button ButtonStyle="ButtonStyle.Warning" />
```
#### [Info](#tab/info)
```
<Property365Button ButtonStyle="ButtonStyle.Info" />
```
***
## Busy indicator
A common usage scanrio is to display busy (or loading) icon to show that a task is running. Property365Button supports it out of the box
via the `IsBusy` property. Setting it to `true` displays the loading icon.
```
<Property365Button IsBusy=@busy Click=@OnBusyClick Text="Save" />
@code {
    bool busy;

    async Task OnBusyClick()
    {
        busy = true;
        // Use await and Task.Delay to yield execution to Blazor and refresh the UI
        await Task.Delay(2000);
        // Set the busy flag to false after the long task is done
        busy = false;
    }
}
```