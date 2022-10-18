using Microsoft.AspNetCore.Components;

namespace Property365.Web.Components
{
    /// <summary>
    /// A Property365HtmlEditor tool which applies "strike through" styling to the selection.
    /// </summary>
    /// <example>
    /// <code>
    /// &lt;Property365HtmlEditor @bind-Value=@html&gt;
    ///  &lt;Property365HtmlEditorStrikeThrough /&gt;
    /// &lt;/Property365HtmlEdito&gt;
    /// @code {
    ///   string html = "@lt;strong&gt;Hello&lt;/strong&gt; world!"; 
    /// }
    /// </code>
    /// </example>
    public partial class Property365HtmlEditorStrikeThrough : Property365HtmlEditorButtonBase
    {
        /// <inheritdoc />
        protected override string CommandName => "strikeThrough";

        /// <summary>
        /// Specifies the title (tooltip) displayed when the user hovers the tool. Set to <c>"Strikethrough"</c> by default.
        /// </summary>
        [Parameter]
        public string Title { get; set; } = "Strikethrough";
    }
}
