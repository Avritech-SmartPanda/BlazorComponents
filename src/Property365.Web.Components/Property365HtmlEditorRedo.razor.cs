using Microsoft.AspNetCore.Components;

namespace Property365.Web.Components
{
    /// <summary>
    /// A Property365HtmlEditor tool which repeats the last undone command.
    /// </summary>
    /// <example>
    /// <code>
    /// &lt;Property365HtmlEditor @bind-Value=@html&gt;
    ///  &lt;Property365HtmlEditorRedo /&gt;
    /// &lt;/Property365HtmlEdito&gt;
    /// @code {
    ///   string html = "@lt;strong&gt;Hello&lt;/strong&gt; world!"; 
    /// }
    /// </code>
    /// </example>
    public partial class Property365HtmlEditorRedo : Property365HtmlEditorButtonBase
    {
        /// <inheritdoc />
        protected override string CommandName => "redo";

        /// <summary>
        /// Specifies the title (tooltip) displayed when the user hovers the tool. Set to <c>"Redo"</c> by default.
        /// </summary>
        [Parameter]
        public string Title { get; set; } = "Redo";
    }
}
