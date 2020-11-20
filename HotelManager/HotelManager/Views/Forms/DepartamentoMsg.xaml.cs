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
    public partial class DepartamentoMsg : ContentPage
    {
         List<Mensaje> msg = new List<Mensaje>();
        int de;
        public  DepartamentoMsg(int depa)
        {
            de = depa;
            InitializeComponent();
             Boton.IsEnabled = false;
            Boton.IsVisible = false;
            if(depa == 3)
            {
                Boton.IsVisible = true;
                Boton.IsEnabled = true;
            }
            Lista.ItemsSource = msg;
            Initi();
            UpdateChildrenLayout();
        }
        public async void Initi()
        {
              msg = (await App.client.GetTable<Mensaje>().Where(u => u.Tipo == de).ToListAsync()); 
              Lista.ItemsSource = msg;
            UpdateChildrenLayout();
        }
        private void Boton_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new ConfirmarReservacion());
        }

        private async void Lista_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Mensaje m = e.CurrentSelection.FirstOrDefault() as Mensaje;
         string res = await DisplayActionSheet("Desea:", "Cancelar", null, "Empezar", "Finalizar");
            if(res == "Empezar")
            {
                m.Msg += "EN CURSO:" + App.sesion.Login;
                await App.client.GetTable<Mensaje>().UpdateAsync(m);
                msg = (await App.client.GetTable<Mensaje>().Where(u => u.Tipo == de).ToListAsync());
                Lista.ItemsSource = msg;
            }
            else
            {
                if(res=="Finalizar")
                {
                     await App.client.GetTable<Mensaje>().DeleteAsync(m);
                    msg = (await App.client.GetTable<Mensaje>().Where(u => u.Tipo == de).ToListAsync());
                    Lista.ItemsSource = msg;
                }
            }
          UpdateChildrenLayout();
        }
    }
}