#pragma checksum "D:\sw\App\StoreService\Views\Shared\CreateField.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "729e625aa30036cb6b90e8e13c9617d66530d760"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Shared_CreateField), @"mvc.1.0.view", @"/Views/Shared/CreateField.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Shared/CreateField.cshtml", typeof(AspNetCore.Views_Shared_CreateField))]
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
#line 1 "D:\sw\App\StoreService\Views\_ViewImports.cshtml"
using StoreService;

#line default
#line hidden
#line 2 "D:\sw\App\StoreService\Views\_ViewImports.cshtml"
using StoreService.Models;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"729e625aa30036cb6b90e8e13c9617d66530d760", @"/Views/Shared/CreateField.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"17abaf34317d686661956aab8d42936dca249b49", @"/Views/_ViewImports.cshtml")]
    public class Views_Shared_CreateField : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<tableStructure>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#line 2 "D:\sw\App\StoreService\Views\Shared\CreateField.cshtml"
  
    ViewData["Title"] = "Create";

#line default
#line hidden
            BeginContext(65, 21, true);
            WriteLiteral("\r\n<h2>Create</h2>\r\n\r\n");
            EndContext();
#line 8 "D:\sw\App\StoreService\Views\Shared\CreateField.cshtml"
 using (Html.BeginForm())
{
    

#line default
#line hidden
            BeginContext(121, 23, false);
#line 10 "D:\sw\App\StoreService\Views\Shared\CreateField.cshtml"
Write(Html.AntiForgeryToken());

#line default
#line hidden
            EndContext();
            BeginContext(146, 196, true);
            WriteLiteral("<fieldset>\r\n    <legend>Create Field</legend>\r\n    <div class=\"form-group\">\r\n        <div class=\"col-md-10\">\r\n            <input class=\"btn btn-default\" type=\"hidden\" id=\"field_id\" name=\"field_id\"");
            EndContext();
            BeginWriteAttribute("value", " value=\"", 342, "\"", 391, 1);
#line 15 "D:\sw\App\StoreService\Views\Shared\CreateField.cshtml"
WriteAttributeValue("", 350, Url.ActionContext.RouteData.Values["id"], 350, 41, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(392, 442, true);
            WriteLiteral(@" />
        </div>
        <div class=""control-label col-md-2"">
        </div>
        <div class=""col-md-10"">
            <input class=""btn btn-default"" type=""text"" id=""field_name"" name=""field_name"" value="""" />
        </div>
    </div>
    <div class=""form-group"">
        <div class=""col-md-offset-2 col-md-10"">
            <input type=""submit"" value=""Save"" class=""btn btn-default"" />
        </div>
    </div>

</fieldset>
");
            EndContext();
#line 30 "D:\sw\App\StoreService\Views\Shared\CreateField.cshtml"
}

#line default
#line hidden
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<tableStructure> Html { get; private set; }
    }
}
#pragma warning restore 1591
