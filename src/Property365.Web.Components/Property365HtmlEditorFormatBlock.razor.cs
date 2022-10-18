using Microsoft.AspNetCore.Components;

namespace Property365.Web.Components
{
    /// <summary>
    /// A tool which changes the style of a the selected text by making it a heading or paragraph.
    /// </summary>
    /// <example>
    /// <code>
    /// &lt;Property365HtmlEditor @bind-Value=@html&gt;
    ///  &lt;Property365HtmlEditorFormatBlock /&gt;
    /// &lt;/Property365HtmlEdito&gt;
    /// @code {
    ///   string html = "@lt;strong&gt;Hello&lt;/strong&gt; world!"; 
    /// }
    /// </code>
    /// </example>
    public partial class Property365HtmlEditorFormatBlock
    {
        /// <summary>
        /// The Property365HtmlEditor component which this tool is part of.
        /// </summary>
        [CascadingParameter]
        public Property365HtmlEditor Editor { get; set; }

        /// <summary>
        /// Specifies the placeholder displayed to the user. Set to <c>"Format block"</c> by default.
        /// </summary>
        [Parameter]
        public string Placeholder { get; set; } = "Format block";

        /// <summary>
        /// Specifies the title (tooltip) displayed when the user hovers the tool. Set to <c>"Text style"</c> by default.
        /// </summary>
        [Parameter]
        public string Title { get; set; } = "Text style";

        async Task OnChange(string value)
        {
            await Editor.ExecuteCommandAsync("formatBlock", value);
        }
    }

}
