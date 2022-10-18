using Microsoft.AspNetCore.Components;
using Property365.Web.Components.Rendering;

namespace Property365.Web.Components
{
    /// <summary>
    /// Property365Header component.
    /// </summary>
    public partial class Property365Header : Property365ComponentWithChildren
    {
        /// <summary>
        /// The <see cref="Property365Layout" /> this component is nested in.
        /// </summary>
        [CascadingParameter]
        public Property365Layout Layout { get; set; }

        /// <inheritdoc />
        protected override string GetComponentCssClass()
        {
            return ClassList.Create("header")
                            .Add("rz-header")
                            .Add("fixed", Layout == null)
                            .ToString();
        }
    }
}
