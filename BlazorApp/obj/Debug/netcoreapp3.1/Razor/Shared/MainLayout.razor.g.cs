#pragma checksum "C:\Users\koko\source\repos\New_MFJ\My_Future_Job\BlazorApp\Shared\MainLayout.razor" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "8266e667647eafc51bbc930d60396b5831a9d39b"
// <auto-generated/>
#pragma warning disable 1591
namespace BlazorApp.Shared
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Components;
#nullable restore
#line 1 "C:\Users\koko\source\repos\New_MFJ\My_Future_Job\BlazorApp\_Imports.razor"
using System.Net.Http;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\koko\source\repos\New_MFJ\My_Future_Job\BlazorApp\_Imports.razor"
using Microsoft.AspNetCore.Authorization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Users\koko\source\repos\New_MFJ\My_Future_Job\BlazorApp\_Imports.razor"
using Microsoft.AspNetCore.Components.Authorization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "C:\Users\koko\source\repos\New_MFJ\My_Future_Job\BlazorApp\_Imports.razor"
using Microsoft.AspNetCore.Components.Forms;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "C:\Users\koko\source\repos\New_MFJ\My_Future_Job\BlazorApp\_Imports.razor"
using Microsoft.AspNetCore.Components.Routing;

#line default
#line hidden
#nullable disable
#nullable restore
#line 6 "C:\Users\koko\source\repos\New_MFJ\My_Future_Job\BlazorApp\_Imports.razor"
using Microsoft.AspNetCore.Components.Web;

#line default
#line hidden
#nullable disable
#nullable restore
#line 7 "C:\Users\koko\source\repos\New_MFJ\My_Future_Job\BlazorApp\_Imports.razor"
using Microsoft.JSInterop;

#line default
#line hidden
#nullable disable
#nullable restore
#line 8 "C:\Users\koko\source\repos\New_MFJ\My_Future_Job\BlazorApp\_Imports.razor"
using BlazorApp;

#line default
#line hidden
#nullable disable
#nullable restore
#line 9 "C:\Users\koko\source\repos\New_MFJ\My_Future_Job\BlazorApp\_Imports.razor"
using BlazorApp.Shared;

#line default
#line hidden
#nullable disable
#nullable restore
#line 10 "C:\Users\koko\source\repos\New_MFJ\My_Future_Job\BlazorApp\_Imports.razor"
using CustomerLibrary;

#line default
#line hidden
#nullable disable
#nullable restore
#line 11 "C:\Users\koko\source\repos\New_MFJ\My_Future_Job\BlazorApp\_Imports.razor"
using Radzen;

#line default
#line hidden
#nullable disable
#nullable restore
#line 12 "C:\Users\koko\source\repos\New_MFJ\My_Future_Job\BlazorApp\_Imports.razor"
using Radzen.Blazor;

#line default
#line hidden
#nullable disable
#nullable restore
#line 13 "C:\Users\koko\source\repos\New_MFJ\My_Future_Job\BlazorApp\_Imports.razor"
using BlazorStrap;

#line default
#line hidden
#nullable disable
    public partial class MainLayout : LayoutComponentBase
    {
        #pragma warning disable 1998
        protected override void BuildRenderTree(Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder)
        {
            __builder.OpenElement(0, "div");
            __builder.AddAttribute(1, "class", "sidebar");
            __builder.AddMarkupContent(2, "\r\n    ");
            __builder.OpenComponent<BlazorApp.Shared.NavMenu>(3);
            __builder.CloseComponent();
            __builder.AddMarkupContent(4, "\r\n");
            __builder.CloseElement();
            __builder.AddMarkupContent(5, "\r\n\r\n");
            __builder.OpenElement(6, "div");
            __builder.AddAttribute(7, "class", "main");
            __builder.AddMarkupContent(8, "\r\n    ");
            __builder.OpenElement(9, "div");
            __builder.AddAttribute(10, "class", "top-row px-4");
            __builder.AddMarkupContent(11, "\r\n        ");
            __builder.OpenElement(12, "h3");
            __builder.AddContent(13, "Hello, ");
            __builder.AddContent(14, 
#nullable restore
#line 11 "C:\Users\koko\source\repos\New_MFJ\My_Future_Job\BlazorApp\Shared\MainLayout.razor"
                    Username

#line default
#line hidden
#nullable disable
            );
            __builder.CloseElement();
            __builder.AddMarkupContent(15, "\r\n        ");
            __builder.AddMarkupContent(16, "<a href=\"/Logout\">Logout</a>\r\n        ");
            __builder.AddMarkupContent(17, "<a href=\"https://docs.microsoft.com/aspnet/\" target=\"_blank\">About</a>\r\n    ");
            __builder.CloseElement();
            __builder.AddMarkupContent(18, "\r\n\r\n    ");
            __builder.OpenElement(19, "div");
            __builder.AddAttribute(20, "class", "content px-4");
            __builder.AddMarkupContent(21, "\r\n        ");
            __builder.AddContent(22, 
#nullable restore
#line 17 "C:\Users\koko\source\repos\New_MFJ\My_Future_Job\BlazorApp\Shared\MainLayout.razor"
         Body

#line default
#line hidden
#nullable disable
            );
            __builder.AddMarkupContent(23, "\r\n    ");
            __builder.CloseElement();
            __builder.AddMarkupContent(24, "\r\n");
            __builder.CloseElement();
        }
        #pragma warning restore 1998
#nullable restore
#line 21 "C:\Users\koko\source\repos\New_MFJ\My_Future_Job\BlazorApp\Shared\MainLayout.razor"
 
    private string Username = "Anonymous User";

    protected override async Task OnInitializedAsync()
    {
        var state = await AuthState.GetAuthenticationStateAsync();

        Username =
            state.User.Claims
            .Where(c => c.Type.Equals("name"))
            .Select(c => c.Value)
            .FirstOrDefault() ?? string.Empty;

        await base.OnInitializedAsync();
    }

#line default
#line hidden
#nullable disable
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private AuthenticationStateProvider AuthState { get; set; }
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private IBootstrapCss BootstrapCSS { get; set; }
    }
}
#pragma warning restore 1591
