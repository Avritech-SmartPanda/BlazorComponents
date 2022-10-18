using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Property365.Web.Components.Rendering;

namespace Property365.Web.Components
{
    /// <summary>
    /// Property365CheckBox component.
    /// </summary>
    /// <typeparam name="TValue">The type of the value.</typeparam>
    /// <example>
    /// <code>
    /// &lt;Property365CheckBox @bind-Value=@someValue TValue="bool" Change=@(args => Console.WriteLine($"Is checked: {args}")) /&gt;
    /// </code>
    /// </example>
    public partial class Property365CheckBox<TValue> : FormComponent<TValue>
    {
        /// <summary>
        /// Gets or sets a value indicating whether is tri-state (true, false or null).
        /// </summary>
        /// <value><c>true</c> if tri-state; otherwise, <c>false</c>.</value>
        [Parameter]
        public bool TriState { get; set; } = false;

        ClassList BoxClassList => ClassList.Create("absolute bg-white bottom-0 left-0 top-0 right-0 justify-center items-center flex border rounded")
                                           .Add("active", !object.Equals(Value, false))
                                           .Add("opacity-50", Disabled)
                                           .AddDisabled(Disabled);

        ClassList IconClassList => ClassList.Create("w-2.5 align-middle")
                                            .Add("h-2.5 border-sm bg-blue-500", object.Equals(Value, true))
                                            .Add("h-0.5 border-sm bg-blue-500", object.Equals(Value, null));

        string CheckBoxValue => CheckBoxChecked ? "true" : "false";

        bool CheckBoxChecked => object.Equals(Value, true);

        /// <inheritdoc />
        protected override string GetComponentCssClass()
        {
            return GetClassList("inline-block align-middle relative w-5 min-w-5 h-5").ToString();
        }

        async Task OnKeyPress(KeyboardEventArgs args)
        {
            if (args.Code == "Space")
            {
                await Toggle();
            }
        }

        async Task Toggle()
        {
            if (Disabled)
            {
                return;
            }

            if (object.Equals(Value, false))
            {
                if (TriState)
                {
                    Value = default;
                }
                else
                {
                    Value = (TValue)(object)true;
                }
            }
            else if (Value == null)
            {
                Value = (TValue)(object)true;
            }
            else if (object.Equals(Value, true))
            {
                Value = (TValue)(object)false;
            }

            await ValueChanged.InvokeAsync(Value);
            if (FieldIdentifier.FieldName != null) { EditContext?.NotifyFieldChanged(FieldIdentifier); }
            await Change.InvokeAsync(Value);
        }
    }
}
