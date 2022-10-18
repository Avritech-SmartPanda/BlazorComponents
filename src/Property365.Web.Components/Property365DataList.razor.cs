using Microsoft.AspNetCore.Components;

namespace Property365.Web.Components
{
    /// <summary>
    /// Property365DataList component.
    /// </summary>
    /// <typeparam name="TItem">The type of the item.</typeparam>
    /// <example>
    /// <code>
    /// &lt;Property365DataList @data=@orders TItem="Order" AllowPaging="true" WrapItems="true"&gt;
    ///     &lt;Template&gt;
    ///         @context.OrderId
    ///     &lt;/Template&gt;
    /// &lt;/Property365DataList&gt;
    /// </code>
    /// </example>
    public partial class Property365DataList<TItem> : PagedDataBoundComponent<TItem>
    {
        /// <inheritdoc />
        protected override string GetComponentCssClass()
        {
            return "rz-datalist-content";
        }

        /// <summary>
        /// Gets or sets a value indicating whether to wrap items.
        /// </summary>
        /// <value><c>true</c> if wrap items; otherwise, <c>false</c>.</value>
        [Parameter]
        public bool WrapItems { get; set; }
    }
}
