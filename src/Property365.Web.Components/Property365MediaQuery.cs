using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace Property365.Web.Components
{
    /// <summary>
    /// Property365MediaQuery fires its <see cref="Change" /> event when the media query specified via <see cref="Query" /> matches or not.
    /// </summary>
    /// <example>
    /// &lt; Property365MediaQuery Query="(max-width: 768px)" Change=@OnChange /&gt;
    /// @code {
    ///  void OnChange(bool matches)
    ///  {
    ///     // matches is true if the media query applies; otherwise false.
    ///  }
    ///}
    /// </example>
    public class Property365MediaQuery : ComponentBase, IDisposable
    {

        [Inject]
        IJSRuntime JSRuntime { get; set; }
        

        /// <summary>
        /// The CSS media query this component will listen for.
        /// </summary>
        [Parameter]
        public string Query { get; set; }

        /// <summary>
        /// A callback that will be invoked when the status of the media query changes - to either match or not.
        /// </summary>
        [Parameter]
        public EventCallback<bool> Change { get; set; }

        /// <summary>
        /// Invoked by interop when media query changes.
        /// </summary>
        [JSInvokable]
        public async Task OnChange(bool matches)
        {
            await Change.InvokeAsync(matches);
        }

        bool initialized;
        private DotNetObjectReference<Property365MediaQuery> reference;

        private DotNetObjectReference<Property365MediaQuery> Reference
        {
            get
            {
                if (reference == null)
                {
                    reference = DotNetObjectReference.Create(this);
                }

                return reference;
            }
        }

        /// <summary>
        /// Called by the Blazor runtime. Initializes the media query on the client-side.
        /// </summary>
        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            if (firstRender)
            {
                initialized = true;
                var matches = await JSRuntime.InvokeAsync<bool>("Property365Components.mediaQuery", Query, Reference);

                await Change.InvokeAsync(matches);
            }
        }

        /// <summary>
        /// Detaches client-side event listeners.
        /// </summary>
        public void Dispose()
        {
            if (initialized)
            {
                JSRuntime.InvokeVoidAsync("Property365Components.mediaQuery", Reference);
            }

            reference?.Dispose();
            reference = null;
        }
    }
}