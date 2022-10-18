using Microsoft.AspNetCore.Components;

namespace Property365.Web.Components
{
    /// <summary>
    /// Adds a custom font to a <see cref="Property365HtmlEditorFontName" />.
    /// </summary>
    /// <example>
    /// <code>
    ///  &lt;Property365HtmlEditorFontName&gt;
    ///  &lt;Property365HtmlEditorFontNameItem Text="Times New Roman" Value='"Times New Roman"' /&gt;
    ///  &lt;/Property365HtmlEditorFontName&gt;
    /// </code>
    /// </example>
    public partial class Property365HtmlEditorFontNameItem
    {
        /// <summary>
        /// The name of the font e.g. <c>"Times New Roman"</c>.
        /// </summary>
        [Parameter]
        public string Text { get; set; }

        /// <summary>
        /// The CSS value of the font. Use quotes if it contains spaces.
        /// </summary>
        [Parameter]
        public string Value { get; set; }

        /// <summary>
        /// The Property365HtmlEditorFontName tool which this tool belongs to.
        /// </summary>
        [CascadingParameter]
        public Property365HtmlEditorFontName Parent { get; set; }

        /// <inheritdoc />
        protected override void OnInitialized()
        {
            Parent.AddFont(this);
        }
    }
}
