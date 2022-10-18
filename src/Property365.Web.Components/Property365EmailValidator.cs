using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Components;

namespace Property365.Web.Components
{
    /// <summary>
    /// A validator component which checks if a component value is a valid email address.
    /// Must be placed inside a <see cref="Property365TemplateForm{TItem}" />
    /// </summary>
    /// <example>
    /// <code>
    /// &lt;Property365TemplateForm TItem="Model" Data=@model&gt;
    ///   &lt;Property365TextBox style="display: block" Name="Email" @bind-Value=@model.Email /&gt;
    ///   &lt;Property365EmailValidator Component="Email" Style="position: absolute" /&gt;
    /// &lt;/Property365TemplateForm&gt;
    /// @code {
    ///  class Model
    ///   {
    ///    public string Email { get; set; }
    ///  }
    ///  
    ///  Model model = new Model();
    /// }
    /// </code>
    /// </example>
    public class Property365EmailValidator : ValidatorBase
    {
        /// <summary>
        /// Gets or sets the message displayed when the component is invalid. Set to <c>"Invalid email"</c> by default.
        /// </summary>
        [Parameter]
        public override string Text { get; set; } = "Invalid email";

        /// <inheritdoc />
        protected override bool Validate(IProperty365FormComponent component)
        {
            var value = component.GetValue();
            var valueAsString = value as string;

            if (string.IsNullOrEmpty(valueAsString))
            {
                return true;
            }

            var email = new EmailAddressAttribute();

            return email.IsValid(valueAsString);
        }
    }
}