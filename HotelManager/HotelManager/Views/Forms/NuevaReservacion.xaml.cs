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
    public partial class NuevaReservacion : ContentPage
    {
        public NuevaReservacion()
        {
            InitializeComponent();
            Entrada.MinimumDate = DateTime.Now;
            Entrada.Date = DateTime.Now;
            Salida.MinimumDate = DateTime.Now.AddDays(1);
            Salida.Date = DateTime.Now.AddDays(2);
        }

        private async void confirmar_Clicked(object sender, EventArgs e)
        {
            var usuario = (await App.client.GetTable<Usuarios>().Where(u => u.Email == Email.Text && u.Login == Nombre.Text).ToListAsync()).FirstOrDefault();
            if(usuario!=null)
            {
                if(Entrada.Date<Salida.Date)
                {
                Reservacion res = new Reservacion
                {
                    IDCliente = usuario.ID,
                    Room = Convert.ToInt16(Cuarto.Text),
                    Entrada = Entrada.Date,
                    Salida = Salida.Date,
                    Estatus = 0
                };
                    await App.client.GetTable<Reservacion>().InsertAsync(res);
                    await DisplayAlert("Bienvenido", "Su reservación esta completa", "OK");
                    await Navigation.PopAsync();
                }
                else
                {
                    await DisplayAlert("Error","Las fechas esta incorrectas","OK");
                }

            }
        }
    }
}