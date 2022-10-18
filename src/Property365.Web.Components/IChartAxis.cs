namespace Property365.Web.Components
{
    /// <summary>
    /// Common axis API of <see cref="Property365Chart" />
    /// </summary>
    public interface IChartAxis
    {
        /// <summary>
        /// Gets or sets the grid lines configuration of this axis.
        /// </summary>
        Property365GridLines GridLines { get; set; }
    }
}