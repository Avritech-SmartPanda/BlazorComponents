# Badge component
This article demonstrates how to use the Badge component. 

## Badge Style
```
<Property365Badge BadgeStyle="BadgeStyle.Primary" Text="Primary" />
<Property365Badge BadgeStyle="BadgeStyle.Secondary" Text="Secondary" />
<Property365Badge BadgeStyle="BadgeStyle.Light" Text="Light" />
<Property365Badge BadgeStyle="BadgeStyle.Success" Text="Success" />
<Property365Badge BadgeStyle="BadgeStyle.Danger" Text="Danger" />
<Property365Badge BadgeStyle="BadgeStyle.Warning" Text="Warning" />
<Property365Badge BadgeStyle="BadgeStyle.Info" Text="Info" />
```

## Pills
```
<Property365Badge BadgeStyle="BadgeStyle.Primary" IsPill="true" Text="Primary" />
<Property365Badge BadgeStyle="BadgeStyle.Secondary" IsPill="true" Text="Secondary" />
<Property365Badge BadgeStyle="BadgeStyle.Light" IsPill="true" Text="Light" />
<Property365Badge BadgeStyle="BadgeStyle.Success" IsPill="true" Text="Success" />
<Property365Badge BadgeStyle="BadgeStyle.Danger" IsPill="true" Text="Danger" />
<Property365Badge BadgeStyle="BadgeStyle.Warning" IsPill="true" Text="Warning" />
<Property365Badge BadgeStyle="BadgeStyle.Info" IsPill="true" Text="Info" />
```

## In Button
```
<Property365Button ButtonStyle="ButtonStyle.Info">
    Button
    <Property365Badge BadgeStyle="BadgeStyle.Primary" Text="15" />
</Property365Button>

<Property365Button ButtonStyle="ButtonStyle.Light">
    Button
    <Property365Badge BadgeStyle="BadgeStyle.Primary" IsPill="@true" Text="15" />
</Property365Button>
```

## Define custom content
```
<Property365Badge BadgeStyle="BadgeStyle.Primary">
    Childcontent
</Property365Badge>
```