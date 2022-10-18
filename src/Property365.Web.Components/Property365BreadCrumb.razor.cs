using Microsoft.AspNetCore.Components;

namespace Property365.Web.Components
{
    /// <summary>
    /// A component to display a Bread Crumb style menu
    /// </summary>
    public partial class Property365BreadCrumb : Property365ComponentWithChildren
    {

        private string getFont()
        {
            return $"tex-2xl";
        }

        /// <summary>
        /// An optional RenderFragment that is rendered per Item
        /// </summary>
        [Parameter]
        public RenderFragment<Property365BreadCrumbItem> Template { get; set; }

        /// <inheritdoc/>
        protected override string GetComponentCssClass()
        {
            return $"rz-breadcrumb {getFont()}";
        }
    }

}
