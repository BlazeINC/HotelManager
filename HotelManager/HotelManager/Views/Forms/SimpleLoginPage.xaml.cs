
using HotelManager.Models;
using System;
using System.Linq;
using Xamarin.Forms;
using Xamarin.Forms.Internals;
using Xamarin.Forms.Xaml;

namespace HotelManager.Views.Forms
{
    /// <summary>
    /// Page to login with user name and password
    /// </summary>
    [Preserve(AllMembers = true)]
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SimpleLoginPage
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SimpleLoginPage" /> class.
        /// </summary>
        public SimpleLoginPage()
        {
            InitializeComponent();
            App.ord.Clear();
            App.reservaciones.Clear();
            App.sesion = null;
            var assembly = typeof(SimpleLoginPage);
            imglogo.Source = ImageSource.FromResource("HotelManager.Assets.img.logo_Azul.png", assembly);
        }

        private void SfButton_Clicked(object sender, System.EventArgs e)
        {
            Navigation.PushAsync(new SimpleSignUpPage());
        }

        private async void SfButton_Clicked_Login(object sender, System.EventArgs e)
        {
            
            if(string.IsNullOrEmpty(email.gettext())||string.IsNullOrEmpty(PasswordEntry.Text))
            {
              await  DisplayAlert("Error", "Esta vacio", "OK");
            }
            else
            {
                var usuario = (await App.client.GetTable<Usuarios>().Where(u => u.Email == email.gettext()).ToListAsync()).FirstOrDefault();
                if(usuario != null && usuario.Password == PasswordEntry.Text && usuario.Email!=null)
                {
                    App.sesion = usuario;
                    if(usuario.Tipo==1)
                    {
                        var reservacion = (await App.client.GetTable<Reservacion>().Where(u => u.IDCliente == usuario.ID).ToListAsync());
                        if(reservacion!=null)
                        {
                           for(int i=0;i<reservacion.Count();i++)
                            {
                                reservacion[i].ValidaReservacion();
                                if(reservacion[i].Estatus==1)
                                {
                                    App.reservaciones.Add(reservacion[i]);
                                }
                            }
                           if(App.reservaciones.Count()>0)
                            {
                        await Navigation.PushAsync(new Home());
                            }
                           else
                            {
                                await DisplayAlert("Error", "No tiene reservaciones CONFIRMADAS, pase a recepción para confirmar", "OK");
                            }

                        }
                        else
                        {
                            await DisplayAlert("Error", "No tiene reservacines vigentes", "OK");
                        }

                    }
                   else
                    {
                        await Navigation.PushAsync(new HomeHotel());
                    }
                }
                else
                {
                    await DisplayAlert("Error", "La contraseña o el Email son incorrectos", "OK");
                }
            }
            
           
        }
    }
}