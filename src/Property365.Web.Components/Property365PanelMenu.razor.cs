using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Routing;

namespace Property365.Web.Components
{
    /// <summary>
    /// Property365PanelMenu component.
    /// </summary>
    /// <example>
    /// <code>
    /// &lt;Property365PanelMenu&gt;
    ///     &lt;Property365PanelMenuItem Text="Data"&gt;
    ///         &lt;Property365PanelMenuItem Text="Orders" Path="orders" /&gt;
    ///         &lt;Property365PanelMenuItem Text="Employees" Path="employees" /&gt;
    ///     &lt;/Property365PanelMenuItemItem&gt;
    /// &lt;/Property365PanelMenu&gt;
    /// </code>
    /// </example>
    public partial class Property365PanelMenu : Property365ComponentWithChildren
    {
        /// <summary>
        /// Gets or sets the click callback.
        /// </summary>
        /// <value>The click callback.</value>
        [Parameter]
        public EventCallback<MenuItemEventArgs> Click { get; set; }

        /// <summary>
        /// Gets or sets a value representing the URL matching behavior.
        /// </summary>
        [Parameter]
        public NavLinkMatch Match { get; set; }

        List<Property365PanelMenuItem> items = new List<Property365PanelMenuItem>();

        /// <summary>
        /// Adds the item.
        /// </summary>
        /// <param name="item">The item.</param>
        public void AddItem(Property365PanelMenuItem item)
        {
            if (items.IndexOf(item) == -1)
            {
                items.Add(item);
                SelectItem(item);
                StateHasChanged();
            }
        }

        /// <inheritdoc />
        protected override void OnInitialized()
        {
            UriHelper.LocationChanged += UriHelper_OnLocationChanged;
        }

        private void UriHelper_OnLocationChanged(object sender, Microsoft.AspNetCore.Components.Routing.LocationChangedEventArgs e)
        {
            foreach (var item in items)
            {
                SelectItem(item);
            }
        }

        /// <inheritdoc />
        public override void Dispose()
        {
            base.Dispose();
            UriHelper.LocationChanged -= UriHelper_OnLocationChanged;
        }

        bool ShouldMatch(string url)
        {
            if (string.IsNullOrEmpty(url))
            {
                return false;
            }

            var currentAbsoluteUrl = UriHelper.ToAbsoluteUri(UriHelper.Uri).AbsoluteUri;
            var absoluteUrl = UriHelper.ToAbsoluteUri(url).AbsoluteUri;

            if (EqualsHrefExactlyOrIfTrailingSlashAdded(absoluteUrl, currentAbsoluteUrl))
            {
                return true;
            }

            if (url == "/")
            {
                return false;
            }

            if (Match == NavLinkMatch.Prefix
                && IsStrictlyPrefixWithSeparator(currentAbsoluteUrl, absoluteUrl))
            {
                return true;
            }

            return false;
        }

        private static bool EqualsHrefExactlyOrIfTrailingSlashAdded(string absoluteUrl, string currentAbsoluteUrl)
        {
            if (string.Equals(currentAbsoluteUrl, absoluteUrl, StringComparison.OrdinalIgnoreCase))
            {
                return true;
            }

            if (currentAbsoluteUrl.Length == absoluteUrl.Length - 1)
            {
                if (absoluteUrl[absoluteUrl.Length - 1] == '/'
                    && absoluteUrl.StartsWith(currentAbsoluteUrl, StringComparison.OrdinalIgnoreCase))
                {
                    return true;
                }
            }

            return false;
        }

        private static bool IsSeparator(char c)
        {
            return c == '?' || c == '/';
        }

        private static bool IsStrictlyPrefixWithSeparator(string value, string prefix)
        {
            var prefixLength = prefix.Length;
            if (value.Length > prefixLength)
            {
                return value.StartsWith(prefix, StringComparison.OrdinalIgnoreCase)
                    && (
                        prefixLength == 0
                        || IsSeparator(prefix[prefixLength - 1])
                        || IsSeparator(value[prefixLength])
                    );
            }
            else
            {
                return false;
            }
        }

        void SelectItem(Property365PanelMenuItem item)
        {
            var selected = ShouldMatch(item.Path);
            item.Select(selected);
        }

        /// <inheritdoc />
        protected override string GetComponentCssClass()
        {
            return "rz-panel-menu";
        }
    }
}
