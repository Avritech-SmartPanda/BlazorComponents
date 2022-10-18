using Microsoft.AspNetCore.Components;

namespace Property365.Web.Components
{
    /// <summary>
    /// Base class of components that are rendered inside a <see cref="Property365Chart" />.
    /// </summary>
    public abstract class Property365ChartComponentBase : ComponentBase
    {
        private Property365Chart chart;

        /// <summary>
        /// Used to inject the Property365Chart instance. Invokes <see cref="Initialize" />.
        /// </summary>
        /// <value>The chart.</value>
        [CascadingParameter]
        public Property365Chart Chart
        {
            get
            {
                return chart;
            }
            set
            {
                chart = value;
                Initialize();
            }
        }

        /// <summary>
        /// Perform initialization when <see cref="Chart" /> is set.
        /// </summary>
        protected virtual void Initialize()
        {

        }

        /// <summary>
        /// Determines if Property365Chart should render.
        /// </summary>
        /// <param name="parameters">The parameters.</param>
        protected virtual bool ShouldRefreshChart(ParameterView parameters)
        {
            return false;
        }

        /// <inheritdoc />
        public override async Task SetParametersAsync(ParameterView parameters)
        {
            bool shouldRefresh = ShouldRefreshChart(parameters);

            await base.SetParametersAsync(parameters);

            ValidateParameters();

            if (shouldRefresh)
            {
                await Chart.Refresh();
            }
        }

        /// <summary>
        /// Validates the parameters.
        /// </summary>
        protected virtual void ValidateParameters()
        {
        }

        /// <summary>
        /// Checks if the specified parameter changed.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="parameters">The parameters.</param>
        /// <param name="parameterName">Name of the parameter.</param>
        /// <param name="parameterValue">The parameter value.</param>
        /// <returns><c>true</c> if the parameter changed, <c>false</c> otherwise.</returns>
        protected bool DidParameterChange<T>(ParameterView parameters, string parameterName, T parameterValue)
        {
            return parameters.DidParameterChange(parameterName, parameterValue);
        }
    }
}
