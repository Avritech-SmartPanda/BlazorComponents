namespace Property365.Web.Components
{
    /// <summary>
    /// Property365Card component.
    /// </summary>
    public partial class Property365Card : Property365ComponentWithChildren
    {
        /// <inheritdoc />
        protected override string GetComponentCssClass()
        {
            return "flex relative overflow-hidden rounded-2xl shadow-sm bg-card flex-col max-w-sm md:max-w-none p-4 sm:py-12 sm:px-10";
        }
    }
}
