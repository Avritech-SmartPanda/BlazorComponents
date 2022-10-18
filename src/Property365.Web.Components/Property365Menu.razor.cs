using Microsoft.AspNetCore.Components;

namespace Property365.Web.Components
{
    /// <summary>
    /// Property365Menu component.
    /// </summary>
    /// <example>
    /// <code>
    /// &lt;Property365Menu&gt;
    ///     &lt;Property365MenuItem Text="Data"&gt;
    ///         &lt;Property365MenuItem Text="Orders" Path="orders" /&gt;
    ///         &lt;Property365MenuItem Text="Employees" Path="employees" /&gt;
    ///     &lt;/Property365MenuItemItem&gt;
    /// &lt;/Property365Menu&gt;
    /// </code>
    /// </example>
    public partial class Property365Menu : Property365ComponentWithChildren
    {
        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="Property365Menu"/> is responsive.
        /// </summary>
        /// <value><c>true</c> if responsive; otherwise, <c>false</c>.</value>
        [Parameter]
        public bool Responsive { get; set; } = true;

        private bool IsOpen { get; set; } = false;

        /// <inheritdoc />
        protected override string GetComponentCssClass()
        {
            var classList = new List<string>();

            classList.Add("rz-menu");

            if (Responsive)
            {
                if (IsOpen)
                {
                    classList.Add("rz-menu-open");
                }
                else
                {
                    classList.Add("rz-menu-closed");
                }
            }

            return string.Join(" ", classList);
        }

        void OnToggle()
        {
            IsOpen = !IsOpen;
        }

        /// <summary>
        /// Gets or sets the click callback.
        /// </summary>
        /// <value>The click callback.</value>
        [Parameter]
        public EventCallback<MenuItemEventArgs> Click { get; set; }
    }
}
