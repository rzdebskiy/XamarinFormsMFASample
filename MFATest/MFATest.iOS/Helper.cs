using System;
using System.Linq;
using Foundation;
using UIKit;
using Xamarin.Forms;
using System.Threading.Tasks;
using Microsoft.IdentityModel.Clients.ActiveDirectory;

[assembly: Dependency(typeof(MFATest.iOS.Helper.Authenticator))]
namespace MFATest.iOS.Helper
{
    class Authenticator : IAuthenticator
    {
        public async Task<AuthenticationResult> Authenticate(string authority, string resource, string clientId, string returnUri)
        {
            var authContext = new AuthenticationContext(authority);
            if (authContext.TokenCache.ReadItems().Any())
                authContext = new AuthenticationContext(authContext.TokenCache.ReadItems().First().Authority);

            var controller = UIApplication.SharedApplication.KeyWindow.RootViewController;
            var uri = new Uri(returnUri);
            var platformParams = new PlatformParameters(controller);
            var authResult = await authContext.AcquireTokenAsync(resource, clientId, uri, platformParams);
            return authResult;
        }

        void IAuthenticator.ClearAllCookies()
        {
            NSHttpCookieStorage CookieStorage = NSHttpCookieStorage.SharedStorage;

            foreach (var cookie in CookieStorage.Cookies)
                CookieStorage.DeleteCookie(cookie);

            //other option could be to delete only cookies with the following names - "MSISAuth", "MSISAuthenticated", "MSISLoopDetectionCookie" 

        }
    }
}