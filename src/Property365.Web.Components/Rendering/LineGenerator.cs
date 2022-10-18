using System.Text;

namespace Property365.Web.Components.Rendering
{
    /// <summary>
    /// Class LineGenerator.
    /// Implements the <see cref="Property365.Web.Components.Rendering.IPathGenerator" />
    /// </summary>
    /// <seealso cref="Property365.Web.Components.Rendering.IPathGenerator" />
    public class LineGenerator : IPathGenerator
    {
        /// <summary>
        /// Pathes the specified data.
        /// </summary>
        /// <param name="data">The data.</param>
        /// <returns>System.String.</returns>
        public string Path(IEnumerable<Point> data)
        {
            var path = new StringBuilder();
            var start = true;

            foreach (var item in data)
            {
                var x = item.X;
                var y = item.Y;

                if (start)
                {
                    start = false;
                }
                else
                {
                    path.Append("L ");
                }

                path.Append($"{x.ToInvariantString()} {y.ToInvariantString()} ");
            }

            return path.ToString();
        }
    }
}
