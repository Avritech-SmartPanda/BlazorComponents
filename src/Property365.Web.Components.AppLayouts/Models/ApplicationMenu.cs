namespace Property365.Web.Components.AppLayouts.Models
{
    public  class ApplicationMenu
    {
        public ApplicationMenu() { 
        
            MenuItems = new List<MenuItem>();
        }
        /// <summary>
        /// 
        /// </summary>
        public IEnumerable<MenuItem> MenuItems { get; set; }
    }
}
