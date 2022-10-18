using Microsoft.AspNetCore.Components;

namespace Property365.Web.Components
{
    /// <summary>
    /// A custom tool in Property365HtmlEditor
    /// </summary>
    /// <example>
    /// <code>
    /// &lt;Property365HtmlEditor Execute=@OnExecute&gt;
    ///   &lt;Property365HtmlEditorCustomTool CommandName="InsertToday" Icon="today" Title="Insert today" /&gt;
    /// &lt;/Property365HtmlEditor&gt;
    /// @code {
    ///   string html = "@lt;strong&gt;Hello&lt;/strong&gt; world!"; 
    ///   async Task OnExecute(HtmlEditorExecuteEventArgs args)
    ///   {
    ///     if (args.CommandName == "InsertToday")
    ///     {
    ///       await args.Editor.ExecuteCommandAsync(HtmlEditorCommands.InsertHtml, DateTime.Today.ToLongDateString());
    ///     }
    ///  }
    /// </code>
    /// </example>
    public partial class Property365HtmlEditorCustomTool
    {
        /// <summary>
        /// Determines if the tools is visible.
        /// </summary>
        [Parameter]
        public bool Visible { get; set; } = true;

        /// <summary>
        /// Specifies the icon of the tool. Set to <c>"settings"</c> by default.
        /// </summary>
        [Parameter]
        public string Icon { get; set; } = "settings";

        /// <summary>
        /// The template of the tool. Use to render a custom tool.
        /// </summary>
        [Parameter]
        public RenderFragment<Property365HtmlEditor> Template { get; set; }

        /// <summary>
        /// Specifies whether the tool is selected.
        /// </summary>
        [Parameter]
        public bool Selected { get; set; }

        /// <summary>
        /// Specifies whether the tool is disabled.
        /// </summary>
        [Parameter]
        public bool Disabled { get; set; }

        /// Specifies the name of the command. It is available as <see cref="HtmlEditorExecuteEventArgs.CommandName" /> when
        /// <see cref="Property365HtmlEditor.Execute" /> is raised.
        [Parameter]
        public string CommandName { get; set; }

        /// <summary>
        /// The Property365HtmlEditor component which this tool is part of.
        /// </summary>
        [CascadingParameter]
        public Property365HtmlEditor Editor { get; set; }

        /// <summary>
        /// Specifies the title (tooltip) displayed when the user hovers the tool.
        /// </summary>
        [Parameter]
        public string Title { get; set; }

        async Task OnClick()
        {
            await Editor.OnExecuteAsync(CommandName);
        }
    }
}
