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
        public class menus
        {
            public string Nombre { get; set; }
            public string Image { get; set; }
            public string Descripcion { get; set; }
            public int Precio { get; set; }
        }
        
    public partial class Menu : ContentPage
    {

       //   List<menus> listamenu = new List<menus>();
        public Menu()
        {
            menus m1 = new menus()
            {
                Nombre = "Hamburguesa",
                Image= "https://cdn-3.expansion.mx/dims4/default/48dba1f/2147483647/strip/true/crop/690x362+0+33/resize/1200x630!/quality/90/?url=https%3A%2F%2Fcherry-brightspot.s3.amazonaws.com%2Fc7%2F1a%2Fe2b540d24bab9e29edb5117c5f68%2Fbaconperfectionburgerparmfries-5214.jpg",
                Descripcion= "Hamburguesa con carne de cerdo, queso suizo, piña a la parrilla, mayonesa, pepinillos, aderezada con salsa chipotle y miel, más papas a la francesa sazonadas con chimi-parmesano.",
                Precio=100
            };
            menus m2 = new menus()
            {
                Nombre = "Costillas de cerdo",
                Image = "https://cdn.kiwilimon.com/articuloimagen/26894/26899.jpg",
                Descripcion = "Costillas de cerdo ahumadas y bañadas con la salsa de tu elección. Se sirven con papas fritas y elote.",
                Precio = 150
            };
            menus m3 = new menus()
            {
                Nombre = "Pizza",
                Image = "https://www.laespanolaaceites.com/wp-content/uploads/2019/06/pizza-con-chorizo-jamon-y-queso-1080x671.jpg",
                Descripcion = "Pizza de pepperoni y chorizo, pan grueso y mucho queso",
                Precio = 90
            };
            InitializeComponent();

            var m = new List<menus>
            {
                m1,m2,m3
            };
            MenuLista.ItemsSource = m;
        }

        private async void Menu_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            menus o = e.CurrentSelection.FirstOrDefault() as menus;
            if(o!=null)
            {
            bool yn = await DisplayAlert("Seleccion", "Desea añadir a la lista para ordenar", "OK", "Cancelar");
            if(yn)
            {
                    App.ord.Add(o);
                MenuLista.SelectedItem = null;
                UpdateChildrenLayout();
            }
            }

        }

        private async void ToolbarItem_Clicked(object sender, EventArgs e)
        {
            if(App.ord.Count>0)
            {
                await Navigation.PushAsync(new ListaMenu());
            }
            else
            {
                await DisplayAlert("Error", "No ha añadido nada a la lista", "OK");
            }
        }
    }
}