#pragma checksum "C:\source\DP_THA\DistributedProgramming_THA\DP_THA\WebApplication\Pages\Shippings.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "a8292eb623976d8c68a6117f5106de123ebe84e9"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(WebApplication.Pages.Pages_Shippings), @"mvc.1.0.razor-page", @"/Pages/Shippings.cshtml")]
namespace WebApplication.Pages
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
#nullable restore
#line 1 "C:\source\DP_THA\DistributedProgramming_THA\DP_THA\WebApplication\Pages\_ViewImports.cshtml"
using WebApplication;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\source\DP_THA\DistributedProgramming_THA\DP_THA\WebApplication\Pages\_ViewImports.cshtml"
using Microsoft.AspNetCore.Http;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemMetadataAttribute("RouteTemplate", "/Shippings")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"a8292eb623976d8c68a6117f5106de123ebe84e9", @"/Pages/Shippings.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"3e9a93dd7035b19849eb4e5a322e3bc88bb52d9c", @"/Pages/_ViewImports.cshtml")]
    #nullable restore
    public class Pages_Shippings : global::Microsoft.AspNetCore.Mvc.RazorPages.Page
    #nullable disable
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("method", "post", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-page-handler", "UpdateStatus", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        #line hidden
        #pragma warning disable 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        #pragma warning restore 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __backed__tagHelperScopeManager = null;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __tagHelperScopeManager
        {
            get
            {
                if (__backed__tagHelperScopeManager == null)
                {
                    __backed__tagHelperScopeManager = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager(StartTagHelperWritingScope, EndTagHelperWritingScope);
                }
                return __backed__tagHelperScopeManager;
            }
        }
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 3 "C:\source\DP_THA\DistributedProgramming_THA\DP_THA\WebApplication\Pages\Shippings.cshtml"
  
    ViewData["Title"] = "Shippings";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<h2>Shippings</h2>\r\n\r\n");
#nullable restore
#line 9 "C:\source\DP_THA\DistributedProgramming_THA\DP_THA\WebApplication\Pages\Shippings.cshtml"
 if (Model.ShippingList != null && Model.ShippingList.Any())
{

#line default
#line hidden
#nullable disable
            WriteLiteral(@"    <table class=""table"">
        <thead>
            <tr>
                <th>Shipping ID</th>
                <th>Order ID</th>
                <th>Shipping Date</th>
                <th></th>
            </tr>
        </thead>
        <tbody>
");
#nullable restore
#line 21 "C:\source\DP_THA\DistributedProgramming_THA\DP_THA\WebApplication\Pages\Shippings.cshtml"
             foreach (var shipping in Model.ShippingList)
            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                <tr>\r\n                    <td>");
#nullable restore
#line 24 "C:\source\DP_THA\DistributedProgramming_THA\DP_THA\WebApplication\Pages\Shippings.cshtml"
                   Write(shipping.Id);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                    <td>");
#nullable restore
#line 25 "C:\source\DP_THA\DistributedProgramming_THA\DP_THA\WebApplication\Pages\Shippings.cshtml"
                   Write(shipping.OrderId);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                    <td>");
#nullable restore
#line 26 "C:\source\DP_THA\DistributedProgramming_THA\DP_THA\WebApplication\Pages\Shippings.cshtml"
                   Write(shipping.ShippingDate);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                    <td>\r\n                        ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "a8292eb623976d8c68a6117f5106de123ebe84e95990", async() => {
                WriteLiteral("\r\n                            <input type=\"hidden\" name=\"orderId\"");
                BeginWriteAttribute("value", " value=\"", 840, "\"", 865, 1);
#nullable restore
#line 29 "C:\source\DP_THA\DistributedProgramming_THA\DP_THA\WebApplication\Pages\Shippings.cshtml"
WriteAttributeValue("", 848, shipping.OrderId, 848, 17, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(" />\r\n                            <button type=\"submit\" class=\"btn btn-primary\">Update Status</button>\r\n                        ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Method = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.PageHandler = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                    </td>\r\n                </tr>\r\n");
#nullable restore
#line 34 "C:\source\DP_THA\DistributedProgramming_THA\DP_THA\WebApplication\Pages\Shippings.cshtml"
            }

#line default
#line hidden
#nullable disable
            WriteLiteral("        </tbody>\r\n    </table>\r\n");
#nullable restore
#line 37 "C:\source\DP_THA\DistributedProgramming_THA\DP_THA\WebApplication\Pages\Shippings.cshtml"
}
else
{

#line default
#line hidden
#nullable disable
            WriteLiteral("    <p>No shipping details found.</p>\r\n");
#nullable restore
#line 41 "C:\source\DP_THA\DistributedProgramming_THA\DP_THA\WebApplication\Pages\Shippings.cshtml"
}

#line default
#line hidden
#nullable disable
        }
        #pragma warning restore 1998
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<ShippingsModel> Html { get; private set; } = default!;
        #nullable disable
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<ShippingsModel> ViewData => (global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<ShippingsModel>)PageContext?.ViewData;
        public ShippingsModel Model => ViewData.Model;
    }
}
#pragma warning restore 1591