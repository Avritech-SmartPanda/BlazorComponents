using Microsoft.AspNetCore.Components;

namespace Property365.Web.Components
{
    /// <summary>
    /// Property365ArcGaugeScaleValue component.
    /// </summary>
    public partial class Property365ArcGaugeScaleValue : ComponentBase
    {
        /// <summary>
        /// Gets or sets the value.
        /// </summary>
        /// <value>The value.</value>
        [Parameter]
        public double Value { get; set; }

        /// <summary>
        /// Gets or sets the scale.
        /// </summary>
        /// <value>The scale.</value>
        [CascadingParameter]
        public Property365ArcGaugeScale Scale { get; set; }

        /// <summary>
        /// Gets or sets the stroke.
        /// </summary>
        /// <value>The stroke.</value>
        [Parameter]
        public string Stroke { get; set; }

        /// <summary>
        /// Gets or sets the width of the stroke.
        /// </summary>
        /// <value>The width of the stroke.</value>
        [Parameter]
        public double StrokeWidth { get; set; }

        /// <summary>
        /// Gets or sets the fill.
        /// </summary>
        /// <value>The fill.</value>
        [Parameter]
        public string Fill { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether to show value.
        /// </summary>
        /// <value><c>true</c> if value is shown; otherwise, <c>false</c>.</value>
        [Parameter]
        public bool ShowValue { get; set; } = true;

        /// <summary>
        /// Gets or sets the format string.
        /// </summary>
        /// <value>The format string.</value>
        [Parameter]
        public string FormatString { get; set; }

        /// <summary>
        /// Gets or sets the template.
        /// </summary>
        /// <value>The template.</value>
        [Parameter]
        public RenderFragment<Property365ArcGaugeScaleValue> Template { get; set; }

        /// <summary>
        /// Gets or sets the gauge.
        /// </summary>
        /// <value>The gauge.</value>
        [CascadingParameter]
        public Property365ArcGauge Gauge { get; set; }

        /// <inheritdoc />
        protected override void OnInitialized()
        {
            base.OnInitialized();

            Gauge.AddValue(this);
        }
        /// <inheritdoc />
        public override async Task SetParametersAsync(ParameterView parameters)
        {
            var shouldRefresh = false;

            if (parameters.DidParameterChange(nameof(Value), Value) || parameters.DidParameterChange(nameof(ShowValue), ShowValue))
            {
                shouldRefresh = true;
            }

            await base.SetParametersAsync(parameters);

            if (shouldRefresh)
            {
                Gauge.Reload();
            }
        }
    }
}
