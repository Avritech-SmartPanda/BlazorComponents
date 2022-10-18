using Microsoft.AspNetCore.Components;

namespace Property365.Web.Components
{
    /// <summary>
    /// A Property365HtmlEditor tool which removes a link.
    /// </summary>
    /// <example>
    /// <code>
    /// &lt;Property365HtmlEditor @bind-Value=@html&gt;
    ///  &lt;Property365HtmlEditorUnlink /&gt;
    /// &lt;/Property365HtmlEdito&gt;
    /// @code {
    ///   string html = "@lt;strong&gt;Hello&lt;/strong&gt; world!"; 
    /// }
    /// </code>
    /// </example>
    public partial class Property365HtmlEditorUnlink : Property365HtmlEditorButtonBase
    {
        /// <inheritdoc />
        protected override string CommandName => "unlink";


        /// <summary>
        /// Specifies the title (tooltip) displayed when the user hovers the tool. Set to <c>"Remove link"</c> by default.
        /// </summary>
        [Parameter]
        public string Title { get; set; } = "Remove link";
    }
}