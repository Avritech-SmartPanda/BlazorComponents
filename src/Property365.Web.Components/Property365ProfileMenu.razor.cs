using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;

namespace Property365.Web.Components
{
    /// <summary>
    /// Property365ProfileMenu component.
    /// </summary>
    /// <example>
    /// <code>
    /// &lt;Property365ProfileMenu&gt;
    ///     &lt;Property365ProfileMenuItem Text="Data"&gt;
    ///         &lt;Property365ProfileMenuItem Text="Orders" Path="orders" /&gt;
    ///         &lt;Property365ProfileMenuItem Text="Employees" Path="employees" /&gt;
    ///     &lt;/Property365ProfileMenuItemItem&gt;
    /// &lt;/Property365ProfileMenu&gt;
    /// </code>
    /// </example>
    public partial class Property365ProfileMenu : Property365ComponentWithChildren
    {
        /// <inheritdoc />
        protected override string GetComponentCssClass()
        {
            return "cursor-pointer mb-0 relative z-3 inline-block list-none py-2.5 px-4";
        }

        /// <summary>
        /// Gets or sets the template.
        /// </summary>
        /// <value>The template.</value>
        [Parameter]
        public RenderFragment Template { get; set; }

        /// <summary>
        /// Gets or sets the click callback.
        /// </summary>
        /// <value>The click callback.</value>
        [Parameter]
        public EventCallback<Property365ProfileMenuItem> Click { get; set; }

        string contentStyle = "display:none;position:absolute;z-index:1;right:24px;";
        string iconStyle = "transform: rotate(0deg);";

        /// <summary>
        /// Toggles the menu open/close state.
        /// </summary>
        /// <param name="args">The <see cref="MouseEventArgs"/> instance containing the event data.</param>
        public void Toggle(MouseEventArgs args)
        {
            contentStyle = contentStyle.IndexOf("display:none;") != -1 ? "display:block;" : "display:none;position:absolute;z-index:1;";
            iconStyle = iconStyle.IndexOf("rotate(0deg)") != -1 ? "transform: rotate(-180deg);" : "transform: rotate(0deg);";
            StateHasChanged();
        }

        /// <summary>
        /// Closes this instance.
        /// </summary>
        public void Close()
        {
            contentStyle = "display:none;";
            iconStyle = "transform: rotate(0deg);";
            StateHasChanged();
        }
    }
}
