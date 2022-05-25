using AMP.Views;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AMP
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            //MainPage = new LoginPage();
            MainPage = new NavigationPage(new LoginPage())
            {
                BarBackgroundColor = Color.Blue,
                BarTextColor = Color.White,
            };

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
