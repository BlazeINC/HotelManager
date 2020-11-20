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
    public class Botones
    {
        public string Name { get; set; }
        public string ImageUrl { get; set; }
    }

    public partial class Home : ContentPage
    {
        public Home()
        {
             Botones nuevo = new Botones
            {
                Name = "Hotel",
                ImageUrl = "https://q-cf.bstatic.com/images/hotel/max1024x768/211/211874461.jpg"
            };
            Botones nuevo2 = new Botones
            {
                Name = "Alberca",
                ImageUrl = "https://r-cf.bstatic.com/images/hotel/max1024x768/182/182033193.jpg"
            };
            Botones nuevo3 = new Botones
            {
                Name = "Menu",
                ImageUrl = "https://sevilla.abc.es/gurme/wp-content/uploads/sites/24/2012/01/comida-rapida-casera.jpg"
            };
            Botones nuevo4 = new Botones
            {
                Name = "Gimnasio",
                ImageUrl = "https://img.freepik.com/foto-gratis/equipos-gimnasio-gimnasio_23-2147949744.jpg?size=626&ext=jpg"
            };
            Botones nuevo5 = new Botones
            {
                Name = "Reservación",
                ImageUrl = "https://www.eluniversal.com.mx/sites/default/files/styles/f03-651x400/public/2017/11/15/hoteles_secretos_destinos.jpg?itok=OlJp51eq&c=7dc3660e9a184118fe4e88cb2c9f789a"
            };
            InitializeComponent();
            var bot = new List<Botones>
            {
                nuevo,nuevo2,nuevo3,nuevo4,nuevo5
            };          
            Carrusel.ItemsSource = bot;
        }
        public void Carrusel_ItemSelected (object sender, SelectedItemChangedEventArgs e)
        {
           /* Botones tipo = e.SelectedItem as Botones;
            if(tipo.Name == "Hotel")
                Navigation.PushAsync(new Page1());*/
        }
        private void Button_Clicked(object sender, EventArgs e)
        {
            Botones u = Carrusel.CurrentItem as Botones;
            switch(u.Name)
            {
                case "Hotel": Navigation.PushAsync(new Page1()); break;
                case "Alberca": Navigation.PushAsync(new Alberca()); break;
                case "Menu": Navigation.PushAsync(new Menu()); break;
                case "Gimnasio": Navigation.PushAsync(new Gym()); break;
                case "Reservación": Navigation.PushAsync(new Page2()); break;
            }
                
        }
    }
}