using Microsoft.AspNetCore.Components;

namespace Property365.Web.Components
{
    /// <summary>
    /// Property365SelectBarItem component.
    /// </summary>
    public class Property365SelectBarItem : Property365Component
    {
        /// <summary>
        /// Gets or sets the text.
        /// </summary>
        /// <value>The text.</value>
        [Parameter]
        public string Text { get; set; }

        /// <summary>
        /// Gets or sets the value.
        /// </summary>
        /// <value>The value.</value>
        [Parameter]
        public object Value { get; set; }

        IProperty365SelectBar _selectBar;

        /// <summary>
        /// Gets or sets the select bar.
        /// </summary>
        /// <value>The select bar.</value>
        [CascadingParameter]
        public IProperty365SelectBar SelectBar
        {
            get
            {
                return _selectBar;
            }
            set
            {
                if (_selectBar != value)
                {
                    _selectBar = value;
                    _selectBar.AddItem(this);
                }
            }
        }

        /// <summary>
        /// Disposes this instance.
        /// </summary>
        public override void Dispose()
        {
            base.Dispose();
            SelectBar?.RemoveItem(this);
        }

        internal void SetText(string value)
        {
            Text = value;
        }

        internal void SetValue(object value)
        {
            Value = value;
        }
    }
}