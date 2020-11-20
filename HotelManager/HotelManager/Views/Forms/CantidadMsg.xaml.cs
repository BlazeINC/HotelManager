using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HotelManager.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace HotelManager.Views.Forms
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CantidadMsg : ContentPage
    {

        Mensaje mensaje = new Mensaje();
        Reservacion r = new Reservacion();
        public CantidadMsg(string Producto, int tipo)
        {
            InitializeComponent();
            label.Text = Producto;
            mensaje.Tipo = tipo;
            mensaje.IDHuesped = App.sesion.ID;
            var cuartos = App.reservaciones;
            Lista.ItemsSource = cuartos;
        }
        private async void Button_Clicked(object sender, EventArgs e)
        { 
            if(r.ID!=string.Empty && Cantidad.Value>0)
            {
            mensaje.Msg="Cuarto:"+r.Room.ToString()+"|"+label.Text +":"+Cantidad.Value.ToString()+"|";
           await App.client.GetTable<Mensaje>().InsertAsync(mensaje);
            await DisplayAlert("Excelente", "Se ha registrado correctamente su pedido", "OK");
            await Navigation.PopAsync();
            }
            else
            {
                await DisplayAlert("Error", "No ha escogido un cuarto o cantidad", "OK");
            }

        }

        private void Cantidad_ValueChanged(object sender, ValueChangedEventArgs e)
        {
            label2.Text = "Cantidad: " + Cantidad.Value.ToString();
        }

        private void Lista_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            r = e.CurrentSelection.FirstOrDefault() as Reservacion;
        }
    }
}