using Microsoft.AspNetCore.Components;
using Property365.Web.Components.Rendering;
using System.Collections;
using System.Linq.Dynamic.Core;

namespace Property365.Web.Components
{
    /// <summary>
    /// Property365SelectBar component.
    /// </summary>
    /// <typeparam name="TValue">The type of the value.</typeparam>
    /// <example>
    /// <code>
    /// &lt;Property365SelectBar @bind-Value=@values TValue="IEnumerable&lt;int&gt;" Multiple="true"&gt;
    ///     &lt;Items&gt;
    ///         &lt;Property365SelectBarItem Text="Orders" Value="1" /&gt;
    ///         &lt;Property365SelectBarItem Text="Employees" Value="2" /&gt;
    ///         &lt;Property365SelectBarItem Text="Customers" Value="3" /&gt;
    ///     &lt;/Items&gt;
    /// &lt;/Property365SelectBar&gt;
    /// </code>
    /// </example>
    public partial class Property365SelectBar<TValue> : FormComponent<TValue>, IProperty365SelectBar
    {
        ClassList ButtonClassList(Property365SelectBarItem item) => ClassList.Create("rz-button rz-button-text-only")
                            .Add("state-active", IsSelected(item))
                            .AddDisabled(Disabled);

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

        IEnumerable<Property365SelectBarItem> allItems
        {
            get
            {
                return items.Concat((Data != null ? Data.Cast<object>() : Enumerable.Empty<object>()).Select(i =>
                {
                    var item = new Property365SelectBarItem();
                    item.SetText((string)PropertyAccess.GetItemOrValueFromProperty(i, TextProperty));
                    item.SetValue(PropertyAccess.GetItemOrValueFromProperty(i, ValueProperty));
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
            return GetClassList("rz-selectbutton rz-buttonset").Add($"rz-buttonset-{items.Count}").ToString();
        }

        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="Property365SelectBar{TValue}"/> is multiple.
        /// </summary>
        /// <value><c>true</c> if multiple; otherwise, <c>false</c>.</value>
        [Parameter]
        public bool Multiple { get; set; }

        /// <summary>
        /// Gets or sets the items.
        /// </summary>
        /// <value>The items.</value>
        [Parameter]
        public RenderFragment Items { get; set; }

        List<Property365SelectBarItem> items = new List<Property365SelectBarItem>();

        /// <summary>
        /// Adds the item.
        /// </summary>
        /// <param name="item">The item.</param>
        public void AddItem(Property365SelectBarItem item)
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
        public void RemoveItem(Property365SelectBarItem item)
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
        protected bool IsSelected(Property365SelectBarItem item)
        {
            if (Multiple)
            {
                return Value != null && ((IEnumerable)Value).Cast<object>().Contains(item.Value);
            }
            else
            {
                return object.Equals(Value, item.Value);
            }
        }

        /// <summary>
        /// Gets a value indicating whether this instance has value.
        /// </summary>
        /// <value><c>true</c> if this instance has value; otherwise, <c>false</c>.</value>
        public override bool HasValue
        {
            get
            {
                return Multiple ? Value != null && ((IEnumerable)Value).Cast<object>().Any() : Value != null;
            }
        }

        /// <summary>
        /// Selects the item.
        /// </summary>
        /// <param name="item">The item.</param>
        protected async System.Threading.Tasks.Task SelectItem(Property365SelectBarItem item)
        {
            if (Disabled)
                return;

            if (Multiple)
            {
                var type = typeof(TValue).IsGenericType ? typeof(TValue).GetGenericArguments()[0] : typeof(TValue);

                var selectedValues = Value != null ? ((IEnumerable)Value).AsQueryable().Cast(type).AsEnumerable().ToList() : new List<dynamic>();

                if (!selectedValues.Contains(item.Value))
                {
                    selectedValues.Add(item.Value);
                }
                else
                {
                    selectedValues.Remove(item.Value);
                }

                Value = (TValue)selectedValues.AsQueryable().Cast(type);
            }
            else
            {
                Value = (TValue)item.Value;
            }

            await ValueChanged.InvokeAsync(Value);
            if (FieldIdentifier.FieldName != null) { EditContext?.NotifyFieldChanged(FieldIdentifier); }
            await Change.InvokeAsync(Value);

            StateHasChanged();
        }
    }
}
