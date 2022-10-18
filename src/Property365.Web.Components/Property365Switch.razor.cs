namespace Property365.Web.Components
{
    /// <summary>
    /// Property365Switch component.
    /// </summary>
    /// <example>
    /// <code>
    /// &lt;Property365Switch @bind-Value=@value Change=@(args => Console.WriteLine($"Value: {args}")) /&gt;
    /// </code>
    /// </example>
    public partial class Property365Switch : FormComponent<bool>
    {
        /// <inheritdoc />
        protected override string GetComponentCssClass()
        {
            return GetClassList("rz-switch").Add("rz-switch-checked", Value).ToString();
        }

        /// <summary>
        /// Toggles this instance checked state.
        /// </summary>
        public async System.Threading.Tasks.Task Toggle()
        {
            if (Disabled)
            {
                return;
            }

            Value = !Value;

            await ValueChanged.InvokeAsync(Value);
            if (FieldIdentifier.FieldName != null) { EditContext?.NotifyFieldChanged(FieldIdentifier); }
            await Change.InvokeAsync(Value);
        }
    }
}
