using Microsoft.AspNetCore.Components;

namespace Property365.Web.Components
{
    /// <summary>
    /// Adds a custom color to <see cref="Property365HtmlEditorBackground" />.
    /// </summary>
    /// <example>
    /// <code>
    ///  &lt;Property365HtmlEditorBackground &gt;
    ///     &lt;Property365HtmlEditorBackgroundItem Value="red" /&gt;
    ///     &lt;Property365HtmlEditorBackgroundItem Value="green" /&gt;
    ///  &lt;/Property365HtmlEditorBackground &gt;
    /// </code>
    /// </example>
    public partial class Property365HtmlEditorBackgroundItem
    {
        /// <summary>
        /// The custom color to add.
        /// </summary>
        [Parameter]
        public string Value { get; set; }
    }
}
