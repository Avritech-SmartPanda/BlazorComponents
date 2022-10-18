using Bunit;
using System.Collections.Generic;
using Xunit;

namespace Property365.Web.Components.Tests
{
    public class PagerTests
    {
        [Fact]
        public void Property365Pager_AutoHide_If_Count_Is_Less_Than_PageSize()
        {
            using var ctx = new TestContext();
            ctx.JSInterop.Mode = JSRuntimeMode.Loose;
            ctx.JSInterop.SetupModule("_content/Property365.Web.Components/Property365.Web.Components.js");

            var component = ctx.RenderComponent<Property365Pager>(parameters =>
            {
                parameters.Add<int>(p => p.PageSize, 20);
                parameters.Add<int>(p => p.Count, 100);
            });

            component.Render();

            Assert.Contains(@$"rz-paginator", component.Markup);

            component.SetParametersAndRender(parameters =>
            {
                parameters.Add<int>(p => p.PageSize, 101);
                parameters.Add<int>(p => p.Count, 100);
            });
            Assert.DoesNotContain(@$"rz-paginator", component.Markup);
        }

        [Fact]
        public void Property365Pager_Dont_AutoHide_If_PageSizeOptions_Specified()
        {
            using var ctx = new TestContext();
            ctx.JSInterop.Mode = JSRuntimeMode.Loose;
            ctx.JSInterop.SetupModule("_content/Property365.Web.Components/Property365.Web.Components.js");

            var component = ctx.RenderComponent<Property365Pager>(parameters =>
            {
                parameters.Add<int>(p => p.PageSize, 101);
                parameters.Add<int>(p => p.Count, 100);
                parameters.Add<IEnumerable<int>>(p => p.PageSizeOptions, new int[] { 3, 7, 15 });
            });

            component.Render();

            Assert.Contains(@$"rz-paginator", component.Markup);
            Assert.Contains(@$"dropdown-trigger", component.Markup);
        }

        [Fact]
        public async void Property365Pager_Renders_Summary() {
            using var ctx = new TestContext();
            ctx.JSInterop.Mode = JSRuntimeMode.Loose;
            ctx.JSInterop.SetupModule("_content/Property365.Web.Components/Property365.Web.Components.js");

            var component = ctx.RenderComponent<Property365Pager>(parameters => {
                parameters.Add<int>(p => p.PageSize, 10);
                parameters.Add<int>(p => p.Count, 100);
                parameters.Add<bool>(p => p.ShowPagingSummary, true);
            });
            await component.Instance.GoToPage(2);
            component.Render();

            Assert.Contains(@$"rz-paginator-summary", component.Markup); 
            Assert.Contains(@$"Page 3 of 10 (100 items)", component.Markup); 
            
            component.SetParametersAndRender(parameters => {
                parameters.Add<bool>(p => p.ShowPagingSummary, false);
            });
            Assert.DoesNotContain(@$"rz-paginator-summary", component.Markup);
        }

    }
}
