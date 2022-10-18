using Bunit;
using Xunit;

namespace Property365.Web.Components.Tests
{
    public class CheckBoxTests
    {
        [Fact]
        public void CheckBox_Renders_CssClasses()
        {
            using var ctx = new TestContext();

            var component = ctx.RenderComponent<Property365CheckBox<bool>>();

            component.Render();

            Assert.Contains(@$"inline-block align-middle relative w-5 min-w-5 h-5", component.Markup);
            Assert.Contains(@$"chkbox-box", component.Markup);
        }

        [Fact]
        public void CheckBox_Renders_ValueParameter()
        {
            using var ctx = new TestContext();

            var component = ctx.RenderComponent<Property365CheckBox<bool?>>();

            var value = true;

            component.SetParametersAndRender(parameters => parameters.Add<bool?>(p => p.Value, value));

            Assert.Contains(@$"state-active", component.Markup);
            Assert.Contains(@$"rzi-check", component.Markup);

            component.SetParametersAndRender(parameters => parameters.Add<bool?>(p => p.Value, !value));

            Assert.DoesNotContain(@$"state-active", component.Markup);
            Assert.DoesNotContain(@$"rzi-check", component.Markup);

            component.SetParametersAndRender(parameters => parameters.Add<bool?>(p => p.Value, null));

            Assert.Contains(@$"state-active", component.Markup);
            Assert.Contains(@$"rzi-times", component.Markup);
        }

        [Fact]
        public void CheckBox_Renders_StyleParameter()
        {
            using var ctx = new TestContext();

            var component = ctx.RenderComponent<Property365CheckBox<bool>>();

            var value = "width:20px";

            component.SetParametersAndRender(parameters => parameters.Add(p => p.Style, value));

            Assert.Contains(@$"style=""{value}""", component.Markup);
        }

        [Fact]
        public void CheckBox_Renders_UnmatchedParameter()
        {
            using var ctx = new TestContext();

            var component = ctx.RenderComponent<Property365CheckBox<bool>>();

            component.SetParametersAndRender(parameters => parameters.AddUnmatched("autofocus", ""));

            Assert.Contains(@$"autofocus", component.Markup);
        }


        [Fact]
        public void CheckBox_Renders_NameParameter()
        {
            using var ctx = new TestContext();

            var component = ctx.RenderComponent<Property365CheckBox<bool>>();

            var value = "Test";

            component.SetParametersAndRender(parameters => parameters.Add(p => p.Name, value));

            Assert.Contains(@$"name=""{value}""", component.Markup);
        }

        [Fact]
        public void CheckBox_Renders_DisabledParameter()
        {
            using var ctx = new TestContext();

            var component = ctx.RenderComponent<Property365CheckBox<bool>>();

            component.SetParametersAndRender(parameters => parameters.Add<bool>(p => p.Disabled, true));

            Assert.Contains(@$"disabled", component.Markup);
            Assert.Contains(@$"rz-state-disabled", component.Markup);
        }

        [Fact]
        public void CheckBox_Raises_ChangedEvent()
        {
            using var ctx = new TestContext();

            var component = ctx.RenderComponent<Property365CheckBox<bool>>();

            var raised = false;

            component.SetParametersAndRender(parameters => parameters.Add(p => p.Change, args => { raised = true; }));

            component.Find("div.chkbox-box").Click();

            Assert.True(raised);
        }

        [Fact]
        public void CheckBox_Raises_ValueChangedEvent()
        {
            using var ctx = new TestContext();

            var component = ctx.RenderComponent<Property365CheckBox<bool>>();

            var raised = false;

            component.SetParametersAndRender(parameters => parameters.Add(p => p.ValueChanged, args => { raised = true; }));

            component.Find("div.chkbox-box").Click();

            Assert.True(raised);
        }

        [Fact]
        public void CheckBox_Renders_TriStateParameter()
        {
            using var ctx = new TestContext();

            var component = ctx.RenderComponent<Property365CheckBox<bool?>>();

            component.SetParametersAndRender(parameters => parameters.Add<bool>(p => p.TriState, true));


            component.Find("div.chkbox-box").Click();

            component.Render();

            Assert.Contains(@$"state-active", component.Markup);
            Assert.Contains(@$"rzi-check", component.Markup);

            component.Find("div.chkbox-box").Click();

            component.Render();

            Assert.DoesNotContain(@$"state-active", component.Markup);
            Assert.DoesNotContain(@$"rzi-check", component.Markup);

            component.Find("div.chkbox-box").Click();

            Assert.Contains(@$"state-active", component.Markup);
            Assert.Contains(@$"rzi-times", component.Markup);
        }
    }
}
