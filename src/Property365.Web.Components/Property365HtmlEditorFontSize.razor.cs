using Microsoft.AspNetCore.Components;

namespace Property365.Web.Components
{
    /// <summary>
    /// A tool which changes the font size of the selected text.
    /// </summary>
    /// <example>
    /// <code>
    /// &lt;Property365HtmlEditor @bind-Value=@html&gt;
    ///  &lt;Property365HtmlEditorFontSize /&gt;
    /// &lt;/Property365HtmlEdito&gt;
    /// @code {
    ///   string html = "@lt;strong&gt;Hello&lt;/strong&gt; world!"; 
    /// }
    /// </code>
    /// </example>
    public partial class Property365HtmlEditorFontSize
    {
        /// <summary>
        /// The Property365HtmlEditor component which this tool is part of.
        /// </summary>
        [CascadingParameter]
        public Property365HtmlEditor Editor { get; set; }

        /// <summary>
        /// Specifies the placeholder displayed to the user. Set to <c>"Font size"</c> by default.
        /// </summary>
        [Parameter]
        public string Placeholder { get; set; } = "Font size";

        /// <summary>
        /// Specifies the title (tooltip) displayed when the user hovers the tool. Set to <c>"Font size"</c> by default.
        /// </summary>
        [Parameter]
        public string Title { get; set; } = "Font size";

        async Task OnChange(string value)
        {
            await Editor.ExecuteCommandAsync("fontSize", value);
        }

    }
}
