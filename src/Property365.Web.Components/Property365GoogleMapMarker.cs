using Microsoft.AspNetCore.Components;

namespace Property365.Web.Components
{
    /// <summary>
    /// Property365GoogleMapMarker component.
    /// </summary>
    public class Property365GoogleMapMarker : Property365Component
    {
        /// <summary>
        /// Gets or sets the position.
        /// </summary>
        /// <value>The position.</value>
        [Parameter]
        public GoogleMapPosition Position { get; set; } = new GoogleMapPosition() { Lat = 0, Lng = 0 };

        /// <summary>
        /// Gets or sets the title.
        /// </summary>
        /// <value>The title.</value>
        [Parameter]
        public string Title { get; set; }

        /// <summary>
        /// Gets or sets the label.
        /// </summary>
        /// <value>The label.</value>
        [Parameter]
        public string Label { get; set; }

        Property365GoogleMap _map;

        /// <summary>
        /// Gets or sets the map.
        /// </summary>
        /// <value>The map.</value>
        [CascadingParameter]
        public Property365GoogleMap Map
        {
            get
            {
                return _map;
            }
            set
            {
                if (_map != value)
                {
                    _map = value;
                    _map.AddMarker(this);
                }
            }
        }

        /// <summary>
        /// Disposes this instance.
        /// </summary>
        public override void Dispose()
        {
            base.Dispose();
            Map?.RemoveMarker(this);
        }
    }
}