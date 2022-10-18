using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Rendering;
using System.Collections;

namespace Property365.Web.Components
{
    /// <summary>
    /// A component which displays a hierarchy of items. Supports inline definition and data-binding.
    /// </summary>
    /// <example>
    ///   <code>
    /// &lt;Property365Tree&gt;
    ///     &lt;Property365TreeItem Text="BMW"&gt;
    ///         &lt;Property365TreeItem Text="M3" /&gt;
    ///         &lt;Property365TreeItem Text="M5" /&gt;
    ///     &lt;/Property365TreeItem&gt;
    ///     &lt;Property365TreeItem Text="Audi"&gt;
    ///         &lt;Property365TreeItem Text="RS4" /&gt;
    ///         &lt;Property365TreeItem Text="RS6" /&gt;
    ///     &lt;/Property365TreeItem&gt;
    ///     &lt;Property365TreeItem Text="Mercedes"&gt;
    ///         &lt;Property365TreeItem Text="C63 AMG" /&gt;
    ///         &lt;Property365TreeItem Text="S63 AMG" /&gt;
    ///     &lt;/Property365TreeItem&gt;
    /// &lt;/Property365Tree&gt;
    ///   </code>
    /// </example>
    public partial class Property365Tree : Property365Component
    {
        /// <inheritdoc />
        protected override string GetComponentCssClass()
        {
            return "rz-tree";
        }

        internal Property365TreeItem SelectedItem { get; private set; }

        IList<Property365TreeLevel> Levels { get; set; } = new List<Property365TreeLevel>();

        /// <summary>
        /// A callback that will be invoked when the user selects an item.
        /// </summary>
        /// <example>
        /// <code>
        /// &lt;Property365Tree Change=@OnChange&gt;
        ///     &lt;Property365TreeItem Text="BMW"&gt;
        ///         &lt;Property365TreeItem Text="M3" /&gt;
        ///         &lt;Property365TreeItem Text="M5" /&gt;
        ///     &lt;/Property365TreeItem&gt;
        ///     &lt;Property365TreeItem Text="Audi"&gt;
        ///         &lt;Property365TreeItem Text="RS4" /&gt;
        ///         &lt;Property365TreeItem Text="RS6" /&gt;
        ///     &lt;/Property365TreeItem&gt;
        ///     &lt;Property365TreeItem Text="Mercedes"&gt;
        ///         &lt;Property365TreeItem Text="C63 AMG" /&gt;
        ///         &lt;Property365TreeItem Text="S63 AMG" /&gt;
        ///     &lt;/Property365TreeItem&gt;
        /// &lt;/Property365Tree&gt;
        /// @code {
        ///   void OnChange(TreeEventArgs args) 
        ///   {
        /// 
        ///   }
        /// }
        /// </code>
        /// </example>
        [Parameter]
        public EventCallback<TreeEventArgs> Change { get; set; }

        /// <summary>
        /// A callback that will be invoked when the user expands an item.
        /// </summary>
        /// <example>
        /// <code>
        /// &lt;Property365Tree Expand=@OnExpand&gt;
        ///     &lt;Property365TreeItem Text="BMW"&gt;
        ///         &lt;Property365TreeItem Text="M3" /&gt;
        ///         &lt;Property365TreeItem Text="M5" /&gt;
        ///     &lt;/Property365TreeItem&gt;
        ///     &lt;Property365TreeItem Text="Audi"&gt;
        ///         &lt;Property365TreeItem Text="RS4" /&gt;
        ///         &lt;Property365TreeItem Text="RS6" /&gt;
        ///     &lt;/Property365TreeItem&gt;
        ///     &lt;Property365TreeItem Text="Mercedes"&gt;
        ///         &lt;Property365TreeItem Text="C63 AMG" /&gt;
        ///         &lt;Property365TreeItem Text="S63 AMG" /&gt;
        ///     &lt;/Property365TreeItem&gt;
        /// &lt;/Property365Tree&gt;
        /// @code {
        ///   void OnExpand(TreeExpandEventArgs args) 
        ///   {
        /// 
        ///   }
        /// }
        /// </code>
        /// </example>
        [Parameter]
        public EventCallback<TreeExpandEventArgs> Expand { get; set; }

