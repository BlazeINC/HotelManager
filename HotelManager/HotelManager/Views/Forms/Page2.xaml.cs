using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace HotelManager.Views.Forms
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Page2 : ContentPage
    {
        public Page2()
        {
            InitializeComponent();
            Lista.ItemsSource = App.reservaciones;
            var assembly = typeof(Page2);
            ImagenRes.Source = ImageSource.FromResource("HotelManager.Assets.img.logo_Azul.png", assembly);
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            Device.OpenUri(new System.Uri("https://docs.google.com/forms/d/e/1FAIpQLSdyagoELdpIcNIlDb_w-ln_ySdvqyTumniEP2QbmmT5nyoH5w/viewform?usp=sf_link"));
        }
    }
}