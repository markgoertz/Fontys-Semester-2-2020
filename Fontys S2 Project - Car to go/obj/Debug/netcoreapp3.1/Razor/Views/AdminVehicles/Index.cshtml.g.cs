#pragma checksum "D:\Fontys Semester 2 2020\Fontys S2 Project - Car to go\Views\AdminVehicles\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "31a58182ceea0b545a452e7d9663a9528a90d8f8"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_AdminVehicles_Index), @"mvc.1.0.view", @"/Views/AdminVehicles/Index.cshtml")]
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
#line 1 "D:\Fontys Semester 2 2020\Fontys S2 Project - Car to go\Views\_ViewImports.cshtml"
using Fontys_S2_Project___Car_to_go;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "D:\Fontys Semester 2 2020\Fontys S2 Project - Car to go\Views\_ViewImports.cshtml"
using Fontys_S2_Project___Car_to_go.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"31a58182ceea0b545a452e7d9663a9528a90d8f8", @"/Views/AdminVehicles/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"024675a3548315655ca905462d7f0a44243c6e54", @"/Views/_ViewImports.cshtml")]
    public class Views_AdminVehicles_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<Fontys_S2_Project___Car_to_go.Models.VehicleViewModel>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "D:\Fontys Semester 2 2020\Fontys S2 Project - Car to go\Views\AdminVehicles\Index.cshtml"
  
    ViewData["Title"] = "View";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<h2 class=\"text-center p-3\">All Cars in the system!</h2>\r\n\r\n\r\n   ");
#nullable restore
#line 10 "D:\Fontys Semester 2 2020\Fontys S2 Project - Car to go\Views\AdminVehicles\Index.cshtml"
Write(Html.ActionLink("Add new car to the system", "Create", "AdminVehicles"));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\r\n<div class=\"table-responsive\">\r\n");
#nullable restore
#line 13 "D:\Fontys Semester 2 2020\Fontys S2 Project - Car to go\Views\AdminVehicles\Index.cshtml"
     if (TempData["Delete"] != null)
    {

#line default
#line hidden
#nullable disable
            WriteLiteral("        <strong class=\"alert alert-danger\">");
#nullable restore
#line 15 "D:\Fontys Semester 2 2020\Fontys S2 Project - Car to go\Views\AdminVehicles\Index.cshtml"
                                      Write(TempData["Delete"]);

#line default
#line hidden
#nullable disable
            WriteLiteral("</strong>\r\n        <br/>\r\n        <br/>\r\n");
#nullable restore
#line 18 "D:\Fontys Semester 2 2020\Fontys S2 Project - Car to go\Views\AdminVehicles\Index.cshtml"
    }

#line default
#line hidden
#nullable disable
#nullable restore
#line 19 "D:\Fontys Semester 2 2020\Fontys S2 Project - Car to go\Views\AdminVehicles\Index.cshtml"
     if (TempData["Create"] != null)
    {

#line default
#line hidden
#nullable disable
            WriteLiteral("        <strong class=\"alert alert-success\">");
#nullable restore
#line 21 "D:\Fontys Semester 2 2020\Fontys S2 Project - Car to go\Views\AdminVehicles\Index.cshtml"
                                       Write(TempData["Create"]);

#line default
#line hidden
#nullable disable
            WriteLiteral("</strong>\r\n        <br />\r\n        <br/>\r\n");
#nullable restore
#line 24 "D:\Fontys Semester 2 2020\Fontys S2 Project - Car to go\Views\AdminVehicles\Index.cshtml"
    }

#line default
#line hidden
#nullable disable
#nullable restore
#line 25 "D:\Fontys Semester 2 2020\Fontys S2 Project - Car to go\Views\AdminVehicles\Index.cshtml"
     if (TempData["Update"] != null)
    {

#line default
#line hidden
#nullable disable
            WriteLiteral("        <strong class=\"alert alert-warning\">");
#nullable restore
#line 27 "D:\Fontys Semester 2 2020\Fontys S2 Project - Car to go\Views\AdminVehicles\Index.cshtml"
                                       Write(TempData["Update"]);

#line default
#line hidden
#nullable disable
            WriteLiteral("</strong>\r\n        <br/>\r\n        <br/>\r\n");
#nullable restore
#line 30 "D:\Fontys Semester 2 2020\Fontys S2 Project - Car to go\Views\AdminVehicles\Index.cshtml"
    }

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n    <table class=\"table table-striped\">\r\n        <thead class=\"thead-dark\">\r\n            <tr>\r\n                <th>\r\n                    ");
#nullable restore
#line 36 "D:\Fontys Semester 2 2020\Fontys S2 Project - Car to go\Views\AdminVehicles\Index.cshtml"
               Write(Html.DisplayNameFor(model => model.ID));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </th>\r\n                <th>\r\n                    ");
#nullable restore
#line 39 "D:\Fontys Semester 2 2020\Fontys S2 Project - Car to go\Views\AdminVehicles\Index.cshtml"
               Write(Html.DisplayNameFor(model => model.Brandname));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </th>\r\n                <th>\r\n                    ");
#nullable restore
#line 42 "D:\Fontys Semester 2 2020\Fontys S2 Project - Car to go\Views\AdminVehicles\Index.cshtml"
               Write(Html.DisplayNameFor(model => model.Modelname));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </th>\r\n                <th>\r\n                    ");
#nullable restore
#line 45 "D:\Fontys Semester 2 2020\Fontys S2 Project - Car to go\Views\AdminVehicles\Index.cshtml"
               Write(Html.DisplayNameFor(model => model.Transmission));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </th>\r\n                <th>\r\n                    ");
#nullable restore
#line 48 "D:\Fontys Semester 2 2020\Fontys S2 Project - Car to go\Views\AdminVehicles\Index.cshtml"
               Write(Html.DisplayNameFor(model => model.Enginepower));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </th>\r\n                <th>\r\n                    ");
#nullable restore
#line 51 "D:\Fontys Semester 2 2020\Fontys S2 Project - Car to go\Views\AdminVehicles\Index.cshtml"
               Write(Html.DisplayNameFor(model => model.Acceleration));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </th>\r\n                <th>\r\n                    ");
#nullable restore
#line 54 "D:\Fontys Semester 2 2020\Fontys S2 Project - Car to go\Views\AdminVehicles\Index.cshtml"
               Write(Html.DisplayNameFor(model => model.Weight));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </th>\r\n                <th>\r\n                    ");
#nullable restore
#line 57 "D:\Fontys Semester 2 2020\Fontys S2 Project - Car to go\Views\AdminVehicles\Index.cshtml"
               Write(Html.DisplayNameFor(model => model.Cargospace));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </th>\r\n                <th>\r\n                    ");
#nullable restore
#line 60 "D:\Fontys Semester 2 2020\Fontys S2 Project - Car to go\Views\AdminVehicles\Index.cshtml"
               Write(Html.DisplayNameFor(model => model.Seat));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </th>\r\n                <th>\r\n                    ");
#nullable restore
#line 63 "D:\Fontys Semester 2 2020\Fontys S2 Project - Car to go\Views\AdminVehicles\Index.cshtml"
               Write(Html.DisplayNameFor(model => model.RentalPrice));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </th>\r\n                <th>\r\n                    ");
#nullable restore
#line 66 "D:\Fontys Semester 2 2020\Fontys S2 Project - Car to go\Views\AdminVehicles\Index.cshtml"
               Write(Html.DisplayNameFor(model => model.Fueltype));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </th>\r\n                <th>\r\n                    ");
#nullable restore
#line 69 "D:\Fontys Semester 2 2020\Fontys S2 Project - Car to go\Views\AdminVehicles\Index.cshtml"
               Write(Html.DisplayNameFor(model => model.ImageLink));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </th>\r\n                <th>\r\n                    ");
#nullable restore
#line 72 "D:\Fontys Semester 2 2020\Fontys S2 Project - Car to go\Views\AdminVehicles\Index.cshtml"
               Write(Html.DisplayNameFor(model => model.CategoryID));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </th>\r\n                <th></th>\r\n            </tr>\r\n        </thead>\r\n\r\n\r\n        <tbody>\r\n\r\n");
#nullable restore
#line 81 "D:\Fontys Semester 2 2020\Fontys S2 Project - Car to go\Views\AdminVehicles\Index.cshtml"
             foreach (var item in Model)
            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                <tr>\r\n                    <td>\r\n                        ");
#nullable restore
#line 85 "D:\Fontys Semester 2 2020\Fontys S2 Project - Car to go\Views\AdminVehicles\Index.cshtml"
                   Write(Html.DisplayFor(modelItem => item.ID));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </td>\r\n                    <td>\r\n                        ");
#nullable restore
#line 88 "D:\Fontys Semester 2 2020\Fontys S2 Project - Car to go\Views\AdminVehicles\Index.cshtml"
                   Write(Html.DisplayFor(modelItem => item.Brandname));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </td>\r\n                    <td>\r\n                        ");
#nullable restore
#line 91 "D:\Fontys Semester 2 2020\Fontys S2 Project - Car to go\Views\AdminVehicles\Index.cshtml"
                   Write(Html.DisplayFor(modelItem => item.Modelname));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </td>\r\n                    <td>\r\n                        ");
