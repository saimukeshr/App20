using Microsoft.Identity.Client;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;

namespace App20.Helpers
{
    public class AuthenticationHelper
    {
        string RedirectUri
        {
            get
            {
                if (DeviceInfo.Platform == DevicePlatform.Android)
                    return $"msauth://{AppId}/{{o30yPkEvW4KJc2Cqh/ngZjy8EwY=}}";
                else if (DeviceInfo.Platform == DevicePlatform.iOS)
                    return $"msauth.{AppId}://auth";

                return string.Empty;
            }
        }

        readonly string AppId = "com.companyname.app20";
        readonly string ClientID = "c89858b7-60e3-42c6-ba7f-91fa9742f05a";
        readonly string[] Scopes = { "User.Read" };
        public static object ParentWindow { get; set; }
        private IPublicClientApplication _pca;

        public AuthenticationHelper()
        {
            _pca = PublicClientApplicationBuilder.Create(ClientID)
               .WithIosKeychainSecurityGroup(AppId)
               .WithRedirectUri(RedirectUri)
               .WithAuthority("https://login.microsoftonline.com/common")
               .Build();
        }

        public async Task<bool> SignInAsync()
        {
            try
            {
                var accounts = await _pca.GetAccountsAsync();
                var firstAccount = accounts.FirstOrDefault();
                var authResult = await _pca.AcquireTokenSilent(Scopes, firstAccount).ExecuteAsync();

                // Store the access token securely for later use.
                await SecureStorage.SetAsync("AccessToken", authResult?.AccessToken);

                return true;
            }
            catch (MsalUiRequiredException)
            {
                try
                {
                    // This means we need to login again through the MSAL window.
                    var authResult = await _pca.AcquireTokenInteractive(Scopes)
                                                .WithParentActivityOrWindow(ParentWindow)
                                                .WithUseEmbeddedWebView(true)
                                                .ExecuteAsync();

                    // Store the access token securely for later use.
                    await SecureStorage.SetAsync("AccessToken", authResult?.AccessToken);

                    return true;
                }
                catch (Exception ex2)
                {
                    Debug.WriteLine(ex2.ToString());
                    return false;
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.ToString());
                return false;
            }
        }

        public async Task<bool> SignOutAsync()
        {
            try
            {
                var accounts = await _pca.GetAccountsAsync();

                // Go through all accounts and remove them.
                while (accounts.Any())
                {
                    await _pca.RemoveAsync(accounts.FirstOrDefault());
                    accounts = await _pca.GetAccountsAsync();
                }

                // Clear our access token from secure storage.
                SecureStorage.Remove("AccessToken");

                return true;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.ToString());
                return false;
            }
        }
    }
}