        /// <summary>
        /// Gets or sets the child content.
        /// </summary>
        /// <value>The child content.</value>
        [Parameter]
        public RenderFragment ChildContent { get; set; }

        /// <summary>
        /// Specifies the collection of data items which Property365Tree will create its items from.
        /// </summary>
        [Parameter]
        public IEnumerable Data { get; set; }

        /// <summary>
        /// Specifies the selected value. Use with <c>@bind-Value</c> to sync it with a property.
        /// </summary>
        [Parameter]
        public object Value { get; set; }

        /// <summary>
        /// A callback which will be invoked when <see cref="Value" /> changes.
        /// </summary>
        [Parameter]
        public EventCallback<object> ValueChanged { get; set; }

        /// <summary>
        /// Specifies whether Property365Tree displays check boxes. Set to <c>false</c> by default.
        /// </summary>
        /// <value><c>true</c> if check boxes are displayed; otherwise, <c>false</c>.</value>
        [Parameter]
        public bool AllowCheckBoxes { get; set; }

        /// <summary>
        /// Specifies what happens when a parent item is checked. If set to <c>true</c> checking parent items also checks all of its children.
        /// </summary>
        [Parameter]
        public bool AllowCheckChildren { get; set; } = true;

        /// <summary>
        /// Specifies what happens with a parent item when one of its children is checked. If set to <c>true</c> checking a child item will affect the checked state of its parents.
        /// </summary>
        [Parameter]
        public bool AllowCheckParents { get; set; } = true;

        /// <summary>
        /// Specifies whether siblings items are collapsed. Set to <c>false</c> by default.
        /// </summary>
        [Parameter]
        public bool SingleExpand { get; set; }

        /// <summary>
        /// Gets or sets the checked values. Use with <c>@bind-CheckedValues</c> to sync it with a property.
        /// </summary>
        [Parameter]
        public IEnumerable<object> CheckedValues { get; set; } = Enumerable.Empty<object>();

        internal List<Property365TreeItem> items = new List<Property365TreeItem>();

        internal void AddItem(Property365TreeItem item)
        {
            if (items.IndexOf(item) == -1)
            {
                items.Add(item);
            }
        }

        internal void RemoveItem(Property365TreeItem item)
        {
            if (items.IndexOf(item) != -1)
            {
                items.Remove(item);
            }
        }

        internal async Task SetCheckedValues(IEnumerable<object> values)
        {
            CheckedValues = values != null ? values.ToList() : null;
            await CheckedValuesChanged.InvokeAsync(CheckedValues);
        }

        internal IEnumerable<object> UncheckedValues { get; set; } = Enumerable.Empty<object>();

        internal void SetUncheckedValues(IEnumerable<object> values)
        {
            UncheckedValues = values.ToList();
        }

        /// <summary>
        /// A callback which will be invoked when <see cref="CheckedValues" /> changes.
        /// </summary>
        [Parameter]
        public EventCallback<IEnumerable<object>> CheckedValuesChanged { get; set; }

        void RenderTreeItem(RenderTreeBuilder builder, object data, RenderFragment<Property365TreeItem> template, Func<object, string> text,
            Func<object, bool> hasChildren, Func<object, bool> expanded, Func<object, bool> selected, IEnumerable children = null)
        {
            builder.OpenComponent<Property365TreeItem>(0);
            builder.AddAttribute(1, nameof(Property365TreeItem.Text), text(data));
            builder.AddAttribute(2, nameof(Property365TreeItem.Value), data);
            builder.AddAttribute(3, nameof(Property365TreeItem.HasChildren), hasChildren(data));
            builder.AddAttribute(4, nameof(Property365TreeItem.Template), template);
            builder.AddAttribute(5, nameof(Property365TreeItem.Expanded), expanded(data));
            builder.AddAttribute(6, nameof(Property365TreeItem.Selected), Value == data || selected(data));
            builder.SetKey(data);
        }

