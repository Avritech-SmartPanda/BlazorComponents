using Microsoft.AspNetCore.Components;

namespace Property365.Web.Components
{
    /// <summary>
    /// Property365StepsItem component.
    /// </summary>
    public class Property365StepsItem : Property365Component
    {
        private string _text;
        /// <summary>
        /// Gets or sets the text.
        /// </summary>
        /// <value>The text.</value>
        [Parameter]
        public string Text
        {
            get
            {
                return _text;
            }
            set
            {
                if (_text != value)
                {
                    _text = value;
                    if (Steps != null)
                    {
                        Steps.Refresh();
                    }
                }
            }
        }

        /// <summary>
        /// Gets or sets the template.
        /// </summary>
        /// <value>The template.</value>
        [Parameter]
        public RenderFragment<Property365StepsItem> Template { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="Property365StepsItem"/> is selected.
        /// </summary>
        /// <value><c>true</c> if selected; otherwise, <c>false</c>.</value>
        [Parameter]
        public bool Selected { get; set; }

        bool _visible = true;
        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="Property365Component" /> is visible.
        /// </summary>
        /// <value><c>true</c> if visible; otherwise, <c>false</c>.</value>
        [Parameter]
        public override bool Visible
        {
            get
            {
                return _visible;
            }
            set
            {
                if (_visible != value)
                {
                    _visible = value;
                    if (Steps != null)
                    {
                        Steps.Refresh();
                    }
                }
            }
        }

        bool _disabled;
        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="Property365StepsItem"/> is disabled.
        /// </summary>
        /// <value><c>true</c> if disabled; otherwise, <c>false</c>.</value>
        [Parameter]
        public bool Disabled
        {
            get
            {
                return _disabled;
            }
            set
            {
                if (_disabled != value)
                {
                    _disabled = value;
                    if (Steps != null)
                    {
                        Steps.Refresh();
                    }
                }
            }
        }

        /// <summary>
        /// Gets or sets the child content.
        /// </summary>
        /// <value>The child content.</value>
        [Parameter]
        public RenderFragment ChildContent { get; set; }

        Property365Steps _steps;

        /// <summary>
        /// Gets or sets the steps.
        /// </summary>
        /// <value>The steps.</value>
        [CascadingParameter]
        public Property365Steps Steps
        {
            get
            {
                return _steps;
            }
            set
            {
                if (_steps != value)
                {
                    _steps = value;
                    _steps.AddStep(this);
                }
            }
        }

        /// <summary>
        /// Set parameters as an asynchronous operation.
        /// </summary>
        /// <param name="parameters">The parameters.</param>
        /// <returns>A Task representing the asynchronous operation.</returns>
        public override async Task SetParametersAsync(ParameterView parameters)
        {
            if (parameters.DidParameterChange(nameof(Selected), Selected))
            {
                var selected = parameters.GetValueOrDefault<bool>(nameof(Selected));
                if (!selected)
                {
                    Steps?.SelectFirst();
                }
                else
                {
                    Steps?.SelectStep(this);
                }
            }

            await base.SetParametersAsync(parameters);
        }

        /// <summary>
        /// Disposes this instance.
        /// </summary>
        public override void Dispose()
        {
            base.Dispose();
            Steps?.RemoveStep(this);
        }
    }
}