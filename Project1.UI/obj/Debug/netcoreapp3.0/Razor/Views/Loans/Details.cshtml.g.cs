#pragma checksum "C:\Users\Robert\source\repos\Project1\Project1.UI\Views\Loans\Details.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "3ec8b887e46697371250e2e8ce6d740e96b80e0c"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Loans_Details), @"mvc.1.0.view", @"/Views/Loans/Details.cshtml")]
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
#line 1 "C:\Users\Robert\source\repos\Project1\Project1.UI\Views\_ViewImports.cshtml"
using Project1.UI;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\Robert\source\repos\Project1\Project1.UI\Views\_ViewImports.cshtml"
using Project1.UI.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Users\Robert\source\repos\Project1\Project1.UI\Views\_ViewImports.cshtml"
using Project1.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "C:\Users\Robert\source\repos\Project1\Project1.UI\Views\_ViewImports.cshtml"
using Microsoft.AspNetCore.Identity;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"3ec8b887e46697371250e2e8ce6d740e96b80e0c", @"/Views/Loans/Details.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"c79716ac05112f70bf5abe14ab8b2a50f01afa61", @"/Views/_ViewImports.cshtml")]
    public class Views_Loans_Details : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<Project1.UI.ViewModels.LoanVM>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Payment", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Index", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "C:\Users\Robert\source\repos\Project1\Project1.UI\Views\Loans\Details.cshtml"
  
    ViewData["Title"] = "Details";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<h1>Details</h1>\r\n");
#nullable restore
#line 8 "C:\Users\Robert\source\repos\Project1\Project1.UI\Views\Loans\Details.cshtml"
 if (Model.Loan.PaidOff)
{

#line default
#line hidden
#nullable disable
            WriteLiteral("    <h2 class=\"text-danger\">This Loan has already been paid off</h2>\r\n");
#nullable restore
#line 11 "C:\Users\Robert\source\repos\Project1\Project1.UI\Views\Loans\Details.cshtml"
}

#line default
#line hidden
#nullable disable
            WriteLiteral("<div>\r\n    <h4>Loan #");
#nullable restore
#line 13 "C:\Users\Robert\source\repos\Project1\Project1.UI\Views\Loans\Details.cshtml"
         Write(Model.Loan.Id);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h4>\r\n    <hr />\r\n    <dl class=\"row\">\r\n        <dt class=\"col-sm-2\">\r\n            ");
#nullable restore
#line 17 "C:\Users\Robert\source\repos\Project1\Project1.UI\Views\Loans\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.Loan.Principal));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class=\"col-sm-10\">\r\n            ");
#nullable restore
#line 20 "C:\Users\Robert\source\repos\Project1\Project1.UI\Views\Loans\Details.cshtml"
       Write(Html.DisplayFor(model => model.Loan.Principal));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n        <dt class=\"col-sm-2\">\r\n            ");
#nullable restore
#line 23 "C:\Users\Robert\source\repos\Project1\Project1.UI\Views\Loans\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.Loan.Balance));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class=\"col-sm-10\">\r\n            ");
#nullable restore
#line 26 "C:\Users\Robert\source\repos\Project1\Project1.UI\Views\Loans\Details.cshtml"
       Write(Html.DisplayFor(model => model.Loan.Balance));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n        <dt class=\"col-sm-2\">\r\n            ");
#nullable restore
#line 29 "C:\Users\Robert\source\repos\Project1\Project1.UI\Views\Loans\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.Loan.CreationDate));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class=\"col-sm-10\">\r\n            ");
#nullable restore
#line 32 "C:\Users\Robert\source\repos\Project1\Project1.UI\Views\Loans\Details.cshtml"
       Write(Html.DisplayFor(model => model.Loan.CreationDate));

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
        </dd>
    </dl>
</div>
<h4>Payment History</h4>
<hr />
<table class=""table"">
    <thead>
        <tr>
            <th>
                Payment amount
            </th>
            <th>
                Payment Date/Time
            </th>
            <th>
                Details
            </th>
        </tr>
    </thead>
    <tbody>
");
#nullable restore
#line 53 "C:\Users\Robert\source\repos\Project1\Project1.UI\Views\Loans\Details.cshtml"
         foreach (var item in Model.Payments)
        {

#line default
#line hidden
#nullable disable
            WriteLiteral("            <tr>\r\n                <td>\r\n                    ");
#nullable restore
#line 57 "C:\Users\Robert\source\repos\Project1\Project1.UI\Views\Loans\Details.cshtml"
               Write(Html.DisplayFor(modelItem => item.Amount));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </td>\r\n                <td>\r\n                    ");
#nullable restore
#line 60 "C:\Users\Robert\source\repos\Project1\Project1.UI\Views\Loans\Details.cshtml"
               Write(Html.DisplayFor(modelItem => item.PaymentTime));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </td>\r\n                <td>\r\n                    ");
#nullable restore
#line 63 "C:\Users\Robert\source\repos\Project1\Project1.UI\Views\Loans\Details.cshtml"
               Write(Html.DisplayFor(modelItem => item.Details));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </td>\r\n            </tr>\r\n");
#nullable restore
#line 66 "C:\Users\Robert\source\repos\Project1\Project1.UI\Views\Loans\Details.cshtml"
        }

#line default
#line hidden
#nullable disable
            WriteLiteral("    </tbody>\r\n</table>\r\n");
#nullable restore
#line 69 "C:\Users\Robert\source\repos\Project1\Project1.UI\Views\Loans\Details.cshtml"
 if (!Model.Loan.PaidOff)
{

#line default
#line hidden
#nullable disable
            WriteLiteral("    <div>\r\n        ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "3ec8b887e46697371250e2e8ce6d740e96b80e0c9122", async() => {
                WriteLiteral("Make a Payment");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 72 "C:\Users\Robert\source\repos\Project1\Project1.UI\Views\Loans\Details.cshtml"
                                  WriteLiteral(Model.Loan.Id);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral(" |\r\n        ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "3ec8b887e46697371250e2e8ce6d740e96b80e0c11287", async() => {
                WriteLiteral("Back to List");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n    </div>\r\n");
#nullable restore
#line 75 "C:\Users\Robert\source\repos\Project1\Project1.UI\Views\Loans\Details.cshtml"
}
else
{

#line default
#line hidden
#nullable disable
            WriteLiteral("    <div>\r\n        ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "3ec8b887e46697371250e2e8ce6d740e96b80e0c12685", async() => {
                WriteLiteral("Back to List");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n    </div>\r\n");
#nullable restore
#line 81 "C:\Users\Robert\source\repos\Project1\Project1.UI\Views\Loans\Details.cshtml"
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<Project1.UI.ViewModels.LoanVM> Html { get; private set; }
    }
}
#pragma warning restore 1591
