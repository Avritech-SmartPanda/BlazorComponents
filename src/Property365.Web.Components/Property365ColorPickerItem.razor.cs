using Microsoft.AspNetCore.Components;
using Property365.Web.Components.Rendering;

namespace Property365.Web.Components
{
    /// <summary>
    /// Property365ColorPickerItem component.
    /// </summary>
    public partial class Property365ColorPickerItem
    {
        /// <summary>
        /// Gets or sets the value.
        /// </summary>
        /// <value>The value.</value>
        [Parameter]
        public string Value { get; set; }

        string Background
        {
            get
            {
                RGB rgb = RGB.Parse(Value);

                return rgb?.ToCSS();
            }
        }

        /// <summary>
        /// Gets or sets the color picker.
        /// </summary>
        /// <value>The color picker.</value>
        [CascadingParameter]
        public Property365ColorPicker ColorPicker { get; set; }

        async Task OnClick()
        {
            await ColorPicker.SelectColor(Value);
        }
    }
}
