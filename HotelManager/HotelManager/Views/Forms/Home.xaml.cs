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
        public ImageSource ImageUrl { get; set; }

        
    }

    public partial class Home : ContentPage
    {
        public Home()
        {
            
            var assembly = typeof(Home);
            Botones nuevo = new Botones
            {
                Name = "Limpieza",
                ImageUrl = "https://image.flaticon.com/icons/png/512/1837/1837476.png"
                //https://q-cf.bstatic.com/images/hotel/max1024x768/211/211874461.jpg
            };
            /*Botones nuevo2 = new Botones
            {
                Name = "Alberca",
                ImageUrl = "https://r-cf.bstatic.com/images/hotel/max1024x768/182/182033193.jpg"
            };*/
            Botones nuevo3 = new Botones
            {
                Name = "Menu",
                ImageUrl = "https://cdn.icon-icons.com/icons2/1774/PNG/512/019plate1_114171.png"
            };
            Botones nuevo4 = new Botones
            {
                Name = "Instalaciones",
                ImageUrl = "https://png.pngtree.com/png-vector/20190121/ourlarge/pngtree-vector-swimming-pool-icon-png-image_333406.jpg"
            };
            Botones nuevo5 = new Botones
            {
                Name = "Mi Cuenta",
                ImageUrl = "https://pngimage.net/wp-content/uploads/2018/05/atencion-al-cliente-icono-png-8.png"
            };
            InitializeComponent();
            var bot = new List<Botones>
            {
                nuevo,nuevo3,nuevo4,nuevo5
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
                case "Limpieza": Navigation.PushAsync(new Page1()); break;
                case "Alberca": Navigation.PushAsync(new Alberca()); break;
                case "Menu": Navigation.PushAsync(new Menu()); break;
                case "Instalaciones": Navigation.PushAsync(new Gym()); break;
                case "Mi Cuenta": Navigation.PushAsync(new Page2()); break;
            }
                
        }
    }
}