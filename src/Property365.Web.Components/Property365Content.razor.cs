using Microsoft.AspNetCore.Components;

namespace Property365.Web.Components
{
    /// <summary>
    /// Property365Content component.
    /// </summary>
    public partial class Property365Content : Property365ComponentWithChildren
    {
        /// <summary>
        /// Gets or sets the container.
        /// </summary>
        /// <value>The container.</value>
        [Parameter]
        public string Container { get; set; }

        /// <inheritdoc />
        protected override string GetComponentCssClass()
        {
            return "content";
        }
    }
}
