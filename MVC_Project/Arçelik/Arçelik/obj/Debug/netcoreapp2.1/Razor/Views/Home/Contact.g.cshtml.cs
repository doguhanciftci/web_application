#pragma checksum "C:\Users\26046294\source\repos\Arçelik\Arçelik\Views\Home\Contact.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "bba05b8ededa01b69ec5d2c42702b0a9314962b3"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_Contact), @"mvc.1.0.view", @"/Views/Home/Contact.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Home/Contact.cshtml", typeof(AspNetCore.Views_Home_Contact))]
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
#line 1 "C:\Users\26046294\source\repos\Arçelik\Arçelik\Views\_ViewImports.cshtml"
using Arçelik;

#line default
#line hidden
#line 2 "C:\Users\26046294\source\repos\Arçelik\Arçelik\Views\_ViewImports.cshtml"
using Arçelik.Models;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"bba05b8ededa01b69ec5d2c42702b0a9314962b3", @"/Views/Home/Contact.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"da355b1c4d9a112d8fab71d96bc7c99f21024003", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_Contact : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<Arçelik.Models.Applicant_History>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#line 1 "C:\Users\26046294\source\repos\Arçelik\Arçelik\Views\Home\Contact.cshtml"
  
    ViewData["Title"] = "Contact";

#line default
#line hidden
            BeginContext(97, 8, true);
            WriteLiteral("\r\n\r\n<h2>");
            EndContext();
            BeginContext(106, 17, false);
#line 7 "C:\Users\26046294\source\repos\Arçelik\Arçelik\Views\Home\Contact.cshtml"
Write(ViewData["Title"]);

#line default
#line hidden
            EndContext();
            BeginContext(123, 185, true);
            WriteLiteral("</h2>\r\n\r\n<br />\r\n<br />\r\n<br />\r\n<h3>Doğuhan Çiftçi</h3>\r\n<h5>Project Engineer</h5>\r\n<br />\r\n<address>\r\n    Arçelik A.Ş.<br />\r\n    Karaağaç Cad. No:2-6 Sütlüce Beyoğlu/İstanbul<br />\r\n");
            EndContext();
            BeginContext(474, 257, true);
            WriteLiteral(@"</address>

<address>
    <strong>Phone:</strong>
    <a href=""tel:+905312366000"">+90 531 236 60 00</a>
    <br />
    <strong>E-mail:</strong>
    <a href=""mailto:doguhan.ciftci@arcelik.com"">doguhan.ciftci@arcelik.com</a>
</address>
<br />
<br />");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<Arçelik.Models.Applicant_History>> Html { get; private set; }
    }
}
#pragma warning restore 1591
