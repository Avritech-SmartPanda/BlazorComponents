using Microsoft.AspNetCore.Components;

namespace Property365.Web.Components
{
    /// <summary>
    /// A tool which changes the font of the selected text.
    /// </summary>
    /// <example>
    /// <code>
    /// &lt;Property365HtmlEditor @bind-Value=@html&gt;
    ///  &lt;Property365HtmlEditorFontName /&gt;
    /// &lt;/Property365HtmlEdito&gt;
    /// @code {
    ///   string html = "@lt;strong&gt;Hello&lt;/strong&gt; world!"; 
    /// }
    /// </code>
    /// </example>
    public partial class Property365HtmlEditorFontName
    {
        IList<Property365HtmlEditorFontNameItem> fonts = new List<Property365HtmlEditorFontNameItem>();

        internal void AddFont(Property365HtmlEditorFontNameItem font)
        {
            if (!fonts.Contains(font))
            {
                fonts.Add(font);
            }
        }

        /// <summary>
        /// Sets the child content.
        /// </summary>
        [Parameter]
        public RenderFragment ChildContent { get; set; }

        /// <summary>
        /// Specifies the placeholder displayed to the user. Set to <c>"Font"</c> by default.
        /// </summary>
        [Parameter]
        public string Placeholder { get; set; } = "Font";

        /// <summary>
        /// Specifies the title (tooltip) displayed when the user hovers the tool. Set to <c>"Font name"</c> by default.
        /// </summary>
        [Parameter]
        public string Title { get; set; } = "Font name";

        /// <summary>
        /// The Property365HtmlEditor component which this tool is part of.
        /// </summary>
        [CascadingParameter]
        public Property365HtmlEditor Editor { get; set; }

        async Task OnChange(string value)
        {
            await Editor.ExecuteCommandAsync("fontName", value);
        }
    }
}
