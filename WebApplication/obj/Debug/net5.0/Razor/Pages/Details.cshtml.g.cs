#pragma checksum "C:\source\DP_THA\DistributedProgramming_THA\DP_THA\WebApplication\Pages\Details.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "db6e54edfc159bf7986dd7ab5a1938ec30b49ed7"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(WebApplication.Pages.Pages_Details), @"mvc.1.0.razor-page", @"/Pages/Details.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"db6e54edfc159bf7986dd7ab5a1938ec30b49ed7", @"/Pages/Details.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"3e9a93dd7035b19849eb4e5a322e3bc88bb52d9c", @"/Pages/_ViewImports.cshtml")]
    #nullable restore
    public class Pages_Details : global::Microsoft.AspNetCore.Mvc.RazorPages.Page
    #nullable disable
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 3 "C:\source\DP_THA\DistributedProgramming_THA\DP_THA\WebApplication\Pages\Details.cshtml"
  
    ViewData["Title"] = "User Details";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<h2>");
#nullable restore
#line 7 "C:\source\DP_THA\DistributedProgramming_THA\DP_THA\WebApplication\Pages\Details.cshtml"
Write(ViewData["Title"]);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h2>\r\n\r\n");
#nullable restore
#line 9 "C:\source\DP_THA\DistributedProgramming_THA\DP_THA\WebApplication\Pages\Details.cshtml"
 if (Model.User != null)
{

#line default
#line hidden
#nullable disable
            WriteLiteral("    <div>\r\n        <label>First Name:</label>\r\n        <p>");
#nullable restore
#line 13 "C:\source\DP_THA\DistributedProgramming_THA\DP_THA\WebApplication\Pages\Details.cshtml"
      Write(Model.User.FirstName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n    </div>\r\n    <div>\r\n        <label>Last Name:</label>\r\n        <p>");
#nullable restore
#line 17 "C:\source\DP_THA\DistributedProgramming_THA\DP_THA\WebApplication\Pages\Details.cshtml"
      Write(Model.User.LastName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n    </div>\r\n    <div>\r\n        <label>Email:</label>\r\n        <p>");
#nullable restore
#line 21 "C:\source\DP_THA\DistributedProgramming_THA\DP_THA\WebApplication\Pages\Details.cshtml"
      Write(Model.User.Email);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n    </div>\r\n");
#nullable restore
#line 23 "C:\source\DP_THA\DistributedProgramming_THA\DP_THA\WebApplication\Pages\Details.cshtml"
}
else
{

#line default
#line hidden
#nullable disable
            WriteLiteral("    <p>No user details available.</p>\r\n");
#nullable restore
#line 27 "C:\source\DP_THA\DistributedProgramming_THA\DP_THA\WebApplication\Pages\Details.cshtml"
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<DetailsModel> Html { get; private set; } = default!;
        #nullable disable
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<DetailsModel> ViewData => (global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<DetailsModel>)PageContext?.ViewData;
        public DetailsModel Model => ViewData.Model;
    }
}
#pragma warning restore 1591
