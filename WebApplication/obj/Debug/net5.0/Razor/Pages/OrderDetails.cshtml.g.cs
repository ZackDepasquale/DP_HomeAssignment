#pragma checksum "C:\source\DP_THA\DistributedProgramming_THA\DP_THA\WebApplication\Pages\OrderDetails.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "f1f780339ad30d888264e121220bcab43297e539"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(WebApplication.Pages.Pages_OrderDetails), @"mvc.1.0.razor-page", @"/Pages/OrderDetails.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemMetadataAttribute("RouteTemplate", "/OrderDetails/{orderId}")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"f1f780339ad30d888264e121220bcab43297e539", @"/Pages/OrderDetails.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"3e9a93dd7035b19849eb4e5a322e3bc88bb52d9c", @"/Pages/_ViewImports.cshtml")]
    #nullable restore
    public class Pages_OrderDetails : global::Microsoft.AspNetCore.Mvc.RazorPages.Page
    #nullable disable
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("method", "post", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-page-handler", "CreatePayment", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
#line 3 "C:\source\DP_THA\DistributedProgramming_THA\DP_THA\WebApplication\Pages\OrderDetails.cshtml"
  
    ViewData["Title"] = "Order Details";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<h2>Order Details</h2>\r\n\r\n");
#nullable restore
#line 9 "C:\source\DP_THA\DistributedProgramming_THA\DP_THA\WebApplication\Pages\OrderDetails.cshtml"
 if (Model.SelectedOrder != null)
{

#line default
#line hidden
#nullable disable
            WriteLiteral("    <h4>Order ID: ");
#nullable restore
#line 11 "C:\source\DP_THA\DistributedProgramming_THA\DP_THA\WebApplication\Pages\OrderDetails.cshtml"
             Write(Model.SelectedOrder.Id);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h4>\r\n    <p>User ID: ");
#nullable restore
#line 12 "C:\source\DP_THA\DistributedProgramming_THA\DP_THA\WebApplication\Pages\OrderDetails.cshtml"
           Write(Model.SelectedOrder.UserId);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n    <p>Order Date: ");
#nullable restore
#line 13 "C:\source\DP_THA\DistributedProgramming_THA\DP_THA\WebApplication\Pages\OrderDetails.cshtml"
              Write(Model.SelectedOrder.OrderDate);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n    <p>Status: ");
#nullable restore
#line 14 "C:\source\DP_THA\DistributedProgramming_THA\DP_THA\WebApplication\Pages\OrderDetails.cshtml"
          Write(Model.SelectedOrder.Status);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n    <p>Total Amount: €");
#nullable restore
#line 15 "C:\source\DP_THA\DistributedProgramming_THA\DP_THA\WebApplication\Pages\OrderDetails.cshtml"
                 Write(Model.SelectedOrder.TotalAmount);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n");
            WriteLiteral("    <h4>Products</h4>\r\n    <ul>\r\n");
#nullable restore
#line 19 "C:\source\DP_THA\DistributedProgramming_THA\DP_THA\WebApplication\Pages\OrderDetails.cshtml"
         foreach (var product in Model.SelectedOrder.Products)
        {

#line default
#line hidden
#nullable disable
            WriteLiteral("            <li>\r\n                <h5>Product ID: ");
#nullable restore
#line 22 "C:\source\DP_THA\DistributedProgramming_THA\DP_THA\WebApplication\Pages\OrderDetails.cshtml"
                           Write(product.Id);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h5>\r\n                <p>Title: ");
#nullable restore
#line 23 "C:\source\DP_THA\DistributedProgramming_THA\DP_THA\WebApplication\Pages\OrderDetails.cshtml"
                     Write(product.Title);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n                <p>Description: ");
#nullable restore
#line 24 "C:\source\DP_THA\DistributedProgramming_THA\DP_THA\WebApplication\Pages\OrderDetails.cshtml"
                           Write(product.Description);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n                <p>Price: €");
#nullable restore
#line 25 "C:\source\DP_THA\DistributedProgramming_THA\DP_THA\WebApplication\Pages\OrderDetails.cshtml"
                      Write(product.Price);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n                <img");
            BeginWriteAttribute("src", " src=\"", 783, "\"", 803, 1);
#nullable restore
#line 26 "C:\source\DP_THA\DistributedProgramming_THA\DP_THA\WebApplication\Pages\OrderDetails.cshtml"
WriteAttributeValue("", 789, product.Image, 789, 14, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" alt=\"Product Image\" width=\"200\" height=\"200\" />\r\n            </li>\r\n");
#nullable restore
#line 28 "C:\source\DP_THA\DistributedProgramming_THA\DP_THA\WebApplication\Pages\OrderDetails.cshtml"
        }

#line default
#line hidden
#nullable disable
            WriteLiteral("    </ul>\r\n");
            WriteLiteral("    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "f1f780339ad30d888264e121220bcab43297e5398217", async() => {
                WriteLiteral("\r\n        <input type=\"hidden\" name=\"userId\"");
                BeginWriteAttribute("value", " value=\"", 1002, "\"", 1037, 1);
#nullable restore
#line 32 "C:\source\DP_THA\DistributedProgramming_THA\DP_THA\WebApplication\Pages\OrderDetails.cshtml"
WriteAttributeValue("", 1010, Model.SelectedOrder.UserId, 1010, 27, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(" />\r\n        <input type=\"hidden\" name=\"orderId\"");
                BeginWriteAttribute("value", " value=\"", 1086, "\"", 1117, 1);
#nullable restore
#line 33 "C:\source\DP_THA\DistributedProgramming_THA\DP_THA\WebApplication\Pages\OrderDetails.cshtml"
WriteAttributeValue("", 1094, Model.SelectedOrder.Id, 1094, 23, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(" />\r\n        <input type=\"hidden\" name=\"amount\"");
                BeginWriteAttribute("value", " value=\"", 1165, "\"", 1205, 1);
#nullable restore
#line 34 "C:\source\DP_THA\DistributedProgramming_THA\DP_THA\WebApplication\Pages\OrderDetails.cshtml"
WriteAttributeValue("", 1173, Model.SelectedOrder.TotalAmount, 1173, 32, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(" />\r\n        <button type=\"submit\" class=\"btn btn-primary\">Create Payment</button>\r\n    ");
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
            WriteLiteral("\r\n");
#nullable restore
#line 37 "C:\source\DP_THA\DistributedProgramming_THA\DP_THA\WebApplication\Pages\OrderDetails.cshtml"
}
else
{

#line default
#line hidden
#nullable disable
            WriteLiteral("    <p>No order found.</p>\r\n");
#nullable restore
#line 41 "C:\source\DP_THA\DistributedProgramming_THA\DP_THA\WebApplication\Pages\OrderDetails.cshtml"
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<OrderDetailsModel> Html { get; private set; } = default!;
        #nullable disable
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<OrderDetailsModel> ViewData => (global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<OrderDetailsModel>)PageContext?.ViewData;
        public OrderDetailsModel Model => ViewData.Model;
    }
}
#pragma warning restore 1591
