#pragma checksum "/Users/patliben/Desktop/myproject/CoreWiki/CoreWiki/Pages/Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "128d6b24d90bdbaebc780faf905810075f6830c1"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(CoreWiki.Pages.Pages_Index), @"mvc.1.0.razor-page", @"/Pages/Index.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.RazorPages.Infrastructure.RazorPageAttribute(@"/Pages/Index.cshtml", typeof(CoreWiki.Pages.Pages_Index), null)]
namespace CoreWiki.Pages
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
#line 1 "/Users/patliben/Desktop/myproject/CoreWiki/CoreWiki/Pages/_ViewImports.cshtml"
using CoreWiki;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"128d6b24d90bdbaebc780faf905810075f6830c1", @"/Pages/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"47707e90384320186ebec9ea2ac07aa1df27304a", @"/Pages/_ViewImports.cshtml")]
    public class Pages_Index : global::Microsoft.AspNetCore.Mvc.RazorPages.Page
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#line 3 "/Users/patliben/Desktop/myproject/CoreWiki/CoreWiki/Pages/Index.cshtml"
  
    ViewData["Title"] = "Home page";

#line default
#line hidden
            BeginContext(71, 701, true);
            WriteLiteral(@"<style>
      table {
          font-family: arial, sans-serif;
          border-collapse: collapse;
          width: 100%;

    }

       td, th {
          border: 1px solid #dddddd;
          text-align: left;
          padding: 8px;

    }

       tr:nth-child(even) {
          background-color: #dddddd;

    }


</style> <div>     <a href=""/firstpage"">Home</a> <table>     <tr>         <h1>My Wikipedia Pages</h1>     </tr>     <tr>         <td><a href=""/RMS_Baltic"">1st Wiki Page</a></td>     </tr>     <tr>         <td><a href=""/Manipulator"">2nd Wiki Page</a></td>     </tr>     <tr>         <td><a href=""/Elektra_Records"">3rd Wiki Page</a></td>     </tr> </table> </div>");
            EndContext();
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IndexModel> Html { get; private set; }
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<IndexModel> ViewData => (global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<IndexModel>)PageContext?.ViewData;
        public IndexModel Model => ViewData.Model;
    }
}
#pragma warning restore 1591
