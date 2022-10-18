using Microsoft.AspNetCore.Components;

namespace Property365.Web.Components
{
    /// <summary>
    /// Property365Link component.
    /// </summary>
    /// <example>
    /// <code>
    /// &lt;Property365Link Path="https://www.property365.io" Text="Go to url" Target="_blank" /&gt;
    /// </code>
    /// </example>
    public partial class Property365Link : Property365Component
    {
        /// <inheritdoc />
        protected override string GetComponentCssClass()
        {
            return "align-middle";
        }

        /// <summary>
        /// Gets or sets the target.
        /// </summary>
        /// <value>The target.</value>
        [Parameter]
        public string Target { get; set; }

        /// <summary>
        /// Gets or sets the icon.
        /// </summary>
        /// <value>The icon.</value>
        [Parameter]
        public string Icon { get; set; }

        /// <summary>
        /// Gets or sets the text.
        /// </summary>
        /// <value>The text.</value>
        [Parameter]
        public string Text { get; set; } = "";

        /// <summary>
        /// Gets or sets the path.
        /// </summary>
        /// <value>The path.</value>
        [Parameter]
        public string Path { get; set; } = "";
    }
}
