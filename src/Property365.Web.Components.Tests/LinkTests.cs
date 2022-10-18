using Bunit;
using Xunit;

namespace Property365.Web.Components.Tests
{
    public class LinkTests
    {
        [Fact]
        public void Link_Renders_StyleParameter()
        {
            using var ctx = new TestContext();

            var component = ctx.RenderComponent<Property365Link>();

            var value = "width:20px";

            component.SetParametersAndRender(parameters => parameters.Add(p => p.Style, value));

            Assert.Contains(@$"style=""{value}""", component.Markup);
        }

        [Fact]
        public void Link_Renders_TextParameter()
        {
            using var ctx = new TestContext();

            var component = ctx.RenderComponent<Property365Link>();

            var text = "Test";

            component.SetParametersAndRender(parameters => parameters.Add(p => p.Text, text));

            Assert.Contains(@$">{text}</span>", component.Markup);
            Assert.Contains(@$"class=""rz-link-text""", component.Markup);
        }

        [Fact]
        public void Link_Renders_IconParameter()
        {
            using var ctx = new TestContext();

            var component = ctx.RenderComponent<Property365Link>();

            var icon = "Test";

            component.SetParametersAndRender(parameters => parameters.Add(p => p.Icon, icon));

            Assert.Contains(@$"<i class=""rzi"">{icon}</i>", component.Markup);
        }

        [Fact]
        public void Link_Renders_PathParameter()
        {
            using var ctx = new TestContext();

            var component = ctx.RenderComponent<Property365Link>();

            var path = "Test";

            component.SetParametersAndRender(parameters => parameters.Add(p => p.Path, path));

            Assert.Contains(@$"<a href=""{path}""", component.Markup);
        }

        [Fact]
        public void Link_Renders_TargetParameter()
        {
            using var ctx = new TestContext();

            var component = ctx.RenderComponent<Property365Link>();

            var target = "_blank";

            component.SetParametersAndRender(parameters => parameters.Add(p => p.Target, target));

            Assert.Contains(@$"target=""{target}""", component.Markup);
        }

        [Fact]
        public void Icon_Renders_UnmatchedParameter()
        {
            using var ctx = new TestContext();

            var component = ctx.RenderComponent<Property365Icon>();

            component.SetParametersAndRender(parameters => parameters.AddUnmatched("autofocus", ""));

            Assert.Contains(@$"autofocus", component.Markup);
        }
    }
}
