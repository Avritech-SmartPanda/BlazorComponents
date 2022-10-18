using System.Diagnostics.CodeAnalysis;

namespace Property365.Web.Components.AppLayouts.Models
{
    public  class MenuItem
    {
        public MenuItem() {

            this.Items = new List<MenuItem>();

        }

        /// <summary>
        /// required The unique name of the menu item.
        /// </summary>
        [NotNull]
        public string Name { get; set; }

        /// <summary>
        /// required Display name/text of the menu item.You can localize this as shown before
        /// </summary>
        [NotNull]
        public string DisplayName { get; set; }

        /// <summary>
        /// : The URL of the menu item.
        /// </summary>
        [NotNull]
        public string Url { get; set; }

        /// <summary>
        /// Can be used to disable this menu item.
        /// </summary>
        public bool IsDisabled { get; set; }

        /// <summary>
        ///  An icon name.Free Font Awesome icon classes are supported out of the box.
        ///  Example: fa fa-book.You can use any CSS font icon class as 
        ///  long as you include the necessary CSS files to your application.
        /// </summary>
        public string Icon { get; set; }

        /// <summary>
        /// The order of the menu item.Default value is 1000. Items are sorted by the adding order 
        /// unless you specify an order value.
        /// </summary>
        public int Order { get; set; }

        /// <summary>
        /// A custom object that you can associate to the menu item and use it while rendering the menu item.
        /// </summary>
        public object CustomData { get; set; }

        /// <summary>
        /// Target of the menu item.Can be null (default), "_blank", 
        /// "_self", "_parent", "_top" or a frame name for web applications.
        /// </summary>
        [NotNull]
        public string Target { get; set; }

        /// <summary>
        /// Can be used to render the element with a specific HTML id attribute.
        /// </summary>
        public string ElementId { get; set; }

        /// <summary>
        /// Additional string classes for the menu item.
        /// </summary>
        public string CssClass { get; set; } 

        /// <summary>
        /// 
        /// </summary>
        public IEnumerable<MenuItem> Items { get; set; }

        /// <summary>
        /// Returns true if this menu item has no child <see cref="Items"/>.
        /// </summary>
        public bool IsLeaf => Items == null;


        /// <summary>
        /// Returns true if this menu child items<see cref="Items"/>.
        /// </summary>
        public bool HasItems => Items==null? false: Items.Any();

        private string GetDefaultElementId()
        {
            return "MenuItem_" + Name;
        }

        public override string ToString()
        {
            return $"[ApplicationMenuItem] Name = {Name}";
        }
    }
}
