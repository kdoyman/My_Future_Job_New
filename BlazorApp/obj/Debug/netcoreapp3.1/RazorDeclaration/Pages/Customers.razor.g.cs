#pragma checksum "C:\Users\koko\source\repos\New_MFJ\My_Future_Job\BlazorApp\Pages\Customers.razor" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "4294008c9fba5311ce10b9959fde2616173407fd"
// <auto-generated/>
#pragma warning disable 1591
#pragma warning disable 0414
#pragma warning disable 0649
#pragma warning disable 0169

namespace BlazorApp.Pages
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Components;
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
#nullable restore
#line 2 "C:\Users\koko\source\repos\New_MFJ\My_Future_Job\BlazorApp\Pages\Customers.razor"
using System.Net.Http;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Users\koko\source\repos\New_MFJ\My_Future_Job\BlazorApp\Pages\Customers.razor"
using System.Net.Http.Headers;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "C:\Users\koko\source\repos\New_MFJ\My_Future_Job\BlazorApp\Pages\Customers.razor"
using Microsoft.AspNetCore.Http;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "C:\Users\koko\source\repos\New_MFJ\My_Future_Job\BlazorApp\Pages\Customers.razor"
using Microsoft.AspNetCore.Authentication;

#line default
#line hidden
#nullable disable
#nullable restore
#line 6 "C:\Users\koko\source\repos\New_MFJ\My_Future_Job\BlazorApp\Pages\Customers.razor"
using Serilog;

#line default
#line hidden
#nullable disable
    [Microsoft.AspNetCore.Components.RouteAttribute("/customers")]
    public partial class Customers : Microsoft.AspNetCore.Components.ComponentBase
    {
        #pragma warning disable 1998
        protected override void BuildRenderTree(Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder)
        {
        }
        #pragma warning restore 1998
#nullable restore
#line 164 "C:\Users\koko\source\repos\New_MFJ\My_Future_Job\BlazorApp\Pages\Customers.razor"
       
    private Customer[] custs;
    string baseUrl = "https://localhost:44311/";
    Customer custObj = new Customer();

    string ids = "0";
    bool showAddrow = false;

    bool loadFailed;

    Customer SelectedCustomer = null;
    public static int CustomersPerPage { get; set; } = 5;
    public static int Pagenumber { get; set; } = 1;
    public static int OldPage;
    bool state = false;

    private long custcountl;
    private bool active = true;
    public int MaxPage
    {
        get
        {
            if (Math.Ceiling((double)(custcountl) / CustomersPerPage) <= 1) { active = false; }
            return Convert.ToInt32(Math.Ceiling(Convert.ToDouble(custcountl) / CustomersPerPage));
        }

    }

    void RowSelect(Customer c)
    {
        SelectedCustomer = c;
    }

    void DoStuff(ChangeEventArgs e)
    {
        switch (e.Value)
        {
            case "five": if (CustomersPerPage == 5) { break; } else { CustomersPerPage = 5; state = true; break; }
            case "ten": if (CustomersPerPage == 10) { break; } else { CustomersPerPage = 10; state = true; break; }
            case "fifteen": if (CustomersPerPage == 15) { break; } else { CustomersPerPage = 15; state = true; break; }
            case "twenty": if (CustomersPerPage == 20) { break; } else { CustomersPerPage = 20; state = true; break; }
            default:
                break;
        }
        Console.WriteLine("It is definitely: " + CustomersPerPage);
        if (state)
        {
            NavigationManager.NavigateTo("customers", true);
        }
        else
        {
            NavigationManager.NavigateTo("customers");
        }
    }

    public void setpage()
    {

        Pagenumber = Pagenumber;
        if (Pagenumber != OldPage)
        {
            NavigationManager.NavigateTo("customers", true);
        }
    }

    protected void onclick(MouseEventArgs e)
    {
        if (Pagenumber != OldPage) {
            NavigationManager.NavigateTo("customers", true);
        }
    }

    protected void onclicklast(MouseEventArgs e)
    {
        Pagenumber = MaxPage;
        if (Pagenumber != OldPage)
        {
            NavigationManager.NavigateTo("customers", true);
        }
    }

    protected void onclickfirst(MouseEventArgs e)
    {
        Pagenumber = 1;
        if (Pagenumber != OldPage)
        {
            NavigationManager.NavigateTo("customers", true);
        }
    }

    protected void onclicknext(MouseEventArgs e)
    {
        if (Pagenumber != MaxPage)
        {
            Pagenumber = Pagenumber + 1;
            NavigationManager.NavigateTo("customers", true);
        }
    }

    protected void onclickbw(MouseEventArgs e)
    {
        if (Pagenumber != 1)
        {
            Pagenumber--;
            NavigationManager.NavigateTo("customers", true);
        }
    }

    protected override async Task OnInitializedAsync()
    {
        try
        {
            ids = "0";
            OldPage = Pagenumber;
            var accessToken = await _httpContextAccessor.HttpContext.GetTokenAsync("access_token");
            if (accessToken != null)
            {
                if(Http.DefaultRequestHeaders.Authorization == null)
                {
                    Http.DefaultRequestHeaders.Add("Authorization", "Bearer " + accessToken);
                }
            }

            await load();

        }
        catch (Exception)
        {
            Log.Information("Failed to Initialize customers");
            throw;
        }

    }

    protected async Task load()
    {
        custcountl = await Http.GetJsonAsync<long>($"{baseUrl}api/customers/GetCount");
        if (Pagenumber > MaxPage && MaxPage != 0) { Pagenumber = MaxPage; }
        else if (Pagenumber < 1) { Pagenumber = 1; }
        custs = await Http.GetJsonAsync<Customer[]>($"{baseUrl}api/customers/getall?pagenum={Pagenumber}&customersPerPage={CustomersPerPage}");
    }

    void AddNewCustomer()
    {
        ids = "0";
        if (showAddrow == false) { showAddrow = true; } else { showAddrow = false; }
        custObj = new Customer();
    }
    // Add New Customer Details Method
    protected async Task AddCustomer()
    {
        if (ids == "0")

        {
            await Http.SendJsonAsync(HttpMethod.Post, $"{baseUrl}api/customers/", custObj);
            await load();
        }
        else
        {
            await Http.SendJsonAsync(HttpMethod.Put, $"{baseUrl}api/customers/" + custObj.Id, custObj);
            await load();
        }

        showAddrow = false;
    }
    // Edit Method
    protected async Task EditCustomer(string CustomerID)
    {
        showAddrow = true;

        ids = "1";
        try
        {
            loadFailed = false;
            ids = CustomerID.ToString();
            custObj = await Http.GetJsonAsync<Customer>
                ($"{baseUrl}api/customers/" + CustomerID);

            string s = custObj.Id;

            showAddrow = true;

        }
        catch (Exception ex)
        {
            loadFailed = true;
            Log.Fatal(ex, "Failed to edit customer {CustomerId}", CustomerID);

        }
    }
    // Delte Method
    protected async Task DeleteCustomer(string CustomerID)
    {
        showAddrow = false;
        bool confirmed = await JsRuntime.InvokeAsync<bool>("confirm", "Are you sure you want to delete this customer?");
        if (confirmed)
        {
            ids = CustomerID.ToString();
            await Http.DeleteAsync($"{baseUrl}api/customers/" + CustomerID);

            await load();
        }
    }


#line default
#line hidden
#nullable disable
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private NavigationManager NavigationManager { get; set; }
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private IHttpContextAccessor _httpContextAccessor { get; set; }
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private IJSRuntime JsRuntime { get; set; }
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private HttpClient Http { get; set; }
    }
}
#pragma warning restore 1591
