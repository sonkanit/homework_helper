using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

using Microsoft.WindowsAzure.MobileServices;

namespace homework_helper
{
    [Activity(MainLauncher = true, Icon = "@drawable/ic_launcher", Label = "@string/app_name", Theme = "@android:style/Theme.Black.NoTitleBar")]
    public class MainActivity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.MainLayout);
        }

        protected override void OnResume()
        {
            base.OnResume();

            if (user != null && user.MobileServiceAuthenticationToken.Length > 0)
            {
                NavigateToPathSelection();
            }
        }

        private void NavigateToPathSelection()
        {
            var intent = new Intent(this, typeof(SelectPathActivity));
            StartActivity(intent);
        }

        private void CreateAndShowDialog(Exception exception, String title)
        {
            CreateAndShowDialog(exception.Message, title);
        }

        private void CreateAndShowDialog(string message, string title)
        {
            AlertDialog.Builder builder = new AlertDialog.Builder(this);

            builder.SetMessage(message);
            builder.SetTitle(title);
            builder.Create().Show();
        }

        private MobileServiceUser user;
        private async Task<bool> Authenticate()
        {
            var success = false;
            try
            {
                // Sign in with Facebook login using a server-managed flow.
                ((PanPanyaApp)Application).User = await ((PanPanyaApp)Application).Client.LoginAsync(this, MobileServiceAuthenticationProvider.Facebook);
                success = true;
            }
            catch (Exception ex)
            {
                CreateAndShowDialog(ex, "Authentication failed");
            }
            return success;
        }

        [Java.Interop.Export()]
        public async void LoginUser(View view)
        {
            // Load data only after authentication succeeds.
            if (await Authenticate())
            {
                //Hide the button after authentication succeeds.
                FindViewById<Button>(Resource.Id.buttonFbSignIn).Visibility = ViewStates.Gone;

                NavigateToPathSelection();
            }
        }
    }
}