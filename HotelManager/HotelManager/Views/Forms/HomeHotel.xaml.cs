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
    public partial class HomeHotel : ContentPage
    {
        public HomeHotel()
        {
            var depa = new List<string>
            { "Recepción","Limpieza","Restaurante"
            };

            InitializeComponent();
            Lista.ItemsSource = depa;
            UpdateChildrenLayout();
        }

        private void Lista_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string l = e.CurrentSelection.FirstOrDefault() as string;
            switch (l)
            {
                case "Recepción": Navigation.PushAsync(new DepartamentoMsg(3)); break;
            case "Limpieza": Navigation.PushAsync(new DepartamentoMsg(1)); break;
            case "Restaurante": Navigation.PushAsync(new DepartamentoMsg(2)); break;
            }
            Lista.SelectedItem = null;
            UpdateChildrenLayout();
        }
    }
}