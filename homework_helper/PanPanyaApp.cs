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
using Microsoft.WindowsAzure.MobileServices;

namespace homework_helper
{
    [Application]
    class PanPanyaApp: Application
    {
        public PanPanyaApp(IntPtr handle, JniHandleOwnership transfer): base(handle, transfer)
        {
            CurrentPlatform.Init();
            client = new MobileServiceClient(applicationURL);
        }

        const string applicationURL = @"https://homework-helper.azurewebsites.net";

        private MobileServiceClient client;
        public MobileServiceClient Client
        {
            get
            {
                return client;
            }
        }

        private MobileServiceUser user;
        public MobileServiceUser User
        {
            get
            {
                return user;
            }
            set
            {
                user = value;
            }
        }
    }
}