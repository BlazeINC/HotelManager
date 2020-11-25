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
            var assembly = typeof(DepartamentoMsg);
            if(depa == 3)
            {
                imgdepa.Source = ImageSource.FromResource("HotelManager.Assets.img.llave-de-hotel.png", assembly);
                Boton.IsVisible = true;
                Boton.IsEnabled = true;
                
            }
            else
            {
                if(depa==1)
                    {
                    imgdepa.Source = ImageSource.FromResource("HotelManager.Assets.img.limpieza_1.png", assembly);
                }
                else
                {
                    if(depa==2)
                    {
                        imgdepa.Source = "https://cdn.icon-icons.com/icons2/1774/PNG/512/019plate1_114171.png";
                    }
                }
            }
            Lista.ItemsSource = msg;
            Initi();
            UpdateChildrenLayout();
        }   
        override protected void OnAppearing()
        {
            switch(de)
            {
                case 1: Title = "Limpieza"; break;
                case 2: Title = "Restaurante"; break;
                case 3: Title = "Recepción"; break;
            }
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