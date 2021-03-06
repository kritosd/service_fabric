#pragma checksum "D:\sw\App\StoreService\Views\Shared\Table.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "c965cb65f73c8efaadf9a9e065209214223fa270"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Shared_Table), @"mvc.1.0.view", @"/Views/Shared/Table.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Shared/Table.cshtml", typeof(AspNetCore.Views_Shared_Table))]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"c965cb65f73c8efaadf9a9e065209214223fa270", @"/Views/Shared/Table.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"17abaf34317d686661956aab8d42936dca249b49", @"/Views/_ViewImports.cshtml")]
    public class Views_Shared_Table : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<tableStructure>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(0, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 3 "D:\sw\App\StoreService\Views\Shared\Table.cshtml"
  
    ViewData["Title"] = "Table";
    Layout = "~/Views/Shared/_Layout.cshtml";

#line default
#line hidden
            BeginContext(113, 25, true);
            WriteLiteral("<h2>Table</h2>\r\n<p>\r\n    ");
            EndContext();
            BeginContext(139, 226, false);
#line 9 "D:\sw\App\StoreService\Views\Shared\Table.cshtml"
Write(Html.ActionLink("Back", // <-- Link text
                 "Tables", // <-- Action Method Name
                 "Home",
                 null, // <-- Route value
                 null // <-- htmlArguments
                ));

#line default
#line hidden
            EndContext();
            BeginContext(365, 8, true);
            WriteLiteral("\r\n</p>\r\n");
            EndContext();
#line 16 "D:\sw\App\StoreService\Views\Shared\Table.cshtml"
 using (Html.BeginForm())
{
    

#line default
#line hidden
            BeginContext(408, 23, false);
#line 18 "D:\sw\App\StoreService\Views\Shared\Table.cshtml"
Write(Html.AntiForgeryToken());

#line default
#line hidden
            EndContext();
            BeginContext(433, 184, true);
            WriteLiteral("<fieldset>\r\n    <legend>Edit Table</legend>\r\n\r\n    <div class=\"form-group\">\r\n        <div class=\"control-label col-md-2\">\r\n        </div>\r\n        <div class=\"col-md-10\">\r\n            ");
            EndContext();
            BeginContext(618, 33, false);
#line 26 "D:\sw\App\StoreService\Views\Shared\Table.cshtml"
       Write(Html.HiddenFor(Model => Model.id));

#line default
#line hidden
            EndContext();
            BeginContext(651, 14, true);
            WriteLiteral("\r\n            ");
            EndContext();
            BeginContext(666, 35, false);
#line 27 "D:\sw\App\StoreService\Views\Shared\Table.cshtml"
       Write(Html.EditorFor(Model => Model.name));

#line default
#line hidden
            EndContext();
            BeginContext(701, 112, true);
            WriteLiteral("\r\n        </div>\r\n    </div>\r\n\r\n    <button type=\"button\" name=\"add\" id=\"add\" class=\"btn btn-success\">\r\n        ");
            EndContext();
            BeginContext(814, 199, false);
#line 32 "D:\sw\App\StoreService\Views\Shared\Table.cshtml"
   Write(Html.ActionLink("Create New Field",
                    "CreateField",
                    "Home",
                    new { table_id = Model.id },
                    null
                    ));

#line default
#line hidden
            EndContext();
            BeginContext(1013, 17, true);
            WriteLiteral("\r\n    </button>\r\n");
            EndContext();
#line 39 "D:\sw\App\StoreService\Views\Shared\Table.cshtml"
     for (var i = 0; i < Model.fields.Count; i++)
    {

#line default
#line hidden
            BeginContext(1088, 46, true);
            WriteLiteral("        <div class=\"form-group\">\r\n            ");
            EndContext();
            BeginContext(1135, 95, false);
#line 42 "D:\sw\App\StoreService\Views\Shared\Table.cshtml"
       Write(Html.LabelFor(model => model.fields, htmlAttributes: new { @class = "control-label col-md-2" }));

#line default
#line hidden
            EndContext();
            BeginContext(1230, 55, true);
            WriteLiteral("\r\n            <div class=\"col-md-10\">\r\n                ");
            EndContext();
            BeginContext(1286, 43, false);
#line 44 "D:\sw\App\StoreService\Views\Shared\Table.cshtml"
           Write(Html.HiddenFor(model => model.fields[i].id));

#line default
#line hidden
            EndContext();
            BeginContext(1329, 18, true);
            WriteLiteral("\r\n                ");
            EndContext();
            BeginContext(1348, 45, false);
#line 45 "D:\sw\App\StoreService\Views\Shared\Table.cshtml"
           Write(Html.EditorFor(model => model.fields[i].name));

#line default
#line hidden
            EndContext();
            BeginContext(1393, 38, true);
            WriteLiteral("\r\n            </div>\r\n        </div>\r\n");
            EndContext();
#line 48 "D:\sw\App\StoreService\Views\Shared\Table.cshtml"
    }

#line default
#line hidden
            BeginContext(1438, 196, true);
            WriteLiteral("    <div class=\"form-group\">\r\n        <div class=\"col-md-offset-2 col-md-10\">\r\n            <input type=\"submit\" value=\"Save\" class=\"btn btn-default\" />\r\n        </div>\r\n    </div>\r\n\r\n</fieldset>\r\n");
            EndContext();
#line 56 "D:\sw\App\StoreService\Views\Shared\Table.cshtml"
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
