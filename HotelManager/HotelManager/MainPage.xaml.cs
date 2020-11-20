using HotelManager.Views.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.PlatformConfiguration.GTKSpecific;

namespace HotelManager
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }
       
        private void BtnLogin_Clicked(object sender, EventArgs e)
        {
            if(string.IsNullOrEmpty(TextUsuario.Text) || string.IsNullOrEmpty(TextUsuario.Text))
            {

            }
            else
            {
              
            }
        }
    }
}