#nullable restore
#line 94 "D:\Fontys Semester 2 2020\Fontys S2 Project - Car to go\Views\AdminVehicles\Index.cshtml"
                   Write(Html.DisplayFor(modelItem => item.Transmission));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </td>\r\n                    <td>\r\n                        ");
#nullable restore
#line 97 "D:\Fontys Semester 2 2020\Fontys S2 Project - Car to go\Views\AdminVehicles\Index.cshtml"
                   Write(Html.DisplayFor(modelItem => item.Enginepower));

#line default
#line hidden
#nullable disable
            WriteLiteral("HP\r\n                    </td>\r\n                    <td>\r\n                        ");
#nullable restore
#line 100 "D:\Fontys Semester 2 2020\Fontys S2 Project - Car to go\Views\AdminVehicles\Index.cshtml"
                   Write(Html.DisplayFor(modelItem => item.Acceleration));

#line default
#line hidden
#nullable disable
            WriteLiteral(" Seconds to 100km/h\r\n                    </td>\r\n                    <td>\r\n                        ");
#nullable restore
#line 103 "D:\Fontys Semester 2 2020\Fontys S2 Project - Car to go\Views\AdminVehicles\Index.cshtml"
                   Write(Html.DisplayFor(modelItem => item.Weight));

#line default
#line hidden
#nullable disable
            WriteLiteral(" kg\r\n                    </td>\r\n                    <td>\r\n                        ");
#nullable restore
#line 106 "D:\Fontys Semester 2 2020\Fontys S2 Project - Car to go\Views\AdminVehicles\Index.cshtml"
                   Write(Html.DisplayFor(modelItem => item.Cargospace));

#line default
#line hidden
#nullable disable
            WriteLiteral(" L\r\n                    </td>\r\n                    <td>\r\n                        ");
#nullable restore
#line 109 "D:\Fontys Semester 2 2020\Fontys S2 Project - Car to go\Views\AdminVehicles\Index.cshtml"
                   Write(Html.DisplayFor(modelItem => item.Seat));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </td>\r\n                    <td>\r\n                        €");
#nullable restore
#line 112 "D:\Fontys Semester 2 2020\Fontys S2 Project - Car to go\Views\AdminVehicles\Index.cshtml"
                    Write(Html.DisplayFor(modelItem => item.RentalPrice));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </td>\r\n                    <td>\r\n                        ");
#nullable restore
#line 115 "D:\Fontys Semester 2 2020\Fontys S2 Project - Car to go\Views\AdminVehicles\Index.cshtml"
                   Write(Html.DisplayFor(modelItem => item.Fueltype));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </td>\r\n                    <td>\r\n                        ");
#nullable restore
#line 118 "D:\Fontys Semester 2 2020\Fontys S2 Project - Car to go\Views\AdminVehicles\Index.cshtml"
                   Write(Html.DisplayFor(modelItem => item.ImageLink));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </td>\r\n                    <td>\r\n                        ");
#nullable restore
#line 121 "D:\Fontys Semester 2 2020\Fontys S2 Project - Car to go\Views\AdminVehicles\Index.cshtml"
                   Write(Html.DisplayFor(modelItem => item.CategoryID));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </td>\r\n                    <td>\r\n                        <button class=\"btn-warning\">");
#nullable restore
#line 124 "D:\Fontys Semester 2 2020\Fontys S2 Project - Car to go\Views\AdminVehicles\Index.cshtml"
                                               Write(Html.ActionLink("Update", "Update", new { ID = item.ID }, new { @class = "text-white p-3 text-decoration-none" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("</button>\r\n                        <button class=\"btn-info\">");
#nullable restore
#line 125 "D:\Fontys Semester 2 2020\Fontys S2 Project - Car to go\Views\AdminVehicles\Index.cshtml"
                                            Write(Html.ActionLink("Details", "Details", "Vehicle", new { ID = item.ID }, new { @class = "text-white p-3 text-decoration-none" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("</button>\r\n                        <button class=\"btn-danger\">");
#nullable restore
#line 126 "D:\Fontys Semester 2 2020\Fontys S2 Project - Car to go\Views\AdminVehicles\Index.cshtml"
                                              Write(Html.ActionLink("Delete", "Delete", new { ID = item.ID }, new { onclick = "return confirm('Are sure wants to delete?');", @class = "text-white p-3 text-decoration-none" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("</button>\r\n                    </td>\r\n                </tr>\r\n");
#nullable restore
#line 129 "D:\Fontys Semester 2 2020\Fontys S2 Project - Car to go\Views\AdminVehicles\Index.cshtml"
            }

#line default
#line hidden
#nullable disable
            WriteLiteral("        </tbody>\r\n    </table>\r\n</div>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<Fontys_S2_Project___Car_to_go.Models.VehicleViewModel>> Html { get; private set; }
    }
}
#pragma warning restore 1591
