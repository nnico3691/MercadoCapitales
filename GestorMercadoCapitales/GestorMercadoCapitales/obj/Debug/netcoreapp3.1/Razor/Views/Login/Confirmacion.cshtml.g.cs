#pragma checksum "C:\proyectos\MercadoCapitales\GestorMercadoCapitales\GestorMercadoCapitales\Views\Login\Confirmacion.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "337fb47ac6122df2055b0c287134b26f650b9081"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Login_Confirmacion), @"mvc.1.0.view", @"/Views/Login/Confirmacion.cshtml")]
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
#line 1 "C:\proyectos\MercadoCapitales\GestorMercadoCapitales\GestorMercadoCapitales\Views\_ViewImports.cshtml"
using GestorMercadoCapitales;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\proyectos\MercadoCapitales\GestorMercadoCapitales\GestorMercadoCapitales\Views\_ViewImports.cshtml"
using GestorMercadoCapitales.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"337fb47ac6122df2055b0c287134b26f650b9081", @"/Views/Login/Confirmacion.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"90ca82432683befafb8b0af20f6cbfbfd6add7c9", @"/Views/_ViewImports.cshtml")]
    #nullable restore
    public class Views_Login_Confirmacion : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<DatosCliente>
    #nullable disable
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 2 "C:\proyectos\MercadoCapitales\GestorMercadoCapitales\GestorMercadoCapitales\Views\Login\Confirmacion.cshtml"
  
    ViewData["Title"] = "Confirmacion";
    Layout = "~/Views/Shared/_Layout.cshtml";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<h2>Confirmación de mis datos</h2>\r\n<div style=\"width:100%;border-style: double;\">\r\n       <b>DNI:</b>\r\n        <br/>\r\n            ");
#nullable restore
#line 12 "C:\proyectos\MercadoCapitales\GestorMercadoCapitales\GestorMercadoCapitales\Views\Login\Confirmacion.cshtml"
       Write(Html.DisplayFor(model => model.TipoDNI));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        <br/>\r\n    \r\n       <b>Nombre:</b>\r\n       <br/>\r\n            ");
#nullable restore
#line 17 "C:\proyectos\MercadoCapitales\GestorMercadoCapitales\GestorMercadoCapitales\Views\Login\Confirmacion.cshtml"
       Write(Html.DisplayFor(model => model.Nombre));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n       <br/>\r\n       <b>Apellido:</b>\r\n        <br /> \r\n            ");
#nullable restore
#line 21 "C:\proyectos\MercadoCapitales\GestorMercadoCapitales\GestorMercadoCapitales\Views\Login\Confirmacion.cshtml"
       Write(Html.DisplayFor(model => model.Apellido));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        <br/>\r\n       <b>Teléfono:</b><br /> \r\n        ");
#nullable restore
#line 24 "C:\proyectos\MercadoCapitales\GestorMercadoCapitales\GestorMercadoCapitales\Views\Login\Confirmacion.cshtml"
   Write(Html.DisplayFor(model => model.Telefono));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n    \r\n</div>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<DatosCliente> Html { get; private set; } = default!;
        #nullable disable
    }
}
#pragma warning restore 1591
