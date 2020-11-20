using HotelManager.Models;
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

    public partial class ListaMenu : ContentPage
    {
       // List<menus> orden = new List<menus>();
        Reservacion r = new Reservacion();
        public ListaMenu()
        {
            if(App.ord.Count>0)
            {
            InitializeComponent();
            MenuLista.ItemsSource = App.ord;
            total();
            Cuartos.ItemsSource = App.reservaciones;
            }
            else
            {
                Navigation.PopAsync();
            }
        }
        public void total()
        {
            int Total = 0;
            for(int i=0;i<App.ord.Count();i++)
            {    
                  Total  = Total + App.ord[i].Precio;
            }
            TotalL.Text = Total.ToString();
        }

        private async void ToolbarItem_Clicked(object sender, EventArgs e)
        {
            bool yn = await DisplayAlert("Orden", "Desea Ordenar?", "Ok", "Cancelar");
            if(yn)
            {
                Mensaje mensaje = new Mensaje
                {
                    IDHuesped = App.sesion.ID,
                    Tipo = 2,
                    Estatus=1,
                };
                mensaje.Msg = "Cuartos:" + r.Room+" Hora:"+DateTime.Now.TimeOfDay.ToString();
                foreach(menus i in App.ord)
                {
                    mensaje.Msg +=" |"+i.Nombre;
                }
                await App.client.GetTable<Mensaje>().InsertAsync(mensaje);
                await DisplayAlert("Orden", "Se realizó su orden", "Ok");
                App.ord.Clear();
                await Navigation.PopAsync();
            }
        }

        private async void MenuLista_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            menus m = e.CurrentSelection.FirstOrDefault() as menus;
            if(m!=null)
            {
            bool yn =await DisplayAlert("Orden", "Desea eliminar de la orden?", "Ok", "Cancelar");
           if(yn)
            {
                App.ord.Remove(m);
                MenuLista.ItemsSource = App.ord;
                    MenuLista.SelectedItem = null;
                    total();
                    //UpdateChildrenLayout();
                    await Navigation.PushAsync(new ListaMenu());
            }
           else
            {
                MenuLista.SelectedItem = null;
                UpdateChildrenLayout();
            }
            }

        }

        private void Cuartos_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            r = e.CurrentSelection.FirstOrDefault() as Reservacion;
        }
    }
}