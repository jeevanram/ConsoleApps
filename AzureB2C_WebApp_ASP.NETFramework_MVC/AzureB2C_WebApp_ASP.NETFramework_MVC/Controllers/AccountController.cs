using AzureB2C_WebApp_ASP.NETFramework_MVC.Utils;
using Microsoft.Identity.Client;
using Microsoft.Owin.Security;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace AzureB2C_WebApp_ASP.NETFramework_MVC.Controllers
{
    public class AccountController : Controller
    {
        /*
         *  Called when requesting to sign up or sign in
         */
        public void SignUpSignIn(string redirectUrl)
        {
            redirectUrl = redirectUrl ?? "/";

            // Use the default policy to process the sign up / sign in flow
            HttpContext.GetOwinContext().Authentication.Challenge(new AuthenticationProperties { RedirectUri = redirectUrl });
            return;
        }


        /*
         *  Called when requesting to sign out
         */
        public async Task SignOut()
        {
            // To sign out the user, you should issue an OpenIDConnect sign out request.
            if (Request.IsAuthenticated)
            {
                // Remove all tokens from MSAL's cache
                var clientApp = MsalAppBuilder.BuildConfidentialClientApplication();
                string accountId = ClaimsPrincipal.Current.GetB2CMsalAccountIdentifier(GlobalSettings.SignUpSignInPolicyId);
                IAccount account = await clientApp.GetAccountAsync(accountId);
                if (account != null)
                {
                    await clientApp.RemoveAsync(account);
                }

                // Then sign-out from OWIN
                IEnumerable<AuthenticationDescription> authTypes = HttpContext.GetOwinContext().Authentication.GetAuthenticationTypes();
                HttpContext.GetOwinContext().Authentication.SignOut(authTypes.Select(t => t.AuthenticationType).ToArray());
                Request.GetOwinContext().Authentication.GetAuthenticationTypes();
            }
        }
    }
}