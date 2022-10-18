using Microsoft.AspNetCore.Components;

namespace Property365.Web.Components
{
    /// <summary>
    /// Property365Icon component. Displays icon from Material Icons font.
    /// </summary>
    /// <example>
    /// <code>
    /// &lt;Property365Icon Icon="3d_rotation" /&gt;
    /// </code>
    /// </example>
    public partial class Property365Icon : Property365Component
    {
        /// <summary>
        /// Gets or sets the icon.
        /// </summary>
        /// <value>The icon.</value>
        [Parameter]
        public string Icon { get; set; }

        /// <summary>
        /// Specifies the display style of the icon.
        /// </summary>
        [Parameter]
        public IconStyle? IconStyle { get; set; }

        /// <inheritdoc />
        protected override string GetComponentCssClass()
        {
            return $"rzi {(IconStyle.HasValue ? $"rzi-{IconStyle.Value.ToString().ToLowerInvariant()} " : "")}d-inline-flex justify-content-center align-items-center";
        }
    }
}
