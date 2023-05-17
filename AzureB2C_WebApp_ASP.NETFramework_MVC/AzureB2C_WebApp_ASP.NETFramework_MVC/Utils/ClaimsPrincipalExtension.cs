using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Web;

namespace AzureB2C_WebApp_ASP.NETFramework_MVC.Utils
{
    public static class ClaimsPrincipalExtension
    {
        public static string GetB2CMsalAccountIdentifier(this ClaimsPrincipal claimsPrincipal, string policy)
        {
            string userObjectId = GetObjectId(claimsPrincipal);
            string tenantId = GlobalSettings.TenantId;

            if (!string.IsNullOrWhiteSpace(userObjectId) && !string.IsNullOrWhiteSpace(tenantId))
            {
                return $"{userObjectId}-{policy}.{tenantId}";
            }

            return null;
        }

        /// <summary>
        /// Get the unique object ID associated with the claimsPrincipal
        /// </summary>
        /// <param name="claimsPrincipal">Claims principal from which to retrieve the unique object id</param>
        /// <returns>Unique object ID of the identity, or <c>null</c> if it cannot be found</returns>
        public static string GetObjectId(this ClaimsPrincipal claimsPrincipal)
        {
            var objIdclaim = claimsPrincipal.FindFirst(ClaimTypes.NameIdentifier);

            if (objIdclaim == null)
            {
                objIdclaim = claimsPrincipal.FindFirst("sub");
            }

            return objIdclaim != null ? objIdclaim.Value : string.Empty;
        }
    }
}