using Microsoft.IdentityModel.Clients.ActiveDirectory;
using System;
using Xamarin.Forms;

namespace MFATest
{
    public partial class MainPage : ContentPage
    {
        public static string clientId = "<<INSERT YOUR CLIENT ID HERE>>";
        public static string authority = "https://login.windows.net/common";
        public static string returnUri = "http://MFATestPCL-redirect";
        private const string graphResourceUri = "https://graph.windows.net";
        private AuthenticationResult authResult = null;

        public MainPage()
        {
            InitializeComponent();
        }

        private async void btnLogin_Clicked(object sender, EventArgs e)
        {
            try
            {
                var auth = DependencyService.Get<IAuthenticator>();
                authResult = await auth.Authenticate(authority, graphResourceUri, clientId, returnUri);
                var userName = authResult.UserInfo.GivenName + " " + authResult.UserInfo.FamilyName;
                await DisplayAlert("Token", userName, "Ok", "Cancel");
            }
            catch (Exception ex)
            {
                await DisplayAlert("Error", ex.Message, "Ok");
            }
        }

        private void btnLogout_Clicked(object sender, EventArgs e)
        {
            if (authResult != null)
            {
                AuthenticationContext ac = new AuthenticationContext(authority);
                ac.TokenCache.Clear();
                var auth = DependencyService.Get<IAuthenticator>();
                auth.ClearAllCookies();
            }

        }
    }
}
