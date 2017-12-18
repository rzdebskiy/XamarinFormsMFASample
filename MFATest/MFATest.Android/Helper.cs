using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Microsoft.IdentityModel.Clients.ActiveDirectory;
using Xamarin.Forms;
using MFATest;
using System.Threading.Tasks;
using Android.Webkit;

[assembly: Dependency(typeof(MFATestPCL.Droid.Helper.Authenticator))]
namespace MFATestPCL.Droid.Helper
{
    public class Authenticator : IAuthenticator
    {

        async Task<AuthenticationResult> IAuthenticator.Authenticate(string authority, string resource, string clientId, string returnUri)
        {
            var authContext = new AuthenticationContext(authority);
            if (authContext.TokenCache.ReadItems().Any())
                authContext = new AuthenticationContext(authContext.TokenCache.ReadItems().First().Authority);

            var uri = new Uri(returnUri);

            var platformParams = new PlatformParameters((Activity)Forms.Context);
            // Use this instead if you would like to force reathentication every time:
            // var platformParams = new PlatformParameters((Activity)Forms.Context, true, PromptBehavior.Always);

            var authResult = await authContext.AcquireTokenAsync(resource, clientId, uri, platformParams);
            return authResult;
        }

        void IAuthenticator.ClearAllCookies()
        {
            CookieManager cookieManager = CookieManager.Instance;
            cookieManager.RemoveAllCookie();
            cookieManager.Flush();
        }
    }

}