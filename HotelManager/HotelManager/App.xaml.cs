using HotelManager.Models;
using HotelManager.Views.Forms;
using Microsoft.WindowsAzure.MobileServices;
using System;
using System.Collections.Generic;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace HotelManager
{
    public partial class App : Application
    {
        public static string DatabaseLocation = string.Empty;
        public static MobileServiceClient client = new MobileServiceClient("https://hotelmanagerwebapp.azurewebsites.net");
        public static Usuarios sesion = new Usuarios();
        public static List<Reservacion> reservaciones = new List<Reservacion>();
        public static List<menus> ord = new List<menus>();
        public static string BaseImageUrl { get; } = "https://cdn.syncfusion.com/essential-ui-kit-for-xamarin.forms/common/uikitimages/";
        public App()
        {
            Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense("MjU5MjMyQDMxMzgyZTMxMmUzMGFGV0lJclMzN0t6NkxGUkNsOTlRZUhEbkh3U3g2MVIrYzNJQTB1K2hZeGs9");
            InitializeComponent();

            MainPage = new NavigationPage(new SimpleLoginPage());
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
