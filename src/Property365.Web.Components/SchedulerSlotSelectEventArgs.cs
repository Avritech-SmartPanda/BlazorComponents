namespace Property365.Web.Components
{
    /// <summary>
    /// Supplies information about a <see cref="Property365Scheduler{TItem}.SlotSelect" /> event that is being raised.
    /// </summary>
    public class SchedulerSlotSelectEventArgs
    {
        /// <summary>
        /// The start of the slot.
        /// </summary>
        public DateTime Start { get; set; }
        /// <summary>
        /// The end of the slot.
        /// </summary>
        public DateTime End { get; set; }
    }
}