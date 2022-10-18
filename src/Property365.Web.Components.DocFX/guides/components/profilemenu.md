# ProfileMenu component
This article demonstrates how to use the ProfileMenu component. 

```
<Property365ProfileMenu>
    <Template>
        <Property365Gravatar Email="user@example.com">
        </Property365Gravatar>
    </Template>
    <ChildContent>
        <Property365ProfileMenuItem Text="Buttons" Path="buttons" Icon="account_circle"></Property365ProfileMenuItem>
        <Property365ProfileMenuItem Text="Menu" Path="menu" Icon="line_weight"></Property365ProfileMenuItem>
        <Property365ProfileMenuItem Text="FileInput" Path="fileinput" Icon="attach_file"></Property365ProfileMenuItem>
        <Property365ProfileMenuItem Text="Dialog" Path="dialog" Icon="perm_media"></Property365ProfileMenuItem>
        <Property365ProfileMenuItem Text="Notification" Path="notification" Icon="announcement"></Property365ProfileMenuItem>
    </ChildContent>
</Property365ProfileMenu>
```