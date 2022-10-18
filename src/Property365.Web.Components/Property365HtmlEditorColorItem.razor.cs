using Microsoft.AspNetCore.Components;

namespace Property365.Web.Components
{
    /// <summary>
    /// Adds a custom color to <see cref="Property365HtmlEditorColor" />.
    /// </summary>
    /// <example>
    /// <code>
    ///  &lt;Property365HtmlEditorColor &gt;
    ///     &lt;Property365HtmlEditorColorItem Value="red" /&gt;
    ///     &lt;Property365HtmlEditorColorItem Value="green" /&gt;
    ///  &lt;/Property365HtmlEditorColor &gt;
    /// </code>
    /// </example>
    public partial class Property365HtmlEditorColorItem
    {
        /// <summary>
        /// The custom color to add.
        /// </summary>
        [Parameter]
        public string Value { get; set; }
    }
}
