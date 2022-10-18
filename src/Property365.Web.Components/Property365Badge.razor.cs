using Microsoft.AspNetCore.Components;

namespace Property365.Web.Components
{
    /// <summary>
    /// Property365Badge component.
    /// </summary>
    /// <example>
    /// <code>
    /// &lt;Property365Badge BadgeStyle="BadgeStyle.Primary" Text="Primary" /&gt;
    /// </code>
    /// </example>
    public partial class Property365Badge : Property365Component
    {

        private string getApprearance()
        {
            return $"text-white inline-block px-1 tracking-wide text-center text-xs font-semibold uppercase bg-{Color}-500 {(IsPill ? " rounded-full" : "rounded")}";


        }


        /// <inheritdoc />
        protected override string GetComponentCssClass()
        {
            

            return $"text-white inline-block px-1.5 tracking-wide text-center text-xs font-semibold uppercase bg-{Color}-500 {(IsPill ? " rounded-full" : "rounded")}";
        }

        /// <summary>
        /// Gets or sets the child content.
        /// </summary>
        /// <value>The child content.</value>
        [Parameter]
        public RenderFragment ChildContent { get; set; }

        /// <summary>
        /// Gets or sets the text.
        /// </summary>
        /// <value>The text.</value>
        [Parameter]
        public string Text { get; set; }

        [Parameter]
        public string Color { get; set; } = "blue";
        /// <summary>
        /// Gets or sets the badge style.
        /// </summary>
        /// <value>The badge style.</value>
        [Parameter]
        public BadgeStyle BadgeStyle { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this instance is pill.
        /// </summary>
        /// <value><c>true</c> if this instance is pill; otherwise, <c>false</c>.</value>
        [Parameter]
        public bool IsPill { get; set; }
    }
}
