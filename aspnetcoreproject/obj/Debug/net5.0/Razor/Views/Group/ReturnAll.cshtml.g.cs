#pragma checksum "C:\Users\User\Desktop\aspnetcoreproject\aspnetcoreproject\Views\Group\ReturnAll.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "5a51ba334552895a3cddb4f9a330f53ba759d7fd"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Group_ReturnAll), @"mvc.1.0.view", @"/Views/Group/ReturnAll.cshtml")]
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
#line 1 "C:\Users\User\Desktop\aspnetcoreproject\aspnetcoreproject\Views\_ViewImports.cshtml"
using aspnetcoreproject;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\User\Desktop\aspnetcoreproject\aspnetcoreproject\Views\_ViewImports.cshtml"
using aspnetcoreproject.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"5a51ba334552895a3cddb4f9a330f53ba759d7fd", @"/Views/Group/ReturnAll.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"1e626a43105bd92af70d3bccfec1ad0dfef3bef5", @"/Views/_ViewImports.cshtml")]
    public class Views_Group_ReturnAll : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<List<Group>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral(@"<section id=""banner"">
    <div class=""item"" style=""background-color: #33ca7f;"">
        <div class=""container"">
            <div class=""row"">
                <div class=""col-6"">
                    <div style=""padding: 130px 0px 50px 0px;"">
                        <h1 class=""fw-bold text-white"">Groups</h1>

                    </div>
                </div>
            </div>
        </div>
    </div>
</section>
<section id=""groups"">
    <div class=""container"">
        <nav class=""pt-5 pb-5"" style=""--bs-breadcrumb-divider: '';"">
            <ol class=""breadcrumb"">
");
#nullable restore
#line 20 "C:\Users\User\Desktop\aspnetcoreproject\aspnetcoreproject\Views\Group\ReturnAll.cshtml"
                 foreach (Category item in (List<Category>)ViewBag.Gtypes)
                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                    <li data-filter=\"filter-");
#nullable restore
#line 22 "C:\Users\User\Desktop\aspnetcoreproject\aspnetcoreproject\Views\Group\ReturnAll.cshtml"
                                       Write(item.Id);

#line default
#line hidden
#nullable disable
            WriteLiteral("\" class=\"breadcrumb-item category-link\"><a href=\"#\" class=\"text-black fw-normal\">");
#nullable restore
#line 22 "C:\Users\User\Desktop\aspnetcoreproject\aspnetcoreproject\Views\Group\ReturnAll.cshtml"
                                                                                                                                Write(item.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("</a></li>\r\n");
#nullable restore
#line 23 "C:\Users\User\Desktop\aspnetcoreproject\aspnetcoreproject\Views\Group\ReturnAll.cshtml"
                }

#line default
#line hidden
#nullable disable
            WriteLiteral("            </ol>\r\n        </nav>\r\n        <div class=\"row\">\r\n            <div class=\"col-4\">\r\n\r\n            </div>\r\n        </div>\r\n    </div>\r\n    <div class=\"container\">\r\n        <div class=\"row align-items-center\">\r\n");
#nullable restore
#line 34 "C:\Users\User\Desktop\aspnetcoreproject\aspnetcoreproject\Views\Group\ReturnAll.cshtml"
             foreach (Group item in Model)
            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                <div");
            BeginWriteAttribute("class", " class=\"", 1175, "\"", 1231, 5);
            WriteAttributeValue("", 1183, "col-4", 1183, 5, true);
            WriteAttributeValue(" ", 1188, "mb-5", 1189, 5, true);
            WriteAttributeValue(" ", 1193, "group-wrapper", 1194, 14, true);
            WriteAttributeValue(" ", 1207, "filter-", 1208, 8, true);
#nullable restore
#line 36 "C:\Users\User\Desktop\aspnetcoreproject\aspnetcoreproject\Views\Group\ReturnAll.cshtml"
WriteAttributeValue("", 1215, item.CategoryId, 1215, 16, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">\r\n                    <div class=\"card text-center\" style=\"padding: 50px;\">\r\n                        <img");
            BeginWriteAttribute("src", " src=\"", 1338, "\"", 1383, 2);
            WriteAttributeValue("", 1344, "/uploads/categories/", 1344, 20, true);
#nullable restore
#line 38 "C:\Users\User\Desktop\aspnetcoreproject\aspnetcoreproject\Views\Group\ReturnAll.cshtml"
WriteAttributeValue("", 1364, item.Category.Icon, 1364, 19, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" class=\"card-img-top\" style=\"width: 90px;\">\r\n                        <div class=\"card-body\">\r\n                            <h5 class=\"card-title \">");
#nullable restore
#line 40 "C:\Users\User\Desktop\aspnetcoreproject\aspnetcoreproject\Views\Group\ReturnAll.cshtml"
                                               Write(item.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h5>\r\n                            <p class=\"card-text \">");
#nullable restore
#line 41 "C:\Users\User\Desktop\aspnetcoreproject\aspnetcoreproject\Views\Group\ReturnAll.cshtml"
                                             Write(item.Teacher.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n                            <p class=\"card-text\">Telebe sayi: 18*</p>\r\n                            <a");
            BeginWriteAttribute("href", " href=\"", 1722, "\"", 1752, 2);
            WriteAttributeValue("", 1729, "/student/index/", 1729, 15, true);
#nullable restore
#line 43 "C:\Users\User\Desktop\aspnetcoreproject\aspnetcoreproject\Views\Group\ReturnAll.cshtml"
WriteAttributeValue("", 1744, item.Id, 1744, 8, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" class=\"btn btn-success ps-5 pe-5\">Ətraflı</a>\r\n                        </div>\r\n                    </div>\r\n                </div>\r\n");
#nullable restore
#line 47 "C:\Users\User\Desktop\aspnetcoreproject\aspnetcoreproject\Views\Group\ReturnAll.cshtml"

            }

#line default
#line hidden
#nullable disable
            WriteLiteral("        </div>\r\n    </div>\r\n</section>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<List<Group>> Html { get; private set; }
    }
}
#pragma warning restore 1591
