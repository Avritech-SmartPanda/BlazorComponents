using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.JSInterop;

namespace Property365.Web.Components
{
    /// <summary>
    /// Property365SplitButton component.
    /// </summary>
    /// <example>
    /// <code>
    /// &lt;Property365SplitButton Click=@(args => Console.WriteLine($"Value is: {args.Value}"))&gt;
    ///     &lt;ChildContent&gt;
    ///         &lt;Property365SplitButtonItem Text="Orders" Value="1" /&gt;
    ///         &lt;Property365SplitButtonItem Text="Employees" Value="2" /&gt;
    ///         &lt;Property365SplitButtonItem Text="Customers" Value="3" /&gt;
    ///     &lt;/ChildContent&gt;
    /// &lt;/Property365SelectBar&gt;
    /// </code>
    /// </example>
    public partial class Property365SplitButton : Property365ComponentWithChildren
    {

        private string getApprearance()
        {
            return ButtonStyle switch
            {
                ButtonStyle.Primary => $"rounded-r-none rounded-l relative group before:absolute before:inset-0 before:bg-primary-800 before:rounded-l before:border-r-none before:scale-x-0 before:origin-right  before:transition before:duration-300 hover:before:scale-x-100 hover:before:origin-left {(Outline ? "border-primary-900 text-primary-900 border-y border-l hover:text-white" : "bg-primary-900  text-white border-none")}",
                ButtonStyle.Secondary => $"rounded-r-none rounded-l relative group before:absolute before:inset-0 before:bg-secondary-800  before:rounded-l before:border-r-none before:scale-x-0 before:origin-right  before:transition before:duration-300 hover:before:scale-x-100 hover:before:origin-left   {(Outline ? "border-secondary-900 border-y border-l text-secondary-900 hover:text-primary-900" : "bg-secondary-900  text-white border-none")}",
                ButtonStyle.Success => $"rounded-r-none rounded-l relative group before:absolute before:inset-0 before:bg-success-800  before:rounded-l before:border-r-none before:scale-x-0 before:origin-right  before:transition before:duration-300 hover:before:scale-x-100 hover:before:origin-left {(Outline ? "border-success-900  border-y border-l text-success-900 hover:text-white" : "bg-success-900 text-white border-none")}",
                ButtonStyle.Danger => $"rounded-r-none rounded-l relative group before:absolute before:inset-0 before:bg-danger-800  before:rounded-l before:border-r-none before:scale-x-0 before:origin-right  before:transition before:duration-300 hover:before:scale-x-100 hover:before:origin-left {(Outline ? "border-danger-900  border-y border-l text-danger-900 hover:text-white" : "bg-danger-900 text-white border-none")}",
                ButtonStyle.Warning => $"rounded-r-none rounded-l relative group before:absolute before:inset-0 before:bg-warning-800  before:rounded-l before:border-r-none before:scale-x-0 before:origin-right  before:transition before:duration-300 hover:before:scale-x-100 hover:before:origin-left {(Outline ? "border-warning-900  border-y border-l text-warning-900 hover:text-dark-900" : "bg-warning-900 text-dark-900 border-none")}",
                ButtonStyle.Info => $"rounded-r-none rounded-l relative group before:absolute before:inset-0 before:bg-info-800  before:rounded-l before:border-r-none before:scale-x-0 before:origin-right  before:transition before:duration-300 hover:before:scale-x-100 hover:before:origin-left {(Outline ? "border-info-900  border-y border-l text-info-900 hover:text-white" : "bg-info-900 text-white border-none")}",
                ButtonStyle.Light => $"rounded-r-none rounded-l relative group before:absolute before:inset-0 before:bg-light-800 before:rounded-l before:border-r-none  before:scale-x-0 before:origin-right  before:transition before:duration-300 hover:before:scale-x-100 hover:before:origin-left {(Outline ? "border-light-900  border-y border-l text-light-900 hover:text-dark-900" : "bg-light-900 text-dark-900 border-none")}",
                ButtonStyle.Dark => $"rounded-r-none rounded-l relative group before:absolute before:inset-0 before:bg-dark-800 before:rounded-l before:border-r-none  before:scale-x-0 before:origin-right  before:transition before:duration-300 hover:before:scale-x-100 hover:before:origin-left {(Outline ? "border-dark-900 border-y border-l text-dark-900 hover:text-white" : "bg-dark-900  text-white border-none")}",
                _ => $"rounded-r-none rounded-l bg-primary-900 relative group before:absolute before:inset-0 before:bg-primary-800  before:rounded-l before:border-r-none before:scale-x-0 before:origin-right  before:transition before:duration-300 hover:before:scale-x-100 hover:before:origin-left text-white border-none"

            };
        }

        /// <summary>
        /// Gets or sets the text.
        /// </summary>
        /// <value>The text.</value>
        [Parameter]
        public string Text { get; set; } = "";

        /// <summary>
        /// Gets or sets the icon.
        /// </summary>
        /// <value>The icon.</value>
        [Parameter]
        public string Icon { get; set; }

        /// <summary>
        /// Gets or sets the image.
        /// </summary>
        /// <value>The image.</value>
        [Parameter]
        public string Image { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="Property365SplitButton"/> is disabled.
        /// </summary>
        /// <value><c>true</c> if disabled; otherwise, <c>false</c>.</value>
        [Parameter]
        public bool Disabled { get; set; }

        /// <summary>
        /// Gets or sets the outline of the button.
        /// </summary>
        /// <value>The outline of the button.</value>
        [Parameter]
        public bool Outline { get; set; }

        /// <summary>
        /// Gets or sets the button appearance.
        /// </summary>
        /// <value>The button appearance.</value>
        [Parameter]
        public ButtonAppearance ButtonAppearance { get; set; } = ButtonAppearance.Simple;

        /// <summary>
        /// Gets or sets the button style.
        /// </summary>
        /// <value>The button style.</value>
        [Parameter]
        public ButtonStyle ButtonStyle { get; set; } = ButtonStyle.Primary;

        // [Parameter]
        // public string Color { get; set; } = "light";


        /// <summary>
        /// Gets or sets the click callback.
        /// </summary>
        /// <value>The click callback.</value>
        [Parameter]
        public EventCallback<Property365SplitButtonItem> Click { get; set; }

        /// <summary>
        /// Handles the <see cref="E:Click" /> event.
        /// </summary>
        /// <param name="args">The <see cref="MouseEventArgs"/> instance containing the event data.</param>
        public async System.Threading.Tasks.Task OnClick(MouseEventArgs args)
        {
            if (!Disabled)
            {
                await Click.InvokeAsync(null);
            }
        }

        /// <summary>
        /// Closes this instance popup.
        /// </summary>
        public void Close()
        {
            JSRuntime.InvokeVoidAsync("Property365Components.closePopup", PopupID);
        }

        /// <summary>
        /// Gets the popup identifier.
        /// </summary>
        /// <value>The popup identifier.</value>
        private string PopupID
        {
            get
            {
                return $"popup{UniqueID}";
            }
        }

        private string getButtonCss()
        {
            return $"{(!string.IsNullOrEmpty(Text) && !string.IsNullOrEmpty(Icon) ? "space-x-2" : "")} {(!string.IsNullOrEmpty(Text) && string.IsNullOrEmpty(Icon) ? "min-w-28" : "")} focus:outline-none leading-5 px-2 py-0.5 h-8 {(getApprearance())} {(Disabled ? "opacity-50 cursor-initial" : "cursor-pointer")}";
        }

        private string getPopupButtonCss()
        {
            return ButtonStyle switch
            {
                ButtonStyle.Primary => $"h-8 leading-5 px-2 py-0.5 focus:outline-none rounded-l-none border-l rounded-r  relative group before:absolute before:inset-0 before:bg-primary-800  before:rounded-r before:border-l-none  before:scale-x-0 before:origin-right  before:transition before:duration-300 hover:before:scale-x-100 hover:before:origin-left  {(Disabled ? "opacity-50 cursor-not-allowed" : "cursor-pointer")} {(Outline ? "border-l-primary border border-primary-900 text-primary-900 hover:text-white" : "border-l-white bg-primary-900 text-white ")}",
                ButtonStyle.Secondary => $"h-8 leading-5 px-2 py-0.5 focus:outline-none rounded-l-none  border-l rounded-r relative group before:absolute before:inset-0 before:bg-secondary-800  before:rounded-r before:border-l-none before:scale-x-0 before:origin-right  before:transition before:duration-300 hover:before:scale-x-100 hover:before:origin-left  {(Disabled ? "opacity-50 cursor-not-allowed" : "cursor-pointer")} {(Outline ? "border-l-secondary border border-secondary-900 text-secondary-900  hover:text-dark-900 " : "border-l-white bg-secondary-900 text-dark-900")}",
                ButtonStyle.Success => $"h-8 leading-5 px-2 py-0.5 focus:outline-none rounded-l-none border-l rounded-r relative group before:absolute before:inset-0 before:bg-success-800  before:rounded-r before:border-l-none before:scale-x-0 before:origin-right  before:transition before:duration-300 hover:before:scale-x-100 hover:before:origin-left  {(Disabled ? "opacity-50 cursor-not-allowed" : "cursor-pointer")} {(Outline ? "border-l-success border border-success-900 text-success-900  hover:text-white" : "border-l-white bg-success-900 text-white")}",
                ButtonStyle.Danger => $"h-8 leading-5 px-2 py-0.5 focus:outline-none rounded-l-none border-l rounded-r relative group before:absolute before:inset-0 before:bg-danger-800  before:rounded-r before:border-l-none before:scale-x-0 before:origin-right  before:transition before:duration-300 hover:before:scale-x-100 hover:before:origin-left {(Disabled ? "opacity-50 cursor-not-allowed" : "cursor-pointer")} {(Outline ? "border-l-danger border border-danger-900 text-danger-900  hover:text-white" : "border-l-white bg-danger-900  text-white")}",
                ButtonStyle.Warning => $"h-8 leading-5 px-2 py-0.5 focus:outline-none rounded-l-none border-l rounded-r relative group before:absolute before:inset-0 before:bg-warning-800  before:rounded-r before:border-l-none before:scale-x-0 before:origin-right  before:transition before:duration-300 hover:before:scale-x-100 hover:before:origin-left {(Disabled ? "opacity-50 cursor-not-allowed" : "cursor-pointer")} {(Outline ? "border-l-warning border border-warning-900 text-warning-900  hover:text-dark-900" : "border-l-white bg-warning-900  text-dark-900")}",
                ButtonStyle.Info => $"h-8 leading-5 px-2 py-0.5 focus:outline-none rounded-l-none border-l rounded-r relative group before:absolute before:inset-0 before:bg-info-800  before:rounded-r before:border-l-none before:scale-x-0 before:origin-right  before:transition before:duration-300 hover:before:scale-x-100 hover:before:origin-left  {(Disabled ? "opacity-50 cursor-not-allowed" : "cursor-pointer")} {(Outline ? "border-l-info border border-info-900 text-info-900  hover:text-white" : "border-l-white bg-info-900 text-white")}",
                ButtonStyle.Light => $"h-8 leading-5 px-2 py-0.5 focus:outline-none rounded-l-none border-l rounded-r relative group before:absolute before:inset-0 before:bg-light-800  before:rounded-r before:border-l-none before:scale-x-0 before:origin-right  before:transition before:duration-300 hover:before:scale-x-100 hover:before:origin-left  {(Disabled ? "opacity-50 cursor-not-allowed" : "cursor-pointer")} {(Outline ? "border-l-light border border-light-900  hover:text-dark-900" : "border-l-white bg-light-900 text-dark-900")}",
                ButtonStyle.Dark => $"h-8 leading-5 px-2 py-0.5 focus:outline-none rounded-l-none border-l rounded-r relative group before:absolute before:inset-0 before:bg-dark-800  before:rounded-r before:border-l-none before:scale-x-0 before:origin-right  before:transition before:duration-300 hover:before:scale-x-100 hover:before:origin-left  {(Disabled ? "opacity-50 cursor-not-allowed" : "cursor-pointer")} {(Outline ? "border-l-dark border border-dark-900 text-dark-900 hover:text-white" : "border-l-white bg-dark-900 text-white")}",
                _ => $"h-8 leading-5 px-2 py-0.5 focus:outline-none rounded-l-none border-l rounded-r relative group before:absolute before:inset-0 before:bg-primary-800  before:rounded-r before:border-l-none before:scale-x-0 before:origin-right  before:transition before:duration-300 hover:before:scale-x-100 hover:before:origin-left {(Disabled ? "opacity-50 cursor-not-allowed" : "cursor-pointer")} {(Outline ? "border-l-primary border border-primary-900" : "border-l-white bg-primary-900  text-white ")}"

            };
        }

        private string OpenPopupScript()
        {
            if (Disabled)
            {
                return string.Empty;
            }

            return $"Property365Components.togglePopup(this.parentNode, '{PopupID}')";
        }

        /// <inheritdoc />
        protected override string GetComponentCssClass()
        {
            return $"inline-flex items-center";
        }

        /// <inheritdoc />
        public override void Dispose()
        {
            Close();
            base.Dispose();
        }
    }
}
