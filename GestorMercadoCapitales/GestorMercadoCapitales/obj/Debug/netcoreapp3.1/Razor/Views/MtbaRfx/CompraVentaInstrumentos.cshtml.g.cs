#pragma checksum "D:\MK\MercadoCapitales\GestorMercadoCapitales\GestorMercadoCapitales\Views\MtbaRfx\CompraVentaInstrumentos.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "8780f5805674360ba7f38daef24162c0ea5f3b11"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_MtbaRfx_CompraVentaInstrumentos), @"mvc.1.0.view", @"/Views/MtbaRfx/CompraVentaInstrumentos.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"8780f5805674360ba7f38daef24162c0ea5f3b11", @"/Views/MtbaRfx/CompraVentaInstrumentos.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"90ca82432683befafb8b0af20f6cbfbfd6add7c9", @"/Views/_ViewImports.cshtml")]
    public class Views_MtbaRfx_CompraVentaInstrumentos : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("style", new global::Microsoft.AspNetCore.Html.HtmlString("color:black !important"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        #line hidden
        #pragma warning disable 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        #pragma warning restore 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __backed__tagHelperScopeManager = null;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __tagHelperScopeManager
        {
            get
            {
                if (__backed__tagHelperScopeManager == null)
                {
                    __backed__tagHelperScopeManager = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager(StartTagHelperWritingScope, EndTagHelperWritingScope);
                }
                return __backed__tagHelperScopeManager;
            }
        }
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral(@"
<link href=""https://cdn.jsdelivr.net/npm/select2@4.1.0-rc.0/dist/css/select2.min.css"" rel=""stylesheet"" />
<script src=""https://cdn.jsdelivr.net/npm/select2@4.1.0-rc.0/dist/js/select2.min.js""></script>

<style>

    .select2-container--default .select2-results__option--selected {
        color: black !important;
    }

    .select2-results__option--selectable {
        color: black !important;
    }

    .select2-container--default .select2-search--dropdown .select2-search__field {
        color: black;
    }

</style>



");
#nullable restore
#line 23 "D:\MK\MercadoCapitales\GestorMercadoCapitales\GestorMercadoCapitales\Views\MtbaRfx\CompraVentaInstrumentos.cshtml"
 using (Html.BeginForm("CompraInstrumento", "MtbaRfx"))
{


#line default
#line hidden
#nullable disable
            WriteLiteral(@"<div>

       
    <table>
        <tr>
            <td>Cuenta: REM7609</td>
            <td></td>
            <td>
                Instrumento:
                    <select class=""js-example-basic-single"" style=""color: black !important;"" name=""symbol"" id=""symbol"">
");
#nullable restore
#line 36 "D:\MK\MercadoCapitales\GestorMercadoCapitales\GestorMercadoCapitales\Views\MtbaRfx\CompraVentaInstrumentos.cshtml"
                     if (PanelInferiorInstrumentos.Instrumentos != null)
                    {
                        

#line default
#line hidden
#nullable disable
#nullable restore
#line 38 "D:\MK\MercadoCapitales\GestorMercadoCapitales\GestorMercadoCapitales\Views\MtbaRfx\CompraVentaInstrumentos.cshtml"
                         foreach (var secuencia in PanelInferiorInstrumentos.Instrumentos)
                        {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "8780f5805674360ba7f38daef24162c0ea5f3b115417", async() => {
#nullable restore
#line 40 "D:\MK\MercadoCapitales\GestorMercadoCapitales\GestorMercadoCapitales\Views\MtbaRfx\CompraVentaInstrumentos.cshtml"
                                                                                     Write(secuencia);

#line default
#line hidden
#nullable disable
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            BeginWriteTagHelperAttribute();
#nullable restore
#line 40 "D:\MK\MercadoCapitales\GestorMercadoCapitales\GestorMercadoCapitales\Views\MtbaRfx\CompraVentaInstrumentos.cshtml"
                                                                  WriteLiteral(secuencia);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper.Value = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("value", __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper.Value, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n");
#nullable restore
#line 41 "D:\MK\MercadoCapitales\GestorMercadoCapitales\GestorMercadoCapitales\Views\MtbaRfx\CompraVentaInstrumentos.cshtml"
                        }

#line default
#line hidden
#nullable disable
#nullable restore
#line 41 "D:\MK\MercadoCapitales\GestorMercadoCapitales\GestorMercadoCapitales\Views\MtbaRfx\CompraVentaInstrumentos.cshtml"
                         

                    }

#line default
#line hidden
#nullable disable
            WriteLiteral(@"                </select>
            </td>
                <td>Precio: <input type=""text"" name=""Precio"" id=""precio"" style=""color:black;"" required/> </td>
                <td>Cantidad: <input type=""number"" id=""cantidad"" name=""cantidad"" style=""color:black;"" required/></td>
                <td>Tipo Op:<br><input type=""radio"" name=""TipoOp"" value=""Compra"" checked=""checked""  required/>Compra<input type=""radio"" name=""TipoOp"" value=""Venta"" />Venta</td>
            <td><input type=""submit"" class=""btn btn-info"" value=""Solicitar""/></td>
        </tr>
    </table>
</div>
");
#nullable restore
#line 53 "D:\MK\MercadoCapitales\GestorMercadoCapitales\GestorMercadoCapitales\Views\MtbaRfx\CompraVentaInstrumentos.cshtml"

}

#line default
#line hidden
#nullable disable
            WriteLiteral("<script>\r\n    $(document).ready(function () {\r\n        $(\'.js-example-basic-single\').select2();\r\n    });\r\n\r\n</script>");
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
