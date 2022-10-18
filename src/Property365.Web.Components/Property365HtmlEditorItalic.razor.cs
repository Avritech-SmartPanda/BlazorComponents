using Microsoft.AspNetCore.Components;

namespace Property365.Web.Components
{
    /// <summary>
    /// A Property365HtmlEditor tool which makes the selection italic.
    /// </summary>
    /// <example>
    /// <code>
    /// &lt;Property365HtmlEditor @bind-Value=@html&gt;
    ///  &lt;Property365HtmlEditorItalic /&gt;
    /// &lt;/Property365HtmlEdito&gt;
    /// @code {
    ///   string html = "@lt;strong&gt;Hello&lt;/strong&gt; world!"; 
    /// }
    /// </code>
    /// </example>
    public partial class Property365HtmlEditorItalic : Property365HtmlEditorButtonBase
    {
        /// <inheritdoc />
        protected override string CommandName => "italic";

        /// <summary>
        /// Specifies the title (tooltip) displayed when the user hovers the tool. Set to <c>"Italic"</c> by default.
        /// </summary>
        [Parameter]
        public string Title { get; set; } = "Italic";
    }
}