using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Rendering;
using Microsoft.JSInterop;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components.Web;

namespace Property365.Web.Components
{
    /// <summary>
    /// Property365DropDown component.
    /// </summary>
    /// <typeparam name="TValue">The type of the value.</typeparam>
    /// <example>
    /// <code>
    /// &lt;Property365DropDown @bind-Value=@customerID TValue="string" Data=@customers TextProperty="CompanyName" ValueProperty="CustomerID" Change=@(args => Console.WriteLine($"Selected CustomerID: {args}")) /&gt;
    /// </code>
    /// </example>
    public partial class Property365DropDown<TValue> : DropDownBase<TValue>
    {

        /// <summary>
        /// Gets or sets a value indicating whether is read only.
        /// </summary>
        /// <value><c>true</c> if is read only; otherwise, <c>false</c>.</value>
        [Parameter]
        public bool ReadOnly { get; set; }

        /// <summary>
        /// Gets or sets the value template.
        /// </summary>
        /// <value>The value template.</value>
        [Parameter]
        public RenderFragment<dynamic> ValueTemplate { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether popup should open on focus. Set to <c>false</c> by default.
        /// </summary>
        /// <value><c>true</c> if popup should open on focus; otherwise, <c>false</c>.</value>
        [Parameter]
        public bool OpenOnFocus { get; set; }

        private async Task OnFocus(Microsoft.AspNetCore.Components.Web.FocusEventArgs args)
        {
            if (OpenOnFocus)
            {
                await OpenPopup("Enter", false);
            }
        }

        /// <summary>
        /// Opens the popup.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <param name="isFilter">if set to <c>true</c> [is filter].</param>
        /// <param name="isFromClick">if set to <c>true</c> [is from click].</param>
        protected override async Task OpenPopup(string key = "ArrowDown", bool isFilter = false, bool isFromClick = false)
        {
            if (Disabled)
                return;

            await JSRuntime.InvokeVoidAsync(OpenOnFocus ? "Property365Components.openPopup" : "Property365Components.togglePopup", Element, PopupID, true);
            await JSRuntime.InvokeVoidAsync("Property365Components.focusElement", isFilter ? UniqueID : SearchID);

            if (list != null)
            {
                await JSRuntime.InvokeVoidAsync("Property365Components.selectListItem", search, list, selectedIndex);
            }
        }

        internal override void RenderItem(RenderTreeBuilder builder, object item)
        {
            builder.OpenComponent(0, typeof(Property365DropDownItem<TValue>));
            builder.AddAttribute(1, "DropDown", this);
            builder.AddAttribute(2, "Item", item);

            if (DisabledProperty != null)
            {
                builder.AddAttribute(3, "Disabled", PropertyAccess.GetItemOrValueFromProperty(item, DisabledProperty));
            }

            builder.SetKey(GetKey(item));
            builder.CloseComponent();
        }

        /// <summary>
        /// Gets or sets the number of maximum selected labels.
        /// </summary>
        /// <value>The number of maximum selected labels.</value>
        [Parameter]
        public int MaxSelectedLabels { get; set; } = 4;

        /// <summary>
        /// Gets or sets a value indicating whether the selected items will be displayed as chips. Set to <c>false</c> by default.
        /// Requires <see cref="DropDownBase{T}.Multiple" /> to be set to <c>true</c>. 
        /// </summary>
        /// <value><c>true</c> to display the selected items as chips; otherwise, <c>false</c>.</value>
        [Parameter]
        public bool Chips { get; set; }

        /// <summary>
        /// Gets or sets the selected items text.
        /// </summary>
        /// <value>The selected items text.</value>
        [Parameter]
        public string SelectedItemsText { get; set; } = "items selected";

        /// <summary>
        /// Gets or sets the select all text.
        /// </summary>
        /// <value>The select all text.</value>
        [Parameter]
        public string SelectAllText { get; set; }

        private bool visibleChanged = false;
        private bool disabledChanged = false;
        private bool firstRender = true;

        /// <inheritdoc />
        public override async Task SetParametersAsync(ParameterView parameters)
        {
            visibleChanged = parameters.DidParameterChange(nameof(Visible), Visible);
            disabledChanged = parameters.DidParameterChange(nameof(Disabled), Disabled);

            await base.SetParametersAsync(parameters);

            if (visibleChanged && !firstRender)
            {
                if (Visible == false)
                {
                    Dispose();
                }
            }
        }

        private bool shouldReposition;

        /// <inheritdoc />
        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            await base.OnAfterRenderAsync(firstRender);

            this.firstRender = firstRender;

            if (firstRender || visibleChanged || disabledChanged)
            {
                visibleChanged = false;
                disabledChanged = false;

                if (Visible)
                {
                    bool reload = false;
                    if (LoadData.HasDelegate && Data == null)
                    {
                        await LoadData.InvokeAsync(await GetLoadDataArgs());
                        reload = true;
                    }

                    if (!Disabled)
                    {
                        await JSRuntime.InvokeVoidAsync("Property365Components.preventArrows", Element);
                        reload = true;
                    }

                    if (reload)
                    {
                        StateHasChanged();
                    }
                }
            }

            if (shouldReposition)
            {
                shouldReposition = false;

                await JSRuntime.InvokeVoidAsync("Property365Components.repositionPopup", Element, PopupID);
            }
        }

        /// <summary>
        /// Called when item is selected.
        /// </summary>
        /// <param name="item">The item.</param>
        /// <param name="isFromKey">if set to <c>true</c> [is from key].</param>
        protected override async Task OnSelectItem(object item, bool isFromKey = false)
        {
            if (!ReadOnly)
            {
                if (!Multiple && !isFromKey)
                {
                    await JSRuntime.InvokeVoidAsync("Property365Components.closePopup", PopupID);
                }

                await SelectItem(item);
            }
        }

        private async Task OnChipRemove(object item)
        {
            if (!Disabled)
            {
                await OnSelectItemInternal(item);
            }
        }

        internal async Task OnSelectItemInternal(object item, bool isFromKey = false)
        {
            await OnSelectItem(item, isFromKey);

            if (Chips)
            {
                shouldReposition = true;
            }
        }

        /// <inheritdoc />
        protected override string GetComponentCssClass()
        {
            return GetClassList("dropdownx relative  outline-1 hover:border-primary-900 focus:border-primary-900 focus:outline-none border border-gray-300 text-gray-900 text-sm rounded  block w-full p-3")
                        .Add("rz-clear", AllowClear)
                        .Add("rz-dropdown-chips", Chips && selectedItems.Count > 0)
                        .ToString();
        }

        /// <inheritdoc />
        public override void Dispose()
        {
            base.Dispose();

            if (IsJSRuntimeAvailable)
            {
                JSRuntime.InvokeVoidAsync("Property365Components.destroyPopup", PopupID);
            }
        }

        internal async Task ClosePopup()
        {
            await JSRuntime.InvokeVoidAsync("Property365Components.closePopup", PopupID);
        }       
    }
}
