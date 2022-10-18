using Microsoft.AspNetCore.Components;

namespace Property365.Web.Components
{
    /// <summary>
    /// Base class that Property365HtmlEditor color picker tools inherit from.
    /// </summary>
    public abstract class Property365HtmlEditorColorBase : Property365HtmlEditorButtonBase
    {
        /// <summary>
        /// Sets <see cref="Property365ColorPicker.ShowHSV" /> of the built-in Property365ColorPicker.
        /// </summary>
        [Parameter]
        public bool ShowHSV { get; set; } = true;

        /// <summary>
        /// Sets <see cref="Property365ColorPicker.ShowRGBA" /> of the built-in Property365ColorPicker.
        /// </summary>
        [Parameter]
        public bool ShowRGBA { get; set; } = true;

        /// <summary>
        /// Gets or sets the child content.
        /// </summary>
        /// <value>The child content.</value>
        [Parameter]
        public RenderFragment ChildContent { get; set; }

        /// <summary>
        /// Sets <see cref="Property365ColorPicker.ShowColors" /> of the built-in Property365ColorPicker.
        /// </summary>
        [Parameter]
        public bool ShowColors { get; set; } = true;

        /// <summary>
        /// Sets <see cref="Property365ColorPicker.ShowButton" /> of the built-in Property365ColorPicker.
        /// </summary>
        [Parameter]
        public bool ShowButton { get; set; } = true;

        /// <summary>
        /// Sets <see cref="Property365ColorPicker.HexText" /> of the built-in Property365ColorPicker.
        /// </summary>
        [Parameter]
        public string HexText { get; set; } = "Hex";

        /// <summary>
        /// Sets <see cref="Property365ColorPicker.RedText" /> of the built-in Property365ColorPicker.
        /// </summary>
        [Parameter]
        public string RedText { get; set; } = "R";

        /// <summary>
        /// Sets <see cref="Property365ColorPicker.GreenText" /> of the built-in Property365ColorPicker.
        /// </summary>
        [Parameter]
        public string GreenText { get; set; } = "G";

        /// <summary>
        /// Sets <see cref="Property365ColorPicker.BlueText" /> of the built-in Property365ColorPicker.
        /// </summary>
        [Parameter]
        public string BlueText { get; set; } = "B";

        /// <summary>
        /// Sets <see cref="Property365ColorPicker.AlphaText" /> of the built-in Property365ColorPicker.
        /// </summary>
        [Parameter]
        public string AlphaText { get; set; } = "A";

        /// <summary>
        /// Sets <see cref="Property365ColorPicker.ButtonText" /> of the built-in Property365ColorPicker.
        /// </summary>
        [Parameter]
        public string ButtonText { get; set; } = "OK";


        /// <summary>
        /// Handles the change event of built-in Property365ColorPicker.
        /// </summary>
        /// <param name="value">The new color.</param>
        protected async Task OnChange(string value)
        {
            await Editor.ExecuteCommandAsync(CommandName, value);
        }
    }
}
