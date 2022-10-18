using Microsoft.AspNetCore.Components;

namespace Property365.Web.Components
{
    /// <summary>
    /// Property365Label component.
    /// </summary>
    /// <example>
    /// <code>
    /// &lt;Property365Label Text="CompanyName" Component="CompanyName" /&gt;
    /// &lt;Property365TextBox Name="CompanyName" /&gt;
    /// </code>
    /// </example>
    public partial class Property365Label : Property365Component
    {
        /// <summary>
        /// Gets or sets the component name for the label.
        /// </summary>
        /// <value>The component name for the label.</value>
        [Parameter]
        public string Component { get; set; }

        /// <summary>
        /// Gets or sets the text.
        /// </summary>
        /// <value>The text.</value>
        [Parameter]
        public string Text { get; set; } = "";

        /// <inheritdoc />
        protected override string GetComponentCssClass()
        {
            return "rz-label";
        }
    }
}
