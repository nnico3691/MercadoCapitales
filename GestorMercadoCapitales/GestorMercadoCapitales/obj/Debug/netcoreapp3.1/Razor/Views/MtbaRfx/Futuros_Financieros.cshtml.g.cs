#pragma checksum "C:\proyectos\MercadoCapitales\GestorMercadoCapitales\GestorMercadoCapitales\Views\MtbaRfx\Futuros_Financieros.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "c47671a111936669a21748ed17d480cb89f0806d"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_MtbaRfx_Futuros_Financieros), @"mvc.1.0.view", @"/Views/MtbaRfx/Futuros_Financieros.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"c47671a111936669a21748ed17d480cb89f0806d", @"/Views/MtbaRfx/Futuros_Financieros.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"90ca82432683befafb8b0af20f6cbfbfd6add7c9", @"/Views/_ViewImports.cshtml")]
    #nullable restore
    public class Views_MtbaRfx_Futuros_Financieros : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<List<MtbaRfx>>
    #nullable disable
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 1 "C:\proyectos\MercadoCapitales\GestorMercadoCapitales\GestorMercadoCapitales\Views\MtbaRfx\Futuros_Financieros.cshtml"
  
    ViewData["Title"] = "Futuros Financieros";
    Layout = "~/Views/Shared/_Layout.cshtml";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n");
            WriteLiteral("\r\n    ");
