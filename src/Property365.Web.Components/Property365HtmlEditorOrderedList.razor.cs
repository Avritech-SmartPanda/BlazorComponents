using Microsoft.AspNetCore.Components;

namespace Property365.Web.Components
{
    /// <summary>
    /// A Property365HtmlEditor tool which inserts an ordered list (<c>ol</c>).
    /// </summary>
    /// <example>
    /// <code>
    /// &lt;Property365HtmlEditor @bind-Value=@html&gt;
    ///  &lt;Property365HtmlEditorOrderedList /&gt;
    /// &lt;/Property365HtmlEdito&gt;
    /// @code {
    ///   string html = "@lt;strong&gt;Hello&lt;/strong&gt; world!"; 
    /// }
    /// </code>
    /// </example>
    public partial class Property365HtmlEditorOrderedList : Property365HtmlEditorButtonBase
    {
        /// <inheritdoc />
        protected override string CommandName => "insertOrderedList";

        /// <summary>
        /// Specifies the title (tooltip) displayed when the user hovers the tool. Set to <c>"Ordered list"</c> by default.
        /// </summary>
        [Parameter]
        public string Title { get; set; } = "Ordered list";
    }
}
