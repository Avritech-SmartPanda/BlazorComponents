﻿using Microsoft.AspNetCore.Components;

namespace Property365.Web.Components
{
    /// <summary>
    /// A validator component which checks if a component value is within a specified range.
    /// Must be placed inside a <see cref="Property365TemplateForm{TItem}" />
    /// </summary>
    /// <example>
    /// <code>
    /// &lt;Property365TemplateForm TItem="Model" Data=@model&gt;
    ///    &lt;Property365Numeric style="display: block" Name="Quantity" @bind-Value=@model.Quantity /&gt;
    ///    &lt;Property365NumericRangeValidator Component="Quantity" Min="1" Max="10" Text="Quantity should be between 1 and 10" Style="position: absolute" /&gt; 
    /// &lt;/Property365TemplateForm&gt;
    /// @code {
    ///    class Model
    ///    {
    ///       public decimal Quantity { get; set; }
    ///    }
    ///    Model model = new Model(); 
    /// }
    /// </code>
    /// </example>>
    public class Property365NumericRangeValidator : ValidatorBase
    {
        /// <summary>
        /// Gets or sets the message displayed when the component is invalid. Set to <c>"Not in the valid range"</c> by default.
        /// </summary>
        [Parameter]
        public override string Text { get; set; } = "Not in the valid range";

        /// <summary>
        /// Specifies the minimum value. The component value should be greater than the minimum in order to be valid.
        /// </summary>
        [Parameter]
        public dynamic Min { get; set; }

        /// <summary>
        /// Specifies the maximum value. The component value should be less than the maximum in order to be valid.
        /// </summary>
        [Parameter]
        public dynamic Max { get; set; }

        /// <inheritdoc />
        protected override bool Validate(IProperty365FormComponent component)
        {
            dynamic value = component.GetValue();

            if (Min != null && ((value != null && value < Min) || value == null))
            {
                return false;
            }

            if (Max != null && (value != null && value > Max))
            {
                return false;
            }

            return true;
        }
    }
}