using Microsoft.AspNetCore.Components;

namespace Property365.Web.Components
{
    /// <summary>
    /// A Property365HtmlEditor tool which inserts a bullet list (<c>ul</c>).
    /// </summary>
    /// <example>
    /// <code>
    /// &lt;Property365HtmlEditor @bind-Value=@html&gt;
    ///  &lt;Property365HtmlEditorUnorderedList /&gt;
    /// &lt;/Property365HtmlEdito&gt;
    /// @code {
    ///   string html = "@lt;strong&gt;Hello&lt;/strong&gt; world!"; 
    /// }
    /// </code>
    /// </example>
    public partial class Property365HtmlEditorUnorderedList : Property365HtmlEditorButtonBase
    {
        /// <inheritdoc />
        protected override string CommandName => "insertUnorderedList";

        /// <summary>
        /// Specifies the title (tooltip) displayed when the user hovers the tool. Set to <c>"Bullet list"</c> by default.
        /// </summary>
        [Parameter]
        public string Title { get; set; } = "Bullet list";
    }
}
