using Microsoft.AspNetCore.Components;
using Property365.Web.Components.Rendering;
using System.Collections;

namespace Property365.Web.Components
{
    /// <summary>
    /// Property365RadioButtonList component.
    /// </summary>
    /// <typeparam name="TValue">The type of the value.</typeparam>
    /// <example>
    /// <code>
    /// &lt;Property365RadioButtonList @bind-Value=@value TValue="int" Orientation="Orientation.Vertical" &gt;
    ///     &lt;Items&gt;
    ///         &lt;Property365RadioButtonListItem Text="Orders" Value="1" /&gt;
    ///         &lt;Property365RadioButtonListItem Text="Employees" Value="2" /&gt;
    ///     &lt;/Items&gt;
    /// &lt;/Property365RadioButtonList&gt;
    /// </code>
    /// </example>
    public partial class Property365RadioButtonList<TValue> : FormComponent<TValue>
    {
        ClassList ItemClassList(Property365RadioButtonListItem<TValue> item) => ClassList.Create("radiobutton-box")
                                                                            .Add("state-active", IsSelected(item))
                                                                            .AddDisabled(Disabled || item.Disabled);

        ClassList IconClassList(Property365RadioButtonListItem<TValue> item) => ClassList.Create("radiobutton-icon")
                                                                            .Add("rzi rzi-circle-on", IsSelected(item));
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

        /// <summary>
        /// Gets or sets the disabled property.
        /// </summary>
        /// <value>The disabled property.</value>
        [Parameter]
        public string DisabledProperty { get; set; }

        /// <summary>
        /// Gets or sets the visible property.
        /// </summary>
        /// <value>The visible property.</value>
        [Parameter]
        public string VisibleProperty { get; set; }

        IEnumerable<Property365RadioButtonListItem<TValue>> allItems
        {
            get
            {
                return items.Concat((Data != null ? Data.Cast<object>() : Enumerable.Empty<object>()).Select(i =>
                {
                    var item = new Property365RadioButtonListItem<TValue>();
                    item.SetText((string)PropertyAccess.GetItemOrValueFromProperty(i, TextProperty));
                    item.SetValue((TValue)PropertyAccess.GetItemOrValueFromProperty(i, ValueProperty));

                    if (DisabledProperty != null && PropertyAccess.TryGetItemOrValueFromProperty<bool>(i, DisabledProperty, out var disabledResult))
                    {
                        item.SetDisabled(disabledResult);
                    }

                    if (VisibleProperty != null && PropertyAccess.TryGetItemOrValueFromProperty<bool>(i, VisibleProperty, out var visibleResult))
                    {
                        item.SetVisible(visibleResult);
                    }

                    return item;
                }));
            }
        }

        IEnumerable _data = null;

        /// <summary>
        /// Gets or sets the data.
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
            return GetClassList(Orientation == Orientation.Horizontal ? "rz-radio-button-list-horizontal" : "rz-radio-button-list-vertical").ToString();
        }

        /// <summary>
        /// Gets or sets the orientation.
        /// </summary>
        /// <value>The orientation.</value>
        [Parameter]
        public Orientation Orientation { get; set; } = Orientation.Horizontal;

        /// <summary>
        /// Gets or sets the items.
        /// </summary>
        /// <value>The items.</value>
        [Parameter]
        public RenderFragment Items { get; set; }

        List<Property365RadioButtonListItem<TValue>> items = new List<Property365RadioButtonListItem<TValue>>();

        /// <summary>
        /// Adds the item.
        /// </summary>
        /// <param name="item">The item.</param>
        public void AddItem(Property365RadioButtonListItem<TValue> item)
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
        public void RemoveItem(Property365RadioButtonListItem<TValue> item)
        {
            if (items.Contains(item))
            {
                items.Remove(item);
                try
                { InvokeAsync(StateHasChanged); }
                catch { }
            }
        }

        /// <summary>
        /// Determines whether the specified item is selected.
        /// </summary>
        /// <param name="item">The item.</param>
        /// <returns><c>true</c> if the specified item is selected; otherwise, <c>false</c>.</returns>
        protected bool IsSelected(Property365RadioButtonListItem<TValue> item)
        {
            return object.Equals(Value, item.Value);
        }

        /// <summary>
        /// Selects the item.
        /// </summary>
        /// <param name="item">The item.</param>
        protected async System.Threading.Tasks.Task SelectItem(Property365RadioButtonListItem<TValue> item)
        {
            if (Disabled || item.Disabled)
                return;

            Value = item.Value;

            await ValueChanged.InvokeAsync(Value);
            if (FieldIdentifier.FieldName != null)
            { EditContext?.NotifyFieldChanged(FieldIdentifier); }
            await Change.InvokeAsync(Value);

            StateHasChanged();
        }

        /// <summary>
        /// Refreshes this instance.
        /// </summary>
        public void Refresh()
        {
            StateHasChanged();
        }
    }
}
