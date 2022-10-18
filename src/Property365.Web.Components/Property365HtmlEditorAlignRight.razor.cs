using Microsoft.AspNetCore.Components;

namespace Property365.Web.Components
{
    /// <summary>
    /// A Property365HtmlEditor tool which aligns the selection to the right.
    /// </summary>
    /// <example>
    /// <code>
    /// &lt;Property365HtmlEditor @bind-Value=@html&gt;
    ///  &lt;Property365HtmlEditorAlignRight /&gt;
    /// &lt;/Property365HtmlEdito&gt;
    /// @code {
    ///   string html = "@lt;strong&gt;Hello&lt;/strong&gt; world!"; 
    /// }
    /// </code>
    /// </example>
    public partial class Property365HtmlEditorAlignRight : Property365HtmlEditorButtonBase
    {
        /// <inheritdoc />
        protected override string CommandName => "justifyRight";

        /// <summary>
        /// Specifies the title (tooltip) displayed when the user hovers the tool. Set to <c>"Align right"</c> by default.
        /// </summary>
        [Parameter]
        public string Title { get; set; } = "Align right";
    }
}
