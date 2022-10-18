using Bunit;
using Xunit;

namespace Property365.Web.Components.Tests
{
    public class PasswordTests
    {
        [Fact]
        public void Password_Renders_CssClass()
        {
            using var ctx = new TestContext();

            var component = ctx.RenderComponent<Property365Password>();

            Assert.Contains(@$"rz-textbox", component.Markup);
        }

        [Fact]
        public void Password_Renders_ValueParameter()
        {
            using var ctx = new TestContext();

            var component = ctx.RenderComponent<Property365Password>();

            var value = "Test";

            component.SetParametersAndRender(parameters => parameters.Add(p => p.Value, value));

            Assert.Contains(@$"value=""{value}""", component.Markup);
        }

        [Fact]
        public void Password_Renders_StyleParameter()
        {
            using var ctx = new TestContext();

            var component = ctx.RenderComponent<Property365Password>();

            var value = "width:20px";

            component.SetParametersAndRender(parameters => parameters.Add(p => p.Style, value));

            Assert.Contains(@$"style=""{value}""", component.Markup);
        }

        [Fact]
        public void Password_Renders_NameParameter()
        {
            using var ctx = new TestContext();

            var component = ctx.RenderComponent<Property365Password>();

            var value = "Test";

            component.SetParametersAndRender(parameters => parameters.Add(p => p.Name, value));

            Assert.Contains(@$"name=""{value}""", component.Markup);
        }

        [Fact]
        public void Password_Renders_TabIndexParameter()
        {
            using var ctx = new TestContext();

            var component = ctx.RenderComponent<Property365Password>();

            var value = 1;

            component.SetParametersAndRender(parameters => parameters.Add<int>(p => p.TabIndex, value));

            Assert.Contains(@$"tabindex=""{value}""", component.Markup);
        }

        [Fact]
        public void Password_Renders_PlaceholderParameter()
        {
            using var ctx = new TestContext();

            var component = ctx.RenderComponent<Property365Password>();

            var value = "Test";

            component.SetParametersAndRender(parameters => parameters.Add(p => p.Placeholder, value));

            Assert.Contains(@$"placeholder=""{value}""", component.Markup);
        }

        [Fact]
        public void Password_Renders_DisabledParameter()
        {
            using var ctx = new TestContext();

            var component = ctx.RenderComponent<Property365Password>();

            component.SetParametersAndRender(parameters => parameters.Add<bool>(p => p.Disabled, true));

            Assert.Contains(@$"disabled", component.Markup);
            Assert.Contains(@$"rz-state-disabled", component.Markup);
        }

        [Fact]
        public void Password_Renders_ReadOnlyParameter()
        {
            using var ctx = new TestContext();

            var component = ctx.RenderComponent<Property365Password>();

            var value = true;

            component.SetParametersAndRender(parameters => parameters.Add<bool>(p => p.ReadOnly, value));

            Assert.Contains(@$"readonly", component.Markup);
        }

        [Fact]
        public void Password_Renders_AutoCompleteParameter()
        {
            using var ctx = new TestContext();

            var component = ctx.RenderComponent<Property365Password>();

            component.SetParametersAndRender(parameters => parameters.Add<bool>(p => p.AutoComplete, false));

            Assert.Contains(@$"autocomplete=""new-password""", component.Markup);

            component.SetParametersAndRender(parameters => parameters.Add<bool>(p => p.AutoComplete, true));

            Assert.Contains(@$"autocomplete=""on""", component.Markup);
        }

        [Fact]
        public void Password_Renders_UnmatchedParameter()
        {
            using var ctx = new TestContext();

            var component = ctx.RenderComponent<Property365Password>();

            component.SetParametersAndRender(parameters => parameters.AddUnmatched("autofocus", ""));

            Assert.Contains(@$"autofocus", component.Markup);
        }
        
        [Fact]
        public void Password_Raises_ChangedEvent()
        {
            using var ctx = new TestContext();

            var component = ctx.RenderComponent<Property365Password>();

            var raised = false;
            var value = "Test";
            object newValue = null;

            component.SetParametersAndRender(parameters => parameters.Add(p => p.Change, args => { raised = true; newValue = args; }));

            component.Find("input").Change(value);

            Assert.True(raised);
            Assert.True(object.Equals(value, newValue));
        }

        [Fact]
        public void Password_Raises_ValueChangedEvent()
        {
            using var ctx = new TestContext();

            var component = ctx.RenderComponent<Property365Password>();

            var raised = false;
            var value = "Test";
            object newValue = null;

            component.SetParametersAndRender(parameters => parameters.Add(p => p.ValueChanged, args => { raised = true; newValue = args; }));

            component.Find("input").Change(value);

            Assert.True(raised);
            Assert.True(object.Equals(value, newValue));
        }
    }
}