# PanelMenu component
This article demonstrates how to use the PanelMenu component. 

```
<Property365PanelMenu Style="width:300px">
    <Property365PanelMenuItem Text="General" Icon="home">
        <Property365PanelMenuItem Text="Buttons" Path="buttons" Icon="account_circle"></Property365PanelMenuItem>
        <Property365PanelMenuItem Text="Menu" Path="menu" Icon="line_weight"></Property365PanelMenuItem>
        <Property365PanelMenuItem Text="FileInput" Path="fileinput" Icon="attach_file"></Property365PanelMenuItem>
        <Property365PanelMenuItem Text="Dialog" Path="dialog" Icon="perm_media"></Property365PanelMenuItem>
        <Property365PanelMenuItem Text="Notification" Path="notification" Icon="announcement"></Property365PanelMenuItem>
    </Property365PanelMenuItem>
    <Property365PanelMenuItem Text="Inputs" Icon="payment">
        <Property365PanelMenuItem Text="CheckBox" Path="checkbox" Icon="check_circle"></Property365PanelMenuItem>
        <Property365PanelMenuItem Text="TextBox" Path="textbox" Icon="input"></Property365PanelMenuItem>
        <Property365PanelMenuItem Text="TextArea" Path="textarea" Icon="description"></Property365PanelMenuItem>
        <Property365PanelMenuItem Text="Password" Path="password" Icon="payment"></Property365PanelMenuItem>
        <Property365PanelMenuItem Text="Numeric" Path="numeric" Icon="aspect_ratio"></Property365PanelMenuItem>
        <Property365PanelMenuItem Text="DatePicker" Path="datepicker" Icon="date_range"></Property365PanelMenuItem>
    </Property365PanelMenuItem>
    <Property365PanelMenuItem Text="Data" Icon="save">
        <Property365PanelMenuItem Text="DataGrid" Path="datagrid" Icon="grid_on"></Property365PanelMenuItem>
        <Property365PanelMenuItem Text="DataList" Path="datalist" Icon="list"></Property365PanelMenuItem>
        <Property365PanelMenuItem Text="DropDown" Path="dropdown" Icon="dns"></Property365PanelMenuItem>
        <Property365PanelMenuItem Text="DropDownDataGrid" Path="dropdown-datagrid" Icon="receipt"></Property365PanelMenuItem>
        <Property365PanelMenuItem Text="ListBox" Path="listbox" Icon="view_list"></Property365PanelMenuItem>
        <Property365PanelMenuItem Text="TemplateForm" Path="templateform" Icon="line_style"></Property365PanelMenuItem>
    </Property365PanelMenuItem>
    <Property365PanelMenuItem Text="Containers" Icon="account_box">
        <Property365PanelMenuItem Text="Tabs" Path="tabs" Icon="tab"></Property365PanelMenuItem>
        <Property365PanelMenuItem Text="Panel" Path="panel" Icon="content_paste"></Property365PanelMenuItem>
        <Property365PanelMenuItem Text="Fieldset" Path="fieldset" Icon="account_balance_wallet"></Property365PanelMenuItem>
        <Property365PanelMenuItem Text="Card" Path="card" Icon="line_style"></Property365PanelMenuItem>
    </Property365PanelMenuItem>
    <Property365PanelMenuItem Text="More">
        <Property365PanelMenuItem Text="Item1"></Property365PanelMenuItem>
        <Property365PanelMenuItem Text="Item2"></Property365PanelMenuItem>
        <Property365PanelMenuItem Text="More items">
            <Property365PanelMenuItem Text="More sub items">
                <Property365PanelMenuItem Text="Item1"></Property365PanelMenuItem>
                <Property365PanelMenuItem Text="Item2"></Property365PanelMenuItem>
            </Property365PanelMenuItem>
        </Property365PanelMenuItem>
    </Property365PanelMenuItem>
</Property365PanelMenu>
```