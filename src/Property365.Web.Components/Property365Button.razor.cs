using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;

namespace Property365.Web.Components
{
    /// <summary>
    /// Property365Button component.
    /// </summary>
    /// <example>
    /// <code>
    /// &lt;Property365Button Click=@(args => Console.WriteLine("Button clicked")) Text="Button" /&gt;
    /// </code>
    /// </example>
    public partial class Property365Button : Property365Component
    {

        private string getApprearance()
        {
            return ButtonStyle switch
            {
                ButtonStyle.Primary => $"{(Outline ? " border-primary-900 text-primary-900 border hover:text-white hover:bg-primary-900" : "hover:bg-dark-900 bg-primary-900  text-white border-none")}",
                ButtonStyle.Secondary => $"{(Outline ? " border border-secondary-900 text-secondary-900 hover:border-secondary-500 hover:bg-secondary-500 hover:text-secondary-900 " : "hover:bg-gray-400 hover:bg-primary-900 bg-secondary-900  text-white border-none")}",
                ButtonStyle.Success => $"{(Outline ? " border-success-900  border text-success-900  hover:bg-success-900 hover:text-white" : "hover:bg-success-800 bg-success-900 text-white border-none")}",
                ButtonStyle.Danger => $"{(Outline ? " border-danger-900  border text-danger-900  hover:bg-danger-900 hover:text-white" : "hover:bg-danger-800  bg-danger-900 text-white border-none")}",
                ButtonStyle.Warning => $"{(Outline ? " border-warning-900  border text-warning-900 hover:bg-warning-900  hover:text-white" : "hover:bg-warning-800 bg-warning-900 text-white border-none")}",
                ButtonStyle.Info => $"{(Outline ? " border-info-900  border text-info-900  hover:bg-info-900 hover:text-white" : "hover:bg-info-800 bg-info-900 text-white border-none")}",
                ButtonStyle.Light => $"{(Outline ? "border-light-900  border text-light-900  hover:bg-light-900 hover:text-primary-900" : "hover:bg-secondary-500  bg-light-900 text-primary-900 border-none")}",
                ButtonStyle.Dark => $"{(Outline ? " border-dark-900 border text-dark-900  hover:bg-dark-900 hover:text-white" : "bg-dark-900 hover:bg-primary-900  text-white border-none")}",
                _ => $"hover:bg-dark-900 bg-primary-900  text-white border-none"
            };

        }


        private string getSize()
        {
            return Size switch
            {
                ButtonSize.Small => $"text-xs {(string.IsNullOrEmpty(Text) && !string.IsNullOrEmpty(Icon) ? "p-3" : "py-2 px-9")}",
                ButtonSize.Medium => $"text-sm {(string.IsNullOrEmpty(Text) && !string.IsNullOrEmpty(Icon) ? "p-3" : "py-2.5 px-9")}",
                ButtonSize.Large => $"text-base {(string.IsNullOrEmpty(Text) && !string.IsNullOrEmpty(Icon) ? "p-3" : "py-3.5 px-9")}",
                _ => $"text-sm {(string.IsNullOrEmpty(Text) && !string.IsNullOrEmpty(Icon) ? "p-3" : "px-9 py-2.5")}"
            };


        }

        /// <summary>
        /// Gets or sets the child content.
        /// </summary>
        /// <value>The child content.</value>
        [Parameter]
        public RenderFragment? ChildContent { get; set; }

        /// <summary>
        /// Gets or sets the text.
        /// </summary>
        /// <value>The text.</value>
        [Parameter]
        public string? Text { get; set; }

        /// <summary>
        /// Gets or sets the icon.
        /// </summary>
        /// <value>The icon.</value>
        [Parameter]
        public string? Icon { get; set; }

        /// <summary>
        /// Gets or sets the image.
        /// </summary>
        /// <value>The image.</value>
        [Parameter]
        public string? Image { get; set; }

        /// <summary>
        /// Gets or sets the button style.
        /// </summary>
        /// <value>The button style.</value>
        [Parameter]
        public ButtonStyle ButtonStyle { get; set; } = ButtonStyle.Primary;

        /// <summary>
        /// Gets or sets the button appearance.
        /// </summary>
        /// <value>The button appearance.</value>
        [Parameter]
        public ButtonAppearance ButtonAppearance { get; set; } = ButtonAppearance.Simple;

        /// <summary>
        /// Gets or sets the size.
        /// </summary>
        /// <value>The size.</value>
        [Parameter]
        public ButtonSize Size { get; set; } = ButtonSize.Medium;
        /// <summary>
        /// Gets or sets the outline of the button.
        /// </summary>
        /// <value>The outline of the button.</value>
        [Parameter]
        public bool Outline { get; set; }

        /// <summary>
        /// Sets rounded border radius of the button.
        /// </summary>
        /// <value>The rounded border radius of the button.
        [Parameter]
        public bool Rounded { get; set; }


        /// <summary>
        /// Gets or sets the type of the button.
        /// </summary>
        /// <value>The type of the button.</value>
        [Parameter]
        public ButtonType ButtonType { get; set; } = ButtonType.Button;



        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="Property365Button"/> is disabled.
        /// </summary>
        /// <value><c>true</c> if disabled; otherwise, <c>false</c>.</value>
        [Parameter]
        public bool Disabled { get; set; }

        /// <summary>
        /// Gets or sets the click callback.
        /// </summary>
        /// <value>The click callback.</value>
        [Parameter]
        public EventCallback<MouseEventArgs> Click { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this instance busy text is shown.
        /// </summary>
        /// <value><c>true</c> if this instance busy text is shown; otherwise, <c>false</c>.</value>
        [Parameter]
        public bool IsBusy { get; set; }

        /// <summary>
        /// Gets or sets the busy text.
        /// </summary>
        /// <value>The busy text.</value>
        [Parameter]
        public string? BusyText { get; set; }

        /// <summary>
        /// Gets a value indicating whether this instance is disabled.
        /// </summary>
        /// <value><c>true</c> if this instance is disabled; otherwise, <c>false</c>.</value>
        public bool IsDisabled { get => Disabled || IsBusy; }


        bool clicking;
        /// <summary>
        /// Handles the <see cref="E:Click" /> event.
        /// </summary>
        /// <param name="args">The <see cref="MouseEventArgs"/> instance containing the event data.</param>
        public async Task OnClick(MouseEventArgs args)
        {
            if (clicking)
            {
                return;
            }

            try
            {
                clicking = true;

                await Click.InvokeAsync(args);
            }
            finally
            {
                clicking = false;
            }
        }

        /// <inheritdoc />
        protected override string GetComponentCssClass()
        {
            var baseStyles = "inline-flex items-center focus:outline-none font-medium ";
            return $"{baseStyles} {getSize()} {getApprearance()} {(Disabled ? "opacity-50 cursor-initial" : "cursor-pointer")} {(Rounded ? "rounded-full" : "rounded")}";
        }
    }
}
