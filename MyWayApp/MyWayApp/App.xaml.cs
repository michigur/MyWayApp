using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using MyWayApp.Models;
using MyWayApp.Views;
using System.Collections.Generic;


namespace MyWayApp
{
    public partial class App : Application
    {

        public static bool IsDevEnv
        {
            get
            {
                return true; //change this before release!
            }
        }
        public App()
        {
            InitializeComponent();

            MainPage = new MainPage();
        }

        public Client CurrentUser { get; set; }
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
