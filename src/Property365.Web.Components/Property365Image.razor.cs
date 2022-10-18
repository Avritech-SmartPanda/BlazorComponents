using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;

namespace Property365.Web.Components
{
    /// <summary>
    /// Property365Image component.
    /// </summary>
    /// <example>
    /// <code>
    /// &lt;Property365Image Path="someimage.png" /&gt;
    /// </code>
    /// </example>
    public partial class Property365Image : Property365ComponentWithChildren
    {
        /// <summary>
        /// Gets or sets the path.
        /// </summary>
        /// <value>The path.</value>
        [Parameter]
        public string Path { get; set; }

        /// <summary>
        /// Gets or sets the click callback.
        /// </summary>
        /// <value>The click callback.</value>
        [Parameter]
        public EventCallback<MouseEventArgs> Click { get; set; }

        /// <summary>
        /// Handles the <see cref="E:Click" /> event.
        /// </summary>
        /// <param name="args">The <see cref="MouseEventArgs"/> instance containing the event data.</param>
        protected async System.Threading.Tasks.Task OnClick(MouseEventArgs args)
        {
            await Click.InvokeAsync(args);
        }
    }
}
