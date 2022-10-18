# ContextMenu component
This article demonstrates how to use the ContextMenu component. Use `ContextMenuService` to open and close context menus.

## Show ContextMenu with items

```
@inject ContextMenuService ContextMenuService

<Property365Button Text="Show context menu" ContextMenu=@(args => ShowContextMenuWithItems(args)) />

@code {
    void ShowContextMenuWithItems(MouseEventArgs args)
    {
        ContextMenuService.Open(args,
            new List<ContextMenuItem> {
                new ContextMenuItem(){ Text = "Context menu item 1", Value = 1 },
                new ContextMenuItem(){ Text = "Context menu item 2", Value = 2 },
                new ContextMenuItem(){ Text = "Context menu item 3", Value = 3 },
         }, OnMenuItemClick);
    }

    void OnMenuItemClick(MenuItemEventArgs args)
    {
        Console.WriteLine($"Menu item with Value={args.Value} clicked");
    }
}
```

## Show ContextMenu with custom content

```
@inject ContextMenuService ContextMenuService

<Property365Button Text="Show context menu" ContextMenu=@(args => ShowContextMenuWithContent(args)) />

@code {
    void ShowContextMenuWithContent(MouseEventArgs args) => ContextMenuService.Open(args, ds =>
        @<Property365Menu Click="OnMenuItemClick">
            <Property365MenuItem Text="Item1" Value="1"></Property365MenuItem>
            <Property365MenuItem Text="Item2" Value="2"></Property365MenuItem>
            <Property365MenuItem Text="More items" Value="3">
                <Property365MenuItem Text="More sub items" Value="4">
                    <Property365MenuItem Text="Item1" Value="5"></Property365MenuItem>
                    <Property365MenuItem Text="Item2" Value="6"></Property365MenuItem>
                </Property365MenuItem>
            </Property365MenuItem>
        </Property365Menu>);

    void OnMenuItemClick(MenuItemEventArgs args)
    {
        Console.WriteLine($"Menu item with Value={args.Value} clicked");
    }
}
```

## Show ContextMenu for HTML element

```
@inject ContextMenuService ContextMenuService

<button @oncontextmenu=@(args => ShowContextMenuWithContent(args)) @oncontextmenu:preventDefault="true">
  Show context menu
</button>

@code {
    void ShowContextMenuWithContent(MouseEventArgs args) => ContextMenuService.Open(args, ds =>
        @<Property365Menu Click="OnMenuItemClick">
            <Property365MenuItem Text="Item1" Value="1"></Property365MenuItem>
            <Property365MenuItem Text="Item2" Value="2"></Property365MenuItem>
            <Property365MenuItem Text="More items" Value="3">
                <Property365MenuItem Text="More sub items" Value="4">
                    <Property365MenuItem Text="Item1" Value="5"></Property365MenuItem>
                    <Property365MenuItem Text="Item2" Value="6"></Property365MenuItem>
                </Property365MenuItem>
            </Property365MenuItem>
        </Property365Menu>);

    void OnMenuItemClick(MenuItemEventArgs args)
    {
        Console.WriteLine($"Menu item with Value={args.Value} clicked");
    }
}
```