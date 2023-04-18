using Microsoft.Extensions.Primitives;

namespace DataAccess.Api.OData
{
    /// <summary>
    /// 
    /// </summary>
    public static class RequestExtensions
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public static bool ShouldOmitNullValues(this HttpRequest request)
        {
            // for simplicity, we check the prefer header
            string? preferHeader = null;
            if (request.Headers.TryGetValue("Prefer", out StringValues values))
            {
                // If there are many "Prefer" headers, pick up the first one.
                preferHeader = values.FirstOrDefault();
            }

            if (preferHeader == null)
            {
                return false;
            }

            // use case insensitive string comparison
            if (preferHeader.Contains("omit-values=nulls", StringComparison.OrdinalIgnoreCase))
            {
                return true;
            }

            return false;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="httpRequest"></param>
        public static void SetPreferenceAppliedResponseHeader(this HttpRequest httpRequest)
        {
            var response = httpRequest.HttpContext.Response;

            string? prefer_applied = null;
            if (response.Headers.TryGetValue("Preference-Applied", out StringValues values))
            {
                // If there are many "Preference-Applied" headers, pick up the first one.
                prefer_applied = values.FirstOrDefault();
            }

            if (prefer_applied == null)
            {
                response.Headers["Preference-Applied"] = "omit-values=nulls";
            }
            else if (!prefer_applied.Contains("omit-values=nulls"))
            {
                response.Headers["Preference-Applied"] = $"{prefer_applied},omit-values=nulls";
            }
        }
    }
}
