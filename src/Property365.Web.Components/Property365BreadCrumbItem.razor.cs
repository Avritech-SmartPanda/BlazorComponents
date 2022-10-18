using Microsoft.AspNetCore.Components;

namespace Property365.Web.Components
{
    /// <summary>
    /// Bread Crumb Item Component
    /// </summary>
    public partial class Property365BreadCrumbItem : Property365Component
    {
        /// <summary>
        /// Cascaded TEmplate Parameter from <see cref="Property365BreadCrumb"/> Component
        /// </summary>
        [CascadingParameter]
        public RenderFragment<Property365BreadCrumbItem> Template { get; set; }

        /// <summary>
        /// The Displayed Text
        /// </summary>
        [Parameter]
        public string Text { get; set; }

        /// <summary>
        /// An optional Link to be rendendered
        /// </summary>
        [Parameter]
        public string Path { get; set; }

        /// <summary>
        /// An optional Icon to be rendered
        /// </summary>
        [Parameter]
        public string Icon { get; set; }

        /// <inheritdoc/>
        protected override string GetComponentCssClass()
        {
            return "rz-breadcrumb-item";
        }
    }
}
