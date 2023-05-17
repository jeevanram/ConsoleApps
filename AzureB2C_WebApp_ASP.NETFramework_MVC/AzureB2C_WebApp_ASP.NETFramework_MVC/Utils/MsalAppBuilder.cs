using Microsoft.Identity.Client;
using Microsoft.Identity.Web;

namespace AzureB2C_WebApp_ASP.NETFramework_MVC.Utils
{
    public static class MsalAppBuilder
    {
        /// <summary>
        /// Shared method to create an IConfidentialClientApplication from configuration and attach the application's token cache implementation
        /// </summary>
        public static IConfidentialClientApplication BuildConfidentialClientApplication()
        {
            IConfidentialClientApplication clientapp = ConfidentialClientApplicationBuilder.Create(GlobalSettings.ClientId)
                  .WithClientSecret(GlobalSettings.ClientSecret)
                  .WithRedirectUri(GlobalSettings.RedirectUri)
                  .WithB2CAuthority(GlobalSettings.B2CAuthority)
                  .Build();

            // Important: for simplicity, this sample showcases an in-memory cache
            // For eviction policies and for using a distribued cache see:
            // https://learn.microsoft.com/en-us/azure/active-directory/develop/msal-net-token-cache-serialization?tabs=aspnet

            //Add an in-memory token cache with options
            clientapp.AddInMemoryTokenCache();

            return clientapp;
        }
    }
}