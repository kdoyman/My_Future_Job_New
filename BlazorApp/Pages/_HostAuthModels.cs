using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.OpenIdConnect;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;


namespace BlazorApp.Pages
{
    public class _HostAuthModels : PageModel
    {
        public IActionResult OnGetLogin()
        {
            return Challenge(AuthProps(), OpenIdConnectDefaults.AuthenticationScheme);
        }

        public async Task OnGetLogout()
        {
            await HttpContext.SignOutAsync("Cookies");
            await HttpContext.SignOutAsync(OpenIdConnectDefaults.AuthenticationScheme, AuthProps());
        }

        private AuthenticationProperties AuthProps()
            => new AuthenticationProperties
            {
                RedirectUri = Url.Content("~/")
            };
    }
}
