#pragma checksum "C:\Users\26046294\source\repos\Arçelik\Arçelik\Views\Home\API.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "4d17d5b45e34853e3273e719c2edf83b294c1215"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_API), @"mvc.1.0.view", @"/Views/Home/API.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Home/API.cshtml", typeof(AspNetCore.Views_Home_API))]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"4d17d5b45e34853e3273e719c2edf83b294c1215", @"/Views/Home/API.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"da355b1c4d9a112d8fab71d96bc7c99f21024003", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_API : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<Arçelik.Models.Applicant_History>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(0, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 2 "C:\Users\26046294\source\repos\Arçelik\Arçelik\Views\Home\API.cshtml"
  
    ViewData["Title"] = "API";

#line default
#line hidden
            BeginContext(41, 2, true);
            WriteLiteral("\r\n");
            EndContext();
            BeginContext(97, 8, true);
            WriteLiteral("\r\n\r\n<h2>");
            EndContext();
            BeginContext(106, 17, false);
#line 9 "C:\Users\26046294\source\repos\Arçelik\Arçelik\Views\Home\API.cshtml"
Write(ViewData["Title"]);

#line default
#line hidden
            EndContext();
            BeginContext(123, 361, true);
            WriteLiteral(@"</h2>
<br />
<br />
<h3>JSON => Table</h3>
<br />
<table style=""width:100%"">
    <tr>
        <th>HId</th>
        <th>Id</th>
        <th>FirstName</th>
        <th>LastName</th>
        <th>Username</th>
        <th>Password</th>
        <th>Age</th>
        <th>Phone</th>
        <th>Extra</th>
        <th>ModificationDate</th>
    </tr>
");
            EndContext();
#line 27 "C:\Users\26046294\source\repos\Arçelik\Arçelik\Views\Home\API.cshtml"
     foreach (var a in Model)
    {

#line default
#line hidden
            BeginContext(522, 30, true);
            WriteLiteral("        <tr>\r\n            <td>");
            EndContext();
            BeginContext(553, 16, false);
#line 30 "C:\Users\26046294\source\repos\Arçelik\Arçelik\Views\Home\API.cshtml"
           Write(a.H_Applicant_Id);

#line default
#line hidden
            EndContext();
            BeginContext(569, 23, true);
            WriteLiteral("</td>\r\n            <td>");
            EndContext();
            BeginContext(593, 14, false);
#line 31 "C:\Users\26046294\source\repos\Arçelik\Arçelik\Views\Home\API.cshtml"
           Write(a.Applicant_Id);

#line default
#line hidden
            EndContext();
            BeginContext(607, 23, true);
            WriteLiteral("</td>\r\n            <td>");
            EndContext();
            BeginContext(631, 9, false);
#line 32 "C:\Users\26046294\source\repos\Arçelik\Arçelik\Views\Home\API.cshtml"
           Write(a.H_FName);

#line default
#line hidden
            EndContext();
            BeginContext(640, 23, true);
            WriteLiteral("</td>\r\n            <td>");
            EndContext();
            BeginContext(664, 9, false);
#line 33 "C:\Users\26046294\source\repos\Arçelik\Arçelik\Views\Home\API.cshtml"
           Write(a.H_LName);

#line default
#line hidden
            EndContext();
            BeginContext(673, 23, true);
            WriteLiteral("</td>\r\n            <td>");
            EndContext();
            BeginContext(697, 12, false);
#line 34 "C:\Users\26046294\source\repos\Arçelik\Arçelik\Views\Home\API.cshtml"
           Write(a.H_Username);

#line default
#line hidden
            EndContext();
            BeginContext(709, 23, true);
            WriteLiteral("</td>\r\n            <td>");
            EndContext();
            BeginContext(733, 12, false);
#line 35 "C:\Users\26046294\source\repos\Arçelik\Arçelik\Views\Home\API.cshtml"
           Write(a.H_Password);

#line default
#line hidden
            EndContext();
            BeginContext(745, 23, true);
            WriteLiteral("</td>\r\n            <td>");
            EndContext();
            BeginContext(769, 7, false);
#line 36 "C:\Users\26046294\source\repos\Arçelik\Arçelik\Views\Home\API.cshtml"
           Write(a.H_Age);

#line default
#line hidden
            EndContext();
            BeginContext(776, 23, true);
            WriteLiteral("</td>\r\n            <td>");
            EndContext();
            BeginContext(800, 9, false);
#line 37 "C:\Users\26046294\source\repos\Arçelik\Arçelik\Views\Home\API.cshtml"
           Write(a.H_Phone);

#line default
#line hidden
            EndContext();
            BeginContext(809, 23, true);
            WriteLiteral("</td>\r\n            <td>");
            EndContext();
            BeginContext(833, 9, false);
#line 38 "C:\Users\26046294\source\repos\Arçelik\Arçelik\Views\Home\API.cshtml"
           Write(a.H_Extra);

#line default
#line hidden
            EndContext();
            BeginContext(842, 23, true);
            WriteLiteral("</td>\r\n            <td>");
            EndContext();
            BeginContext(866, 62, false);
#line 39 "C:\Users\26046294\source\repos\Arçelik\Arçelik\Views\Home\API.cshtml"
           Write(string.Format("{0: dddd, dd MMMM yyyy}", a.H_ModificationDate));

#line default
#line hidden
            EndContext();
            BeginContext(928, 22, true);
            WriteLiteral("</td>\r\n        </tr>\r\n");
            EndContext();
#line 41 "C:\Users\26046294\source\repos\Arçelik\Arçelik\Views\Home\API.cshtml"
    }

#line default
#line hidden
            BeginContext(957, 12, true);
            WriteLiteral("</table>\r\n\r\n");
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
