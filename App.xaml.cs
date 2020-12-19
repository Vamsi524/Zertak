﻿using MobileGuide.Services;
using MobileGuide.Views;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MobileGuide
{
    public partial class App : Application
    {
        public static RestService RestService { get; private set; }

        public App()
        {
            InitializeComponent();

            DependencyService.Register<MockDataStore>();
            RestService = new RestService();
            MainPage = new AppShell();
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
