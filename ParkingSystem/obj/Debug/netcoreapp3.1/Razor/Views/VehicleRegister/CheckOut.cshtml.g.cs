#pragma checksum "C:\Users\rakesh\Desktop\Rupa\ParkingSystem\ParkingSystem\ParkingSystem\Views\VehicleRegister\CheckOut.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "dc8b585d6f950816cb4c25f7339706f140a69ef1"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_VehicleRegister_CheckOut), @"mvc.1.0.view", @"/Views/VehicleRegister/CheckOut.cshtml")]
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
#line 1 "C:\Users\rakesh\Desktop\Rupa\ParkingSystem\ParkingSystem\ParkingSystem\Views\_ViewImports.cshtml"
using ParkingSystem.Core.Services;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\rakesh\Desktop\Rupa\ParkingSystem\ParkingSystem\ParkingSystem\Views\_ViewImports.cshtml"
using ParkingSystem.ViewModels;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"dc8b585d6f950816cb4c25f7339706f140a69ef1", @"/Views/VehicleRegister/CheckOut.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"b36508f946d3d89056da229e051459541bb2155c", @"/Views/_ViewImports.cshtml")]
    public class Views_VehicleRegister_CheckOut : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<ParkingSystem.ViewModels.CheckOutViewModel>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "C:\Users\rakesh\Desktop\Rupa\ParkingSystem\ParkingSystem\ParkingSystem\Views\VehicleRegister\CheckOut.cshtml"
  
    Layout = "_Layout";
    ViewBag.Title = "Check Out";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n");
#nullable restore
#line 8 "C:\Users\rakesh\Desktop\Rupa\ParkingSystem\ParkingSystem\ParkingSystem\Views\VehicleRegister\CheckOut.cshtml"
 using (Html.BeginForm("CheckOut", "VehicleRegister", FormMethod.Post))
{

#line default
#line hidden
#nullable disable
            WriteLiteral("    <h2>Check Out</h2>\r\n    <div class=\"form-group\">\r\n        <div>\r\n            ");
#nullable restore
#line 13 "C:\Users\rakesh\Desktop\Rupa\ParkingSystem\ParkingSystem\ParkingSystem\Views\VehicleRegister\CheckOut.cshtml"
       Write(Html.LabelFor(v => v.RegistrationNumber));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </div>\r\n        <div class=\"thumbnail\">\r\n            ");
#nullable restore
#line 16 "C:\Users\rakesh\Desktop\Rupa\ParkingSystem\ParkingSystem\ParkingSystem\Views\VehicleRegister\CheckOut.cshtml"
       Write(Html.TextBoxFor(v => v.RegistrationNumber));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            ");
#nullable restore
#line 17 "C:\Users\rakesh\Desktop\Rupa\ParkingSystem\ParkingSystem\ParkingSystem\Views\VehicleRegister\CheckOut.cshtml"
       Write(Html.ValidationMessageFor(v => v.RegistrationNumber, "", new { @class = "text-danger" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </div>\r\n\r\n");
#nullable restore
#line 20 "C:\Users\rakesh\Desktop\Rupa\ParkingSystem\ParkingSystem\ParkingSystem\Views\VehicleRegister\CheckOut.cshtml"
         if (!string.IsNullOrEmpty(Model.Message))
        {
            

#line default
#line hidden
#nullable disable
#nullable restore
#line 22 "C:\Users\rakesh\Desktop\Rupa\ParkingSystem\ParkingSystem\ParkingSystem\Views\VehicleRegister\CheckOut.cshtml"
       Write(Html.DisplayFor(v => v.Message));

#line default
#line hidden
#nullable disable
#nullable restore
#line 22 "C:\Users\rakesh\Desktop\Rupa\ParkingSystem\ParkingSystem\ParkingSystem\Views\VehicleRegister\CheckOut.cshtml"
                                            
        }

#line default
#line hidden
#nullable disable
            WriteLiteral("    </div>\r\n");
            WriteLiteral("    <button value=\"Submit\">Check Out</button>\r\n");
#nullable restore
#line 27 "C:\Users\rakesh\Desktop\Rupa\ParkingSystem\ParkingSystem\ParkingSystem\Views\VehicleRegister\CheckOut.cshtml"

}

#line default
#line hidden
#nullable disable
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<ParkingSystem.ViewModels.CheckOutViewModel> Html { get; private set; }
    }
}
#pragma warning restore 1591