#nullable restore
#line 8 "C:\proyectos\MercadoCapitales\GestorMercadoCapitales\GestorMercadoCapitales\Views\MtbaRfx\Futuros_Financieros.cshtml"
Write(Html.Partial("NavBarMtbrfx"));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\r\n<br />\r\n<br />\r\n\r\n<h3>Futuro Financiero</h3>\r\n<br>\r\n\r\n");
#nullable restore
#line 16 "C:\proyectos\MercadoCapitales\GestorMercadoCapitales\GestorMercadoCapitales\Views\MtbaRfx\Futuros_Financieros.cshtml"
Write(Html.Partial("CompraVentaInstrumentos"));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\r\n\r\n <div id=\"TablaPrincipal\">\r\n\r\n    <br/>\r\n    <hr/>\r\n    <table class=\"table table-striped table-dark\">\r\n        <thead");
            BeginWriteAttribute("class", " class=\"", 383, "\"", 391, 0);
            EndWriteAttribute();
            WriteLiteral(@">
            <tr>
                <th scope=""col"">Instrumento</th>
                <th scope=""col"">Vol. C</th>
                <th scope=""col"">Compra</th>
                <th scope=""col"">Venta</th>
                <th scope=""col"">Vol. V</th>
                <th scope=""col"">Ult</th>
                <th scope=""col"">Var</th>
                <th scope=""col"">Var%</th>
                <th scope=""col"">Vol. Operado</th>
                <th scope=""col"">Ajuste</th>
                <th scope=""col"">Min</th>
                <th scope=""col"">Max</th>
                <th scope=""col"">Range</th>
                <th scope=""col"">Int. Abierto</th>
                <th scope=""col"">Hora</th>
            </tr>
        </thead>
        <tbody>

");
#nullable restore
#line 45 "C:\proyectos\MercadoCapitales\GestorMercadoCapitales\GestorMercadoCapitales\Views\MtbaRfx\Futuros_Financieros.cshtml"
             try
            {
                

#line default
#line hidden
#nullable disable
#nullable restore
#line 47 "C:\proyectos\MercadoCapitales\GestorMercadoCapitales\GestorMercadoCapitales\Views\MtbaRfx\Futuros_Financieros.cshtml"
                 foreach (var datos in Model)
                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                    <tr>\r\n                        <td>");
#nullable restore
#line 50 "C:\proyectos\MercadoCapitales\GestorMercadoCapitales\GestorMercadoCapitales\Views\MtbaRfx\Futuros_Financieros.cshtml"
                       Write(datos.Instrumento);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                        <td>");
#nullable restore
#line 51 "C:\proyectos\MercadoCapitales\GestorMercadoCapitales\GestorMercadoCapitales\Views\MtbaRfx\Futuros_Financieros.cshtml"
                       Write(datos.VolC);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                        <td");
            BeginWriteAttribute("style", " style=\"", 1394, "\"", 1438, 3);
            WriteAttributeValue("", 1402, "background-color:", 1402, 17, true);
#nullable restore
#line 52 "C:\proyectos\MercadoCapitales\GestorMercadoCapitales\GestorMercadoCapitales\Views\MtbaRfx\Futuros_Financieros.cshtml"
WriteAttributeValue("", 1419, datos.ColorCompra, 1419, 18, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 1437, ";", 1437, 1, true);
            EndWriteAttribute();
            WriteLiteral(">");
#nullable restore
#line 52 "C:\proyectos\MercadoCapitales\GestorMercadoCapitales\GestorMercadoCapitales\Views\MtbaRfx\Futuros_Financieros.cshtml"
                                                                    Write(datos.Compra);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                        <td");
            BeginWriteAttribute("style", " style=\"", 1487, "\"", 1530, 3);
            WriteAttributeValue("", 1495, "background-color:", 1495, 17, true);
#nullable restore
#line 53 "C:\proyectos\MercadoCapitales\GestorMercadoCapitales\GestorMercadoCapitales\Views\MtbaRfx\Futuros_Financieros.cshtml"
WriteAttributeValue("", 1512, datos.ColorVenta, 1512, 17, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 1529, ";", 1529, 1, true);
            EndWriteAttribute();
            WriteLiteral(">");
#nullable restore
#line 53 "C:\proyectos\MercadoCapitales\GestorMercadoCapitales\GestorMercadoCapitales\Views\MtbaRfx\Futuros_Financieros.cshtml"
                                                                   Write(datos.Venta);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                        <td>");
#nullable restore
#line 54 "C:\proyectos\MercadoCapitales\GestorMercadoCapitales\GestorMercadoCapitales\Views\MtbaRfx\Futuros_Financieros.cshtml"
                       Write(datos.VolV);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                        <td>");
#nullable restore
#line 55 "C:\proyectos\MercadoCapitales\GestorMercadoCapitales\GestorMercadoCapitales\Views\MtbaRfx\Futuros_Financieros.cshtml"
                       Write(datos.Ult);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                        <td>");
#nullable restore
#line 56 "C:\proyectos\MercadoCapitales\GestorMercadoCapitales\GestorMercadoCapitales\Views\MtbaRfx\Futuros_Financieros.cshtml"
                       Write(datos.Var);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                        <td>");
#nullable restore
#line 57 "C:\proyectos\MercadoCapitales\GestorMercadoCapitales\GestorMercadoCapitales\Views\MtbaRfx\Futuros_Financieros.cshtml"
                       Write(datos.VarPorcentaje);

#line default
#line hidden
#nullable disable
            WriteLiteral(" %</td>\r\n                        <td>");
#nullable restore
#line 58 "C:\proyectos\MercadoCapitales\GestorMercadoCapitales\GestorMercadoCapitales\Views\MtbaRfx\Futuros_Financieros.cshtml"
                       Write(datos.VolOpe);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                        <td>");
#nullable restore
#line 59 "C:\proyectos\MercadoCapitales\GestorMercadoCapitales\GestorMercadoCapitales\Views\MtbaRfx\Futuros_Financieros.cshtml"
                       Write(datos.Ajuste);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                        <td>");
#nullable restore
#line 60 "C:\proyectos\MercadoCapitales\GestorMercadoCapitales\GestorMercadoCapitales\Views\MtbaRfx\Futuros_Financieros.cshtml"
                       Write(datos.Min);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                        <td>");
#nullable restore
#line 61 "C:\proyectos\MercadoCapitales\GestorMercadoCapitales\GestorMercadoCapitales\Views\MtbaRfx\Futuros_Financieros.cshtml"
                       Write(datos.Max);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                        <td><input type=\"range\"");
            BeginWriteAttribute("min", " min=\"", 1977, "\"", 1993, 1);
#nullable restore
#line 62 "C:\proyectos\MercadoCapitales\GestorMercadoCapitales\GestorMercadoCapitales\Views\MtbaRfx\Futuros_Financieros.cshtml"
WriteAttributeValue("", 1983, datos.Max, 1983, 10, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            BeginWriteAttribute("max", " max=\"", 1994, "\"", 2010, 1);
#nullable restore
#line 62 "C:\proyectos\MercadoCapitales\GestorMercadoCapitales\GestorMercadoCapitales\Views\MtbaRfx\Futuros_Financieros.cshtml"
WriteAttributeValue("", 2000, datos.Max, 2000, 10, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" disabled></td>\r\n                        <td>");
#nullable restore
#line 63 "C:\proyectos\MercadoCapitales\GestorMercadoCapitales\GestorMercadoCapitales\Views\MtbaRfx\Futuros_Financieros.cshtml"
                       Write(datos.intAbierto);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                        <td>");
#nullable restore
#line 64 "C:\proyectos\MercadoCapitales\GestorMercadoCapitales\GestorMercadoCapitales\Views\MtbaRfx\Futuros_Financieros.cshtml"
                       Write(datos.hora);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                    </tr>\r\n");
#nullable restore
#line 66 "C:\proyectos\MercadoCapitales\GestorMercadoCapitales\GestorMercadoCapitales\Views\MtbaRfx\Futuros_Financieros.cshtml"
                }

#line default
#line hidden
#nullable disable
#nullable restore
#line 66 "C:\proyectos\MercadoCapitales\GestorMercadoCapitales\GestorMercadoCapitales\Views\MtbaRfx\Futuros_Financieros.cshtml"
                 
            }
            catch { }

#line default
#line hidden
#nullable disable
            WriteLiteral(@"

        </tbody>
    </table>

 </div>

<script>

    setInterval('contador()', 1000);

    //$(document).ready(function () {
    //    var refreshId = setInterval(function () {
    //        $('#TablaPrincipal').load('contador()');//actualizas el div automaticamente
    //    }, 1000);
    //});


    function contador() {

        jQuery.ajax({
            url: '");
#nullable restore
#line 90 "C:\proyectos\MercadoCapitales\GestorMercadoCapitales\GestorMercadoCapitales\Views\MtbaRfx\Futuros_Financieros.cshtml"
             Write(Url.Action("Futuros_Financieros", "MtbaRfx"));

#line default
#line hidden
#nullable disable
            WriteLiteral(@"',
            type: ""POST"",
            dataType: ""json"",
            data: {},
            success: function (result) {
               // window.location.reload()
              
            }
        });

        $('#TablaPrincipal').load(location.href + "" #TablaPrincipal"");
    }


</script>
");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<List<MtbaRfx>> Html { get; private set; } = default!;
        #nullable disable
    }
}
#pragma warning restore 1591
