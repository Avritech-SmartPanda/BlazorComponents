using Microsoft.AspNetCore.Components;
using Property365.Web.Components.Rendering;
using System.Collections;

namespace Property365.Web.Components
{
    /// <summary>
    /// Property365CheckBoxList component.
    /// </summary>
    /// <typeparam name="TValue">The type of the value.</typeparam>
    /// <example>
    /// <code>
    /// &lt;Property365CheckBoxList @bind-Value=@checkedValues TValue="int" &gt;
    ///     &lt;Items&gt;
    ///         &lt;Property365CheckBoxListItem Text="Orders" Value="1" /&gt;
    ///         &lt;Property365CheckBoxListItem Text="Employees" Value="2" /&gt;
    ///     &lt;/Items&gt;
    /// &lt;/Property365CheckBoxList&gt;
    /// </code>
    /// </example>
    public partial class Property365CheckBoxList<TValue> : FormComponent<IEnumerable<TValue>>
    {
        ClassList ItemClassList(Property365CheckBoxListItem<TValue> item) => ClassList.Create("absolute bg-white bottom-0 left-0 top-0 right-0 justify-center items-center flex border rounded")
                                                                            .Add("active", IsSelected(item))
                                                                            .Add("opacity-50", Disabled)
                                                                            .AddDisabled(Disabled || item.Disabled);

        ClassList IconClassList(Property365CheckBoxListItem<TValue> item) => ClassList.Create("w-2.5 align-middle")
                                                                            .Add("h-2.5 border-sm bg-blue-500", IsSelected(item));

        /// <summary>
        /// Gets or sets the value property.
        /// </summary>
        /// <value>The value property.</value>
        [Parameter]
        public string ValueProperty { get; set; }

        /// <summary>
        /// Gets or sets the text property.
        /// </summary>
        /// <value>The text property.</value>
        [Parameter]
        public string TextProperty { get; set; }

        IEnumerable<Property365CheckBoxListItem<TValue>> allItems
        {
            get
            {
                return items.Concat((Data != null ? Data.Cast<object>() : Enumerable.Empty<object>()).Select(i =>
                {
                    var item = new Property365CheckBoxListItem<TValue>();
                    item.SetText((string)PropertyAccess.GetItemOrValueFromProperty(i, TextProperty));
                    item.SetValue((TValue)PropertyAccess.GetItemOrValueFromProperty(i, ValueProperty));
                    return item;
                }));
            }
        }

        IEnumerable _data = null;
        /// <summary>
        /// Gets or sets the data used to generate items.
        /// </summary>
        /// <value>The data.</value>
        [Parameter]
        public virtual IEnumerable Data
        {
            get
            {
                return _data;
            }
            set
            {
                if (_data != value)
                {
                    _data = value;
                    StateHasChanged();
                }
            }
        }

        /// <inheritdoc />
        protected override string GetComponentCssClass()
        {
            return GetClassList(Orientation == Orientation.Horizontal ? "flex flex-row w-full" : "flex flex-col w-full space-y-1").ToString();
        }

        /// <summary>
        /// Gets a value indicating whether this instance has value.
        /// </summary>
        /// <value><c>true</c> if this instance has value; otherwise, <c>false</c>.</value>
        public override bool HasValue
        {
            get
            {
                return Value != null && Value.Any();
            }
        }

        /// <summary>
        /// Gets or sets the orientation.
        /// </summary>
        /// <value>The orientation.</value>
        [Parameter]
        public Orientation Orientation { get; set; } = Orientation.Horizontal;

        /// <summary>
        /// Gets or sets the items that will be concatenated with generated items from Data.
        /// </summary>
        /// <value>The items.</value>
        [Parameter]
        public RenderFragment Items { get; set; }

        List<Property365CheckBoxListItem<TValue>> items = new List<Property365CheckBoxListItem<TValue>>();

        /// <summary>
        /// Adds the item.
        /// </summary>
        /// <param name="item">The item.</param>
        public void AddItem(Property365CheckBoxListItem<TValue> item)
        {
            if (items.IndexOf(item) == -1)
            {
                items.Add(item);
                StateHasChanged();
            }
        }

        /// <summary>
        /// Removes the item.
        /// </summary>
        /// <param name="item">The item.</param>
        public void RemoveItem(Property365CheckBoxListItem<TValue> item)
        {
            if (items.Contains(item))
            {
                items.Remove(item);
                if (!disposed)
                {
                    try { InvokeAsync(StateHasChanged); } catch { }
                }
            }
        }

        /// <summary>
        /// Determines whether the specified item is selected.
        /// </summary>
        /// <param name="item">The item.</param>
        /// <returns><c>true</c> if the specified item is selected; otherwise, <c>false</c>.</returns>
        protected bool IsSelected(Property365CheckBoxListItem<TValue> item)
        {
            return Value != null && Value.Contains(item.Value);
        }

        /// <summary>
        /// Selects the item.
        /// </summary>
        /// <param name="item">The item.</param>
        protected async System.Threading.Tasks.Task SelectItem(Property365CheckBoxListItem<TValue> item)
        {
            if (Disabled || item.Disabled)
                return;

            List<TValue> selectedValues = new List<TValue>(Value != null ? Value : Enumerable.Empty<TValue>());

            if (!selectedValues.Contains(item.Value))
            {
                selectedValues.Add(item.Value);
            }
            else
            {
                selectedValues.Remove(item.Value);
            }

            Value = selectedValues;

            await ValueChanged.InvokeAsync(Value);
            if (FieldIdentifier.FieldName != null) { EditContext?.NotifyFieldChanged(FieldIdentifier); }
            await Change.InvokeAsync(Value);

            StateHasChanged();
        }

        private string getDisabledState(Property365CheckBoxListItem<TValue> item)
        {
            return Disabled || item.Disabled ? " rz-state-disabled" : "";
        }
    }
}
