using Microsoft.AspNetCore.Components;

namespace Property365.Web.Components
{
    /// <summary>
    /// Property365ContentContainer component.
    /// </summary>
    public partial class Property365ContentContainer : Property365ComponentWithChildren
    {
        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>The name.</value>
        [Parameter]
        public string Name { get; set; }
    }
}
