﻿using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace LeituraExposicao
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
#if DEBUG
            //HotReloader.Current.Run(this);
            HotReloader.Current.Run(this, new HotReloader.Configuration { DeviceUrlPort = 15000 });
#endif

            MainPage = new NavigationPage(new MainPage());
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
