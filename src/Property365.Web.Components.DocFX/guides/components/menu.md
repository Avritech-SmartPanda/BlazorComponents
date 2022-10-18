# Menu component
This article demonstrates how to use the Menu component. 

```
<Property365Menu>
    <Property365MenuItem Text="General" Icon="home">
        <Property365MenuItem Text="Buttons" Path="buttons" Icon="account_circle"></Property365MenuItem>
        <Property365MenuItem Text="Menu" Path="menu" Icon="line_weight"></Property365MenuItem>
        <Property365MenuItem Text="FileInput" Path="fileinput" Icon="attach_file"></Property365MenuItem>
        <Property365MenuItem Text="Dialog" Path="dialog" Icon="perm_media"></Property365MenuItem>
        <Property365MenuItem Text="Notification" Path="notification" Icon="announcement"></Property365MenuItem>
    </Property365MenuItem>
    <Property365MenuItem Text="Inputs" Icon="payment">
        <Property365MenuItem Text="CheckBox" Path="checkbox" Icon="check_circle"></Property365MenuItem>
        <Property365MenuItem Text="TextBox" Path="textbox" Icon="input"></Property365MenuItem>
        <Property365MenuItem Text="TextArea" Path="textarea" Icon="description"></Property365MenuItem>
        <Property365MenuItem Text="Password" Path="password" Icon="payment"></Property365MenuItem>
        <Property365MenuItem Text="Numeric" Path="numeric" Icon="aspect_ratio"></Property365MenuItem>
        <Property365MenuItem Text="DatePicker" Path="datepicker" Icon="date_range"></Property365MenuItem>
    </Property365MenuItem>
    <Property365MenuItem Text="Data" Icon="save">
        <Property365MenuItem Text="DataGrid" Path="datagrid" Icon="grid_on"></Property365MenuItem>
        <Property365MenuItem Text="DataList" Path="datalist" Icon="list"></Property365MenuItem>
        <Property365MenuItem Text="DropDown" Path="dropdown" Icon="dns"></Property365MenuItem>
        <Property365MenuItem Text="DropDownDataGrid" Path="dropdown-datagrid" Icon="receipt"></Property365MenuItem>
        <Property365MenuItem Text="ListBox" Path="listbox" Icon="view_list"></Property365MenuItem>
        <Property365MenuItem Text="TemplateForm" Path="templateform" Icon="line_style"></Property365MenuItem>
    </Property365MenuItem>
    <Property365MenuItem Text="Containers" Icon="account_box">
        <Property365MenuItem Text="Tabs" Path="tabs" Icon="tab"></Property365MenuItem>
        <Property365MenuItem Text="Panel" Path="panel" Icon="content_paste"></Property365MenuItem>
        <Property365MenuItem Text="Fieldset" Path="fieldset" Icon="account_balance_wallet"></Property365MenuItem>
        <Property365MenuItem Text="Card" Path="card" Icon="line_style"></Property365MenuItem>
    </Property365MenuItem>
    <Property365MenuItem Text="More">
        <Property365MenuItem Text="Item1"></Property365MenuItem>
        <Property365MenuItem Text="Item2"></Property365MenuItem>
        <Property365MenuItem Text="More items">
            <Property365MenuItem Text="More sub items">
                <Property365MenuItem Text="Item1"></Property365MenuItem>
                <Property365MenuItem Text="Item2"></Property365MenuItem>
            </Property365MenuItem>
        </Property365MenuItem>
    </Property365MenuItem>
</Property365Menu>
```