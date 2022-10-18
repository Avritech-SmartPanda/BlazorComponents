namespace Property365.Web.Components
{
    /// <summary>
    /// Supplies information about a <see cref="Property365Scheduler{TItem}.LoadData" /> event that is being raised.
    /// </summary>
    public class SchedulerLoadDataEventArgs
    {
        /// <summary>
        /// The start of the currently rendered period.
        /// </summary>
        public DateTime Start { get; set; }
        /// <summary>
        /// The start of the currently rendered period.
        /// </summary>
        public DateTime End { get; set; }
    }
}