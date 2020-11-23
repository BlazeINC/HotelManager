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
    public class Limpieza
        {
        public string Atriculo { get; set; }
        public int cantidad { get; set; }

    }
    public partial class Page1 : ContentPage
    {
       
        public Page1()
        {
            
            Limpieza Toallas = new Limpieza
            {
                Atriculo = "Toallas",
                cantidad = 0
            };
            Limpieza Sabanas = new Limpieza
            {
                Atriculo = "Sabanas o Cobijas",
              cantidad = 0
            };
            Limpieza Pillow = new Limpieza
            {
                Atriculo = "Almohadas",
                cantidad = 0
            };
           InitializeComponent(); 
            var Clean = new List<Limpieza>
            {
                Toallas,Sabanas,Pillow
            };
            var assembly = typeof(Page1);
            imglimpieza.Source = ImageSource.FromResource("HotelManager.Assets.img.herramientas-de-limpieza.png",assembly);
            Lista.ItemsSource = Clean;
            
        }

        private void Lista_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Limpieza l = e.CurrentSelection.FirstOrDefault() as Limpieza;
            if(l!=null)
                switch (l.Atriculo)
                { 
                     case "Almohadas": Navigation.PushAsync(new CantidadMsg("Almohadas",1)); break;
                    case "Toallas": Navigation.PushAsync(new CantidadMsg("Toallas",1)); break;
                case "Sabanas o Cobijas": Navigation.PushAsync(new CantidadMsg("Sabanas y/o Cobijas",1)); break;
            }

            Lista.SelectedItem = null;
            //UpdateChildrenLayout();

        }
    }
}