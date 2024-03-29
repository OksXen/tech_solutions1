#pragma checksum "D:\Users\fcodi\source\Github\tech_solutions1\src\tech_solutions\dotnet_core_mvc_web_app\Views\EmployeeActivityByDapper\InterestedPersonListings.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "0c86841ccd16d30721e21d788abd277ce9b85451"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_EmployeeActivityByDapper_InterestedPersonListings), @"mvc.1.0.view", @"/Views/EmployeeActivityByDapper/InterestedPersonListings.cshtml")]
namespace AspNetCore
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
#nullable restore
#line 1 "D:\Users\fcodi\source\Github\tech_solutions1\src\tech_solutions\dotnet_core_mvc_web_app\Views\EmployeeActivityByDapper\InterestedPersonListings.cshtml"
using TechSolutionsLibs.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "D:\Users\fcodi\source\Github\tech_solutions1\src\tech_solutions\dotnet_core_mvc_web_app\Views\EmployeeActivityByDapper\InterestedPersonListings.cshtml"
using System.Linq;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"0c86841ccd16d30721e21d788abd277ce9b85451", @"/Views/EmployeeActivityByDapper/InterestedPersonListings.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"ee2f6e9fea1e34bb26ceb8cb6cdf9265302a2313", @"/Views/_ViewImports.cshtml")]
    public class Views_EmployeeActivityByDapper_InterestedPersonListings : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 4 "D:\Users\fcodi\source\Github\tech_solutions1\src\tech_solutions\dotnet_core_mvc_web_app\Views\EmployeeActivityByDapper\InterestedPersonListings.cshtml"
  
    ViewData["Title"] = "Employee Activity Controller";
    IEnumerable<EmployeeActivity> employeeActivities = ViewData["employeeActivities"] as IEnumerable<EmployeeActivity> ;

  


#line default
#line hidden
#nullable disable
            WriteLiteral(@"
<div class=""text-left"">
    <div>
        <h1>Interested Person Listings By Dapper</h1>        

        <table class='table' aria-labelledby=""tabelLabel"">

            <thead>
                <tr>
                    <th scope=""col"">Id</th>
                    <th scope=""col"">First Name</th>
                    <th scope=""col"">Last Name</th>
                    <th scope=""col"">Email</th>
                    <th scope=""col"">Activity Name</th>
                    <th scope=""col"">Comments</th>
                </tr>
            </thead>

            <tbody>
");
#nullable restore
#line 30 "D:\Users\fcodi\source\Github\tech_solutions1\src\tech_solutions\dotnet_core_mvc_web_app\Views\EmployeeActivityByDapper\InterestedPersonListings.cshtml"
                 foreach (EmployeeActivity item in employeeActivities)
                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                    <tr>\r\n                        <td>");
#nullable restore
#line 33 "D:\Users\fcodi\source\Github\tech_solutions1\src\tech_solutions\dotnet_core_mvc_web_app\Views\EmployeeActivityByDapper\InterestedPersonListings.cshtml"
                       Write(item.ActivityId);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                        <td>");
#nullable restore
#line 34 "D:\Users\fcodi\source\Github\tech_solutions1\src\tech_solutions\dotnet_core_mvc_web_app\Views\EmployeeActivityByDapper\InterestedPersonListings.cshtml"
                       Write(item.FirstName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                        <td>");
#nullable restore
#line 35 "D:\Users\fcodi\source\Github\tech_solutions1\src\tech_solutions\dotnet_core_mvc_web_app\Views\EmployeeActivityByDapper\InterestedPersonListings.cshtml"
                       Write(item.LastName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                        <td>");
#nullable restore
#line 36 "D:\Users\fcodi\source\Github\tech_solutions1\src\tech_solutions\dotnet_core_mvc_web_app\Views\EmployeeActivityByDapper\InterestedPersonListings.cshtml"
                       Write(item.EmailAddress);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                        <td>");
#nullable restore
#line 37 "D:\Users\fcodi\source\Github\tech_solutions1\src\tech_solutions\dotnet_core_mvc_web_app\Views\EmployeeActivityByDapper\InterestedPersonListings.cshtml"
                       Write(item.ActivityName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                        <td>");
#nullable restore
#line 38 "D:\Users\fcodi\source\Github\tech_solutions1\src\tech_solutions\dotnet_core_mvc_web_app\Views\EmployeeActivityByDapper\InterestedPersonListings.cshtml"
                       Write(item.Comments);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                    </tr>\r\n");
#nullable restore
#line 40 "D:\Users\fcodi\source\Github\tech_solutions1\src\tech_solutions\dotnet_core_mvc_web_app\Views\EmployeeActivityByDapper\InterestedPersonListings.cshtml"
                }

#line default
#line hidden
#nullable disable
            WriteLiteral("            </tbody>\r\n        </table>\r\n\r\n    </div>\r\n</div>\r\n");
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
