#pragma checksum "D:\MK\MercadoCapitales\GestorMercadoCapitales\GestorMercadoCapitales\Views\Home\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "2646983e46b9888154736d3e42fe298e68a7d7eb"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_Index), @"mvc.1.0.view", @"/Views/Home/Index.cshtml")]
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
#line 1 "D:\MK\MercadoCapitales\GestorMercadoCapitales\GestorMercadoCapitales\Views\_ViewImports.cshtml"
using GestorMercadoCapitales;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "D:\MK\MercadoCapitales\GestorMercadoCapitales\GestorMercadoCapitales\Views\_ViewImports.cshtml"
using GestorMercadoCapitales.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"2646983e46b9888154736d3e42fe298e68a7d7eb", @"/Views/Home/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"90ca82432683befafb8b0af20f6cbfbfd6add7c9", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<List<CotizacionAccion>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 1 "D:\MK\MercadoCapitales\GestorMercadoCapitales\GestorMercadoCapitales\Views\Home\Index.cshtml"
  
    ViewData["Title"] = "Menu principal";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"

<table class=""table"">
    <thead class=""thead-dark"">
        <tr>
            <th scope=""col"">Ticker</th>
            <th scope=""col"">Precio</th>
            <th scope=""col"">Var.%</th>
            <th scope=""col"">Precio A</th>
            <th scope=""col"">C. Compra</th>
            <th scope=""col"">P. Compra</th>
            <th scope=""col"">P. Venta</th>
            <th scope=""col"">C. Venta</th>
            <th scope=""col"">Min-Max</th>
            <th scope=""col"">Vol. Num.</th>
            <th scope=""col"">Monto</th>
            <th scope=""col"">Oper</th>
            <th scope=""col"">Hora</th>
        </tr>
    </thead>
    <tbody>

");
#nullable restore
#line 27 "D:\MK\MercadoCapitales\GestorMercadoCapitales\GestorMercadoCapitales\Views\Home\Index.cshtml"
         try
        {
            

#line default
#line hidden
#nullable disable
#nullable restore
#line 29 "D:\MK\MercadoCapitales\GestorMercadoCapitales\GestorMercadoCapitales\Views\Home\Index.cshtml"
             foreach (var datos in Model)
            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                <tr>\r\n                    <td scope=\"row\">");
#nullable restore
#line 32 "D:\MK\MercadoCapitales\GestorMercadoCapitales\GestorMercadoCapitales\Views\Home\Index.cshtml"
                               Write(datos.ticker);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                    <td>");
#nullable restore
#line 33 "D:\MK\MercadoCapitales\GestorMercadoCapitales\GestorMercadoCapitales\Views\Home\Index.cshtml"
                   Write(datos.precio);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                    <td>");
#nullable restore
#line 34 "D:\MK\MercadoCapitales\GestorMercadoCapitales\GestorMercadoCapitales\Views\Home\Index.cshtml"
                   Write(datos.varPorcentual);

#line default
#line hidden
#nullable disable
            WriteLiteral(" %</td>\r\n                    <td>");
#nullable restore
#line 35 "D:\MK\MercadoCapitales\GestorMercadoCapitales\GestorMercadoCapitales\Views\Home\Index.cshtml"
                   Write(datos.precioA);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                    <td>");
#nullable restore
#line 36 "D:\MK\MercadoCapitales\GestorMercadoCapitales\GestorMercadoCapitales\Views\Home\Index.cshtml"
                   Write(datos.cCompra);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                    <td>");
#nullable restore
#line 37 "D:\MK\MercadoCapitales\GestorMercadoCapitales\GestorMercadoCapitales\Views\Home\Index.cshtml"
                   Write(datos.pCompra);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                    <td>");
#nullable restore
#line 38 "D:\MK\MercadoCapitales\GestorMercadoCapitales\GestorMercadoCapitales\Views\Home\Index.cshtml"
                   Write(datos.pVenta);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                    <td>");
#nullable restore
#line 39 "D:\MK\MercadoCapitales\GestorMercadoCapitales\GestorMercadoCapitales\Views\Home\Index.cshtml"
                   Write(datos.cVenta);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                    <td>");
#nullable restore
#line 40 "D:\MK\MercadoCapitales\GestorMercadoCapitales\GestorMercadoCapitales\Views\Home\Index.cshtml"
                   Write(datos.min);

#line default
#line hidden
#nullable disable
            WriteLiteral(" <input type=\"range\"");
            BeginWriteAttribute("min", " min=\"", 1276, "\"", 1292, 1);
#nullable restore
#line 40 "D:\MK\MercadoCapitales\GestorMercadoCapitales\GestorMercadoCapitales\Views\Home\Index.cshtml"
WriteAttributeValue("", 1282, datos.min, 1282, 10, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            BeginWriteAttribute("max", " max=\"", 1293, "\"", 1309, 1);
#nullable restore
#line 40 "D:\MK\MercadoCapitales\GestorMercadoCapitales\GestorMercadoCapitales\Views\Home\Index.cshtml"
WriteAttributeValue("", 1299, datos.max, 1299, 10, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" disabled> ");
#nullable restore
#line 40 "D:\MK\MercadoCapitales\GestorMercadoCapitales\GestorMercadoCapitales\Views\Home\Index.cshtml"
                                                                                              Write(datos.max);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                    <td>");
#nullable restore
#line 41 "D:\MK\MercadoCapitales\GestorMercadoCapitales\GestorMercadoCapitales\Views\Home\Index.cshtml"
                   Write(datos.volNom);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                    <td>");
#nullable restore
#line 42 "D:\MK\MercadoCapitales\GestorMercadoCapitales\GestorMercadoCapitales\Views\Home\Index.cshtml"
                   Write(datos.ajuste);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                    <td>");
#nullable restore
#line 43 "D:\MK\MercadoCapitales\GestorMercadoCapitales\GestorMercadoCapitales\Views\Home\Index.cshtml"
                   Write(datos.oper);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                    <td>");
#nullable restore
#line 44 "D:\MK\MercadoCapitales\GestorMercadoCapitales\GestorMercadoCapitales\Views\Home\Index.cshtml"
                   Write(datos.hora);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                </tr>\r\n");
#nullable restore
#line 46 "D:\MK\MercadoCapitales\GestorMercadoCapitales\GestorMercadoCapitales\Views\Home\Index.cshtml"
            }

#line default
#line hidden
#nullable disable
#nullable restore
#line 46 "D:\MK\MercadoCapitales\GestorMercadoCapitales\GestorMercadoCapitales\Views\Home\Index.cshtml"
             
        }
        catch { }

#line default
#line hidden
#nullable disable
            WriteLiteral("    </tbody>\r\n</table>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<List<CotizacionAccion>> Html { get; private set; }
    }
}
#pragma warning restore 1591
