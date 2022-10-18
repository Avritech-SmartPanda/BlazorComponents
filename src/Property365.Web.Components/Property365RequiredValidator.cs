using Microsoft.AspNetCore.Components;

namespace Property365.Web.Components
{
    /// <summary>
    /// A validator component which checks if a component has value.
    /// Must be placed inside a <see cref="Property365TemplateForm{TItem}" />
    /// </summary>
    /// <example>
    /// <code>
    /// &lt;Property365TemplateForm TItem="Model" Data=@model&gt;
    ///   &lt;Property365TextBox style="display: block" Name="Email" @bind-Value=@model.Email /&gt;
    ///   &lt;Property365RequiredValidator Component="Email" Text="Email is required" Style="position: absolute" /&gt;
    /// &lt;/Property365TemplateForm&gt;
    /// @code {
    ///  class Model
    ///  {
    ///    public string Email { get; set; }
    ///  }
    ///  
    ///  Model model = new Model();
    /// }
    /// </code>
    /// </example>
    public class Property365RequiredValidator : ValidatorBase
    {
        /// <summary>
        /// Gets or sets the message displayed when the component is invalid. Set to <c>"Required"</c> by default.
        /// </summary>
        [Parameter]
        public override string Text { get; set; } = "Required";

        /// <inheritdoc />
        protected override bool Validate(IProperty365FormComponent component)
        {
            return component.HasValue && !object.Equals(DefaultValue, component.GetValue());
        }

        /// <summary>
        /// Specifies a default value. If the component value is equal to <c>DefaultValue</c> it is considered invalid.
        /// </summary>
        [Parameter]
        public object DefaultValue { get; set; }
    }
}