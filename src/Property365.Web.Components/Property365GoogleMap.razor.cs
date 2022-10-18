using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace Property365.Web.Components
{
    /// <summary>
    /// Property365GoogleMap component.
    /// </summary>
    /// <example>
    /// <code>
    /// &lt;Property365GoogleMap Zoom="3" Center=@(new GoogleMapPosition() { Lat = 42.6977, Lng = 23.3219 }) MapClick=@OnMapClick MarkerClick=@OnMarkerClick"&gt;
    ///     &lt;Markers&gt;
    ///         &lt;Property365GoogleMapMarker Title="London" Label="London" Position=@(new GoogleMapPosition() { Lat = 51.5074, Lng = 0.1278 }) /&gt;
    ///         &lt;Property365GoogleMapMarker Title="Paris " Label="Paris" Position=@(new GoogleMapPosition() { Lat = 48.8566, Lng = 2.3522 }) /&gt;
    ///     &lt;/Markers&gt;
    /// &lt;/Property365GoogleMap&gt;
    /// @code {
    ///   void OnMapClick(GoogleMapClickEventArgs args)
    ///   {
    ///     Console.WriteLine($"Map clicked at Lat: {args.Position.Lat}, Lng: {args.Position.Lng}");
    ///   }
    ///   
    ///   void OnMarkerClick(Property365GoogleMapMarker marker)
    ///   {
    ///     Console.WriteLine($"Map {marker.Title} marker clicked. Marker position -> Lat: {marker.Position.Lat}, Lng: {marker.Position.Lng}");
    ///   }
    /// }
    /// </code>
    /// </example>
    public partial class Property365GoogleMap : Property365Component
    {
        /// <summary>
        /// Gets or sets the data - collection of Property365GoogleMapMarker.
        /// </summary>
        /// <value>The data.</value>
        [Parameter]
        public IEnumerable<Property365GoogleMapMarker> Data { get; set; }

        /// <summary>
        /// Gets or sets the map click callback.
        /// </summary>
        /// <value>The map click callback.</value>
        [Parameter]
        public EventCallback<GoogleMapClickEventArgs> MapClick { get; set; }

        /// <summary>
        /// Gets or sets the marker click callback.
        /// </summary>
        /// <value>The marker click callback.</value>
        [Parameter]
        public EventCallback<Property365GoogleMapMarker> MarkerClick { get; set; }

        /// <summary>
        /// Gets or sets the Google API key.
        /// </summary>
        /// <value>The Google API key.</value>
        [Parameter]
        public string ApiKey { get; set; }

        /// <summary>
        /// Gets or sets the zoom.
        /// </summary>
        /// <value>The zoom.</value>
        [Parameter]
        public double Zoom { get; set; } = 8;

        /// <summary>
        /// Gets or sets the center map position.
        /// </summary>
        /// <value>The center.</value>
        [Parameter]
        public GoogleMapPosition Center { get; set; } = new GoogleMapPosition() { Lat = 0, Lng = 0 };

        /// <summary>
        /// Gets or sets the markers.
        /// </summary>
        /// <value>The markers.</value>
        [Parameter]
        public RenderFragment Markers { get; set; }

        List<Property365GoogleMapMarker> markers = new List<Property365GoogleMapMarker>();

        /// <summary>
        /// Adds the marker.
        /// </summary>
        /// <param name="marker">The marker.</param>
        public void AddMarker(Property365GoogleMapMarker marker)
        {
            if (markers.IndexOf(marker) == -1)
            {
                markers.Add(marker);
            }
        }

        /// <summary>
        /// Removes the marker.
        /// </summary>
        /// <param name="marker">The marker.</param>
        public void RemoveMarker(Property365GoogleMapMarker marker)
        {
            if (markers.IndexOf(marker) != -1)
            {
                markers.Remove(marker);
            }
        }

        /// <inheritdoc />
        protected override string GetComponentCssClass()
        {
            return "rz-map";
        }

        /// <summary>
        /// Handles the <see cref="E:MapClick" /> event.
        /// </summary>
        /// <param name="args">The <see cref="GoogleMapClickEventArgs"/> instance containing the event data.</param>
        [JSInvokable("Property365GoogleMap.OnMapClick")]
        public async System.Threading.Tasks.Task OnMapClick(GoogleMapClickEventArgs args)
        {
            await MapClick.InvokeAsync(args);
        }

        /// <summary>
        /// Called when marker click.
        /// </summary>
        /// <param name="marker">The marker.</param>
        [JSInvokable("Property365GoogleMap.OnMarkerClick")]
        public async System.Threading.Tasks.Task OnMarkerClick(Property365GoogleMapMarker marker)
        {
            await MarkerClick.InvokeAsync(marker);
        }

        /// <inheritdoc />
        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            await base.OnAfterRenderAsync(firstRender);

            var data = Data != null ? Data : markers;

            if (firstRender)
            {
                await JSRuntime.InvokeVoidAsync("Property365Components.createMap", Element, Reference, UniqueID, ApiKey, Zoom, Center,
                     data.Select(m => new { Title = m.Title, Label = m.Label, Position = m.Position }));
            }
            else
            {
                await JSRuntime.InvokeVoidAsync("Property365Components.updateMap", UniqueID, Zoom, Center,
                             data.Select(m => new { Title = m.Title, Label = m.Label, Position = m.Position }));
            }
        }

        /// <inheritdoc />
        public override void Dispose()
        {
            base.Dispose();

            if (IsJSRuntimeAvailable)
            {
                JSRuntime.InvokeVoidAsync("Property365Components.destroyMap", UniqueID);
            }
        }
    }
}
