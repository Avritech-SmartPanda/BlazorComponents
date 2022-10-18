using Microsoft.AspNetCore.Components;
using System.ComponentModel.DataAnnotations;

namespace Property365.Web.Components
{
    /// <summary>
    /// A validator component which matches a component value against a specified regular expression pattern.
    /// Must be placed inside a <see cref="Property365TemplateForm{TItem}" />
    /// </summary>
    /// <example>
    /// <code>
    /// &lt;Property365TemplateForm TItem="Model" Data=@model&gt;
    ///    &lt;Property365TextBox style="display: block" Name="ZIP" @bind-Value=@model.Zip /&gt;
    ///    &lt;Property365RegexValidator Component="ZIP" Text="ZIP code must be 5 digits" Pattern="\d{5}" Style="position: absolute" /&gt;
    /// &lt;/Property365TemplateForm&gt;
    /// @code {
    ///    class Model
    ///    {
    ///       public string Zip { get; set; }
    ///    }
    ///    Model model = new Model(); 
    /// }
    /// </code>
    /// </example>
    public class Property365RegexValidator : ValidatorBase
    {
        /// <summary>
        /// Gets or sets the message displayed when the component is invalid. Set to <c>"Value should match"</c> by default.
        /// </summary>
        [Parameter]
        public override string Text { get; set; } = "Value should match";

        /// <summary>
        /// Specifies the regular expression pattern which the component value should match in order to be valid.
        /// </summary>
        [Parameter]
        public string Pattern { get; set; }

        /// <inheritdoc />
        protected override bool Validate(IProperty365FormComponent component)
        {
            return new RegularExpressionAttribute(Pattern).IsValid(component.GetValue());
        }
    }
}