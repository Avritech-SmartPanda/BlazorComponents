using Microsoft.AspNetCore.Components;

namespace Property365.Web.Components
{
    /// <summary>
    /// Contains <see cref="Property365Chart" /> tooltip configuration.
    /// </summary>
    public partial class Property365ChartTooltipOptions : Property365ChartComponentBase
    {
        /// <summary>
        /// Gets or sets a value indicating whether to show tooltips. By defaults Property365Chart displays tooltips.
        /// </summary>
        /// <value><c>true</c> to display tooltips; otherwise, <c>false</c>.</value>
        [Parameter]
        public bool Visible { get; set; } = true;

        /// <summary>
        /// Gets or sets the CSS style of the tooltip.
        /// </summary>
        /// <value>The style.</value>
        [Parameter]
        public string Style { get; set; }

        /// <inheritdoc />
        protected override void Initialize()
        {
            Chart.Tooltip = this;
        }

        /// <inheritdoc />
        protected override bool ShouldRefreshChart(ParameterView parameters)
        {
            return parameters.DidParameterChange(nameof(Style), Style);
        }
    }
}
