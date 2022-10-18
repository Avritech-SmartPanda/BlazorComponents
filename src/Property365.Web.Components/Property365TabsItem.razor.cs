﻿using Microsoft.AspNetCore.Components;
using Property365.Web.Components.Rendering;

namespace Property365.Web.Components
{
    /// <summary>
    /// Property365TabsItem component.
    /// </summary>
    public partial class Property365TabsItem : IDisposable
    {
        /// <summary>
        /// Gets or sets the arbitrary attributes.
        /// </summary>
        /// <value>The arbitrary attributes.</value>
        [Parameter(CaptureUnmatchedValues = true)]
        public IDictionary<string, object> Attributes { get; set; }

        /// <summary>
        /// Gets or sets the style.
        /// </summary>
        /// <value>The style.</value>
        [Parameter]
        public string Style { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="Property365TabsItem"/> is visible.
        /// </summary>
        /// <value><c>true</c> if visible; otherwise, <c>false</c>.</value>
        [Parameter]
        public bool Visible { get; set; } = true;

        /// <summary>
        /// Gets or sets the text.
        /// </summary>
        /// <value>The text.</value>
        [Parameter]
        public string Text { get; set; }

        /// <summary>
        /// Gets or sets the template.
        /// </summary>
        /// <value>The template.</value>
        [Parameter]
        public RenderFragment<Property365TabsItem> Template { get; set; }

        /// <summary>
        /// Gets or sets the icon.
        /// </summary>
        /// <value>The icon.</value>
        [Parameter]
        public string Icon { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="Property365TabsItem"/> is selected.
        /// </summary>
        /// <value><c>true</c> if selected; otherwise, <c>false</c>.</value>
        [Parameter]
        public bool Selected { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="Property365TabsItem"/> is disabled.
        /// </summary>
        /// <value><c>true</c> if disabled; otherwise, <c>false</c>.</value>
        [Parameter]
        public bool Disabled { get; set; }

        /// <summary>
        /// Gets the class list.
        /// </summary>
        /// <value>The class list.</value>
        ClassList ClassList => ClassList.Create()
                                        .Add("rz-tabview-selected", IsSelected)
                                        .AddDisabled(Disabled)
                                        .Add(Attributes);

        /// <summary>
        /// Gets the index.
        /// </summary>
        /// <value>The index.</value>
        public int Index
        {
            get
            {
                return Tabs.IndexOf(this);
            }
        }

        /// <summary>
        /// Gets a value indicating whether this instance is selected.
        /// </summary>
        /// <value><c>true</c> if this instance is selected; otherwise, <c>false</c>.</value>
        public bool IsSelected
        {
            get
            {
                return Tabs.IsSelected(this);
            }
        }

        /// <summary>
        /// Gets or sets the child content.
        /// </summary>
        /// <value>The child content.</value>
        [Parameter]
        public RenderFragment ChildContent { get; set; }

        /// <summary>
        /// Gets or sets the tabs.
        /// </summary>
        /// <value>The tabs.</value>
        [CascadingParameter]
        public Property365Tabs Tabs { get; set; }

        /// <summary>
        /// On initialized as an asynchronous operation.
        /// </summary>
        /// <returns>A Task representing the asynchronous operation.</returns>
        protected override async Task OnInitializedAsync()
        {
            await Tabs.AddTab(this);
        }

        async Task OnClick()
        {
            if (!Disabled)
            {
                if (Tabs.RenderMode == TabRenderMode.Server)
                {
                    await Tabs.SelectTab(this, true);
                }
                else
                {
                    await Tabs.SelectTabOnClient(this);
                }
            }
        }

        /// <inheritdoc />
        public override async Task SetParametersAsync(ParameterView parameters)
        {
            var selectedChanged = parameters.DidParameterChange(nameof(Selected), Selected);
            var visibleChanged = parameters.DidParameterChange(nameof(Visible), Visible);

            await base.SetParametersAsync(parameters);

            if (selectedChanged)
            {
                if (Selected)
                {
                    Tabs?.SelectTab(this);
                }
            }

            if (visibleChanged && IsSelected)
            {
                Tabs?.SelectTab(this);
            }

            if (visibleChanged && Tabs?.RenderMode == TabRenderMode.Client)
            {
                var firstTab = Tabs?.FirstVisibleTab();
                if (firstTab != null)
                {
                    await Tabs.SelectTabOnClient(firstTab);
                }
            }
        }

        /// <inheritdoc />
        public void Dispose()
        {
            Tabs?.RemoveItem(this);
        }
    }
}