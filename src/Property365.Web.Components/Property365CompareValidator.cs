using Microsoft.AspNetCore.Components;

namespace Property365.Web.Components
{
    /// <summary>
    /// Specifies the comparison operation used by a <see cref="Property365CompareValidator" />
    /// </summary>
    public enum CompareOperator
    {
        /// <summary>
        /// Check if values are equal.
        /// </summary>
        Equal,
        /// <summary>
        /// Check if a value is greater than another value.
        /// </summary>
        GreaterThan,
        /// <summary>
        /// Check if a value is greater than or equal to another value.
        /// </summary>
        GreaterThanEqual,
        /// <summary>
        /// Check if a value is less than another value.
        /// </summary>
        LessThan,
        /// <summary>
        /// Check if a value is less than or equal to another value.
        /// </summary>
        LessThanEqual,
        /// <summary>
        /// Check if values are not equal.
        /// </summary>
        NotEqual,
    }

    /// <summary>
    /// A validator component which compares a component value with a specified value.
    /// Must be placed inside a <see cref="Property365TemplateForm{TItem}" />
    /// </summary>
    /// <example>
    /// <code>
    /// &lt;Property365TemplateForm TItem="Model" Data=@model&gt;
    ///    &lt;Property365Password style="display: block" Name="Password" @bind-Value=@model.Password /&gt;
    ///    &lt;Property365Password style="display: block" Name="RepeatPassword" @bind-Value=@model.RepeatPassword /&gt;
    ///    &lt;Property365CompareValidator Value=@model.Password Component="RepeatPassword" Text="Passwords should be the same"  Style="position: absolute" /&gt;
    /// &lt;/Property365TemplateForm&gt;
    /// @code {
    ///    class Model
    ///    {
    ///      public string Password { get; set; }
    ///      public double Value { get; set; }
    ///      public string RepeatPassword { get; set; }
    ///    } 
    ///    Model model = new Model();
    /// }
    /// </code>
    /// </example>
    public class Property365CompareValidator : ValidatorBase
    {
        /// <summary>
        /// Gets or sets the message displayed when the component is invalid. Set to <c>"Value should match"</c> by default.
        /// </summary>
        [Parameter]
        public override string Text { get; set; } = "Value should match";

        /// <summary>
        /// Specifies the value to compare with.
        /// </summary>
        [Parameter]
        public object Value { get; set; }

        /// <summary>
        /// Specifies the comparison operator. Set to <c>CompareOperator.Equal</c> by default.
        /// </summary>
        [Parameter]
        public CompareOperator Operator { get; set; } = CompareOperator.Equal;

        private int Compare(object componentValue)
        {
            switch (componentValue)
            {
                case String stringValue:
                    return String.Compare(stringValue, (string)Value, false, Culture);
                case IComparable comparable:
                    return comparable.CompareTo(Value);
                default:
                    return 0;
            }
        }
        /// <inheritdoc />
        protected override bool Validate(IProperty365FormComponent component)
        {
            var compareResult = Compare(component.GetValue());

            switch (Operator)
            {
                case CompareOperator.Equal:
                    return compareResult == 0;
                case CompareOperator.NotEqual:
                    return compareResult != 0;
                case CompareOperator.GreaterThan:
                    return compareResult > 0;
                case CompareOperator.GreaterThanEqual:
                    return compareResult >= 0;
                case CompareOperator.LessThan:
                    return compareResult < 0;
                case CompareOperator.LessThanEqual:
                    return compareResult <= 0;
                default:
                    return true;
            }
        }
    }
}