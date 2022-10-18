using Bunit;
using Xunit;

namespace Property365.Web.Components.Tests
{
    public class BreadCrumbTests
    {
        [Fact]
        public void BreadCrumb_Renders_Items()
        {
            using var ctx = new TestContext();

            var component = ctx.RenderComponent<Property365BreadCrumb>();

            component.SetParametersAndRender(parameters =>
            {
                parameters.Add(c => c.ChildContent, builder =>
          {
              builder.OpenComponent<Property365BreadCrumbItem>(0);
              builder.AddAttribute(1, nameof(Property365BreadCrumbItem.Text), "Test");
              builder.CloseComponent();
          });
            });
            //@"<Property365BreadCrumbItem Text=""Test"" />"
            Assert.Contains(@"class=""rz-breadcrumb-item", component.Markup);
            Assert.Contains(">Test</", component.Markup);
        }

        [Fact]
        public void BreadCrumb_Renders_Icon()
        {
            using var ctx = new TestContext();

            var component = ctx.RenderComponent<Property365BreadCrumb>();

            component.SetParametersAndRender(parameters =>
            {
                parameters.Add(c => c.ChildContent, builder =>
          {
              builder.OpenComponent<Property365BreadCrumbItem>(0);
              builder.AddAttribute(1, nameof(Property365BreadCrumbItem.Text), "Test");
              builder.AddAttribute(2, nameof(Property365BreadCrumbItem.Icon), "add");
              builder.CloseComponent();
          });
            });

            //@"<Property365BreadCrumbItem Text=""Test"" />"
            Assert.Contains("<i", component.Markup);
            Assert.Contains(">add</i>", component.Markup);
        }

        [Fact]
        public void BreadCrumb_Renders_Link()
        {
            using var ctx = new TestContext();

            var component = ctx.RenderComponent<Property365BreadCrumb>();

            component.SetParametersAndRender(parameters =>
            {
                parameters.Add(c => c.ChildContent, builder =>
                {
                    builder.OpenComponent<Property365BreadCrumbItem>(0);
                    builder.AddAttribute(1, nameof(Property365BreadCrumbItem.Text), "Test");
                    builder.AddAttribute(2, nameof(Property365BreadCrumbItem.Icon), "add");
                    builder.AddAttribute(3, nameof(Property365BreadCrumbItem.Path), "/badge");
                    builder.CloseComponent();
                });
            });

            //@"<Property365BreadCrumbItem Text=""Test"" />"
            Assert.Contains("<i", component.Markup);
            Assert.Contains(">add</i>", component.Markup);
            Assert.Contains("<a href=\"/badge", component.Markup);
        }
    }
}
