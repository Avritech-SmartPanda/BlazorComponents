using Microsoft.AspNetCore.Components;

namespace Property365.Web.Components
{
    /// <summary>
    /// A Property365HtmlEditor tool which sets the text color of the selection.
    /// </summary>
    /// <example>
    /// <code>
    /// &lt;Property365HtmlEditor @bind-Value=@html&gt;
    ///  &lt;Property365HtmlEditorColor /&gt;
    /// &lt;/Property365HtmlEdito&gt;
    /// @code {
    ///   string html = "@lt;strong&gt;Hello&lt;/strong&gt; world!"; 
    /// }
    /// </code>
    /// </example>
    public partial class Property365HtmlEditorColor : Property365HtmlEditorColorBase
    {
        /// <inheritdoc />
        protected override string CommandName => "foreColor";

        /// <summary>
        /// Specifies the default text color. Set to <c>"rgb(255, 0, 0)"</c> by default;
        /// </summary>
        [Parameter]
        public string Value { get; set; } = "rgb(255, 0, 0)";
        /// <summary>
        /// Specifies the title (tooltip) displayed when the user hovers the tool. Set to <c>"Text color"</c> by default.
        /// </summary>
        [Parameter]
        public string Title { get; set; } = "Text color";
    }
}