        RenderFragment RenderChildren(IEnumerable children, int depth)
        {
            var level = depth < Levels.Count() ? Levels.ElementAt(depth) : Levels.Last();

            return new RenderFragment(builder =>
            {
                Func<object, string> text = null;

                foreach (var data in children)
                {
                    if (text == null)
                    {
                        text = level.Text ?? Getter<string>(data, level.TextProperty);
                    }

                    RenderTreeItem(builder, data, level.Template, text, level.HasChildren, level.Expanded, level.Selected);

                    var hasChildren = level.HasChildren(data);

                    if (!string.IsNullOrEmpty(level.ChildrenProperty))
                    {
                        var grandChildren = PropertyAccess.GetValue(data, level.ChildrenProperty) as IEnumerable;

                        if (grandChildren != null && hasChildren)
                        {
                            builder.AddAttribute(7, "ChildContent", RenderChildren(grandChildren, depth + 1));
                            builder.AddAttribute(8, nameof(Property365TreeItem.Data), grandChildren);
                        }
                    }

                    builder.CloseComponent();
                }
            });
        }

        internal async Task SelectItem(Property365TreeItem item)
        {
            var selectedItem = SelectedItem;

            if (selectedItem != item)
            {
                SelectedItem = item;

                selectedItem?.Unselect();

                if (Value != item.Value)
                {
                    await ValueChanged.InvokeAsync(item.Value);
                }

                await Change.InvokeAsync(new TreeEventArgs()
                {
                    Text = item?.Text,
                    Value = item?.Value
                });
            }
        }

        internal async Task ExpandItem(Property365TreeItem item)
        {
            var args = new TreeExpandEventArgs()
            {
                Text = item?.Text,
                Value = item?.Value,
                Children = new TreeItemSettings()
            };

            await Expand.InvokeAsync(args);

            if (args.Children.Data != null)
            {
                var childContent = new RenderFragment(builder =>
                {
                    Func<object, string> text = null;
                    var children = args.Children;

                    foreach (var data in children.Data)
                    {
                        if (text == null)
                        {
                            text = children.Text ?? Getter<string>(data, children.TextProperty);
                        }

                        RenderTreeItem(builder, data, children.Template, text, children.HasChildren, children.Expanded, children.Selected);
                        builder.CloseComponent();
                    }
                });

                item.RenderChildContent(childContent);

                if (AllowCheckBoxes && AllowCheckChildren && args.Children.Data != null)
                {
                    if (CheckedValues != null && CheckedValues.Contains(item.Value))
                    {
                        await SetCheckedValues(CheckedValues.Union(args.Children.Data.Cast<object>().Except(UncheckedValues)));
                    }
                    else
                    {
                        await SetCheckedValues(CheckedValues.Except(args.Children.Data.Cast<object>()));
                    }
                }
            }
            else if (item.Data != null)
            {
                if (AllowCheckBoxes && AllowCheckChildren && item.Data != null)
                {
                    if (CheckedValues != null && CheckedValues.Contains(item.Value))
                    {
                        await SetCheckedValues(CheckedValues.Union(item.Data.Cast<object>().Except(UncheckedValues)));
                    }
                    else
                    {
                        await SetCheckedValues(CheckedValues);
                    }
                }
            }
        }

        Func<object, T> Getter<T>(object data, string property)
        {
            if (string.IsNullOrEmpty(property))
            {
                return (value) => (T)value;
            }

            return PropertyAccess.Getter<T>(data, property);
        }

        /// <inheritdoc />
        public override async Task SetParametersAsync(ParameterView parameters)
        {
            if (parameters.DidParameterChange(nameof(Value), Value))
            {
                var value = parameters.GetValueOrDefault<object>(nameof(Value));

                if (value == null)
                {
                    SelectedItem = null;
                }
            }

            await base.SetParametersAsync(parameters);
        }

        internal void AddLevel(Property365TreeLevel level)
        {
            if (!Levels.Contains(level))
            {
                Levels.Add(level);
                StateHasChanged();
            }
        }
    }
}
