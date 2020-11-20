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
    public partial class ConfirmarReservacion : ContentPage
    {
        public ConfirmarReservacion()
        {
            InitializeComponent();
            var reservacion = new List<Reservacion>();
            Lista.ItemsSource = reservacion;

        }

        private async void Buscar_Clicked(object sender, EventArgs e)
        {
            var usuario = (await App.client.GetTable<Usuarios>().Where(u => u.Email == Email.Text).ToListAsync()).FirstOrDefault();
            if (usuario != null && Nombre.Text == usuario.Login)
            {
                var reservacion = (await App.client.GetTable<Reservacion>().Where(u => u.IDCliente == usuario.ID && u.Entrada<=DateTime.Today && u.Estatus==0).ToListAsync());
                if(reservacion.Count()>0)
                {
                    
                    Lista.ItemsSource = reservacion;
                    UpdateChildrenLayout();
                    await DisplayAlert("Encontrado","Se encontraron reservaciones","OK");
                }
                else
                {
                    await DisplayAlert("No Encontrado", "No se encontraron reservaciones", "OK");
                }
            }
            else
            {
                await DisplayAlert("Error", "El nombre o el Email son incorrectos", "OK");
            }
        }

        private async void Lista_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Reservacion reservacion = e.CurrentSelection.FirstOrDefault() as Reservacion;
            bool yn = await DisplayAlert("Confirmar Reservación", "Desea confirmar esta reservación", "OK", "NO");
            if (yn)
            {
                reservacion.Estatus = 1;
                await App.client.GetTable<Reservacion>().UpdateAsync(reservacion);
                UpdateChildrenLayout();
            }
        }

        private void Nueva_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new NuevaReservacion());
        }
    }
}