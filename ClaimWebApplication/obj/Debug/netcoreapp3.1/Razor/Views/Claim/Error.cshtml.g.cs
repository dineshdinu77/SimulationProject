#pragma checksum "C:\Users\deepa\Desktop\New folder\ClaimWebApplication\Views\Claim\Error.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "393321317e6b56189e572829296e3e6d30014ee8"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Claim_Error), @"mvc.1.0.view", @"/Views/Claim/Error.cshtml")]
namespace AspNetCore
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
#line 1 "C:\Users\deepa\Desktop\New folder\ClaimWebApplication\Views\_ViewImports.cshtml"
using ClaimWebApplication;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\deepa\Desktop\New folder\ClaimWebApplication\Views\_ViewImports.cshtml"
using ClaimWebApplication.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"393321317e6b56189e572829296e3e6d30014ee8", @"/Views/Claim/Error.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"a69e5708edf22e776c18631dc9d0986d542a29ee", @"/Views/_ViewImports.cshtml")]
    public class Views_Claim_Error : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("<h1>Error In Adding Claim Details</h1>\r\n<a class=\"btn btn-success\"");
            BeginWriteAttribute("href", " href=\"", 196, "\"", 241, 1);
#nullable restore
#line 7 "C:\Users\deepa\Desktop\New folder\ClaimWebApplication\Views\Claim\Error.cshtml"
WriteAttributeValue("", 203, Url.Action("AddClaimDetails","Claim"), 203, 38, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">Add claim Details</a>\r\n\r\n<a class=\"btn btn-success\"");
            BeginWriteAttribute("href", " href=\"", 294, "\"", 329, 1);
#nullable restore
#line 9 "C:\Users\deepa\Desktop\New folder\ClaimWebApplication\Views\Claim\Error.cshtml"
WriteAttributeValue("", 301, Url.Action("Logout","Auth"), 301, 28, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">Sign out</a>\r\n");
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<dynamic> Html { get; private set; }
    }
}
#pragma warning restore 1591