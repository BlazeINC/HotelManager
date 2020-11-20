
using HotelManager.Models;
using Xamarin.Forms.Internals;
using Xamarin.Forms.Xaml;

namespace HotelManager.Views.Forms
{
    /// <summary>
    /// Page to sign in with user details.
    /// </summary>
    [Preserve(AllMembers = true)]
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SimpleSignUpPage
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SimpleSignUpPage" /> class.
        /// </summary>
        public SimpleSignUpPage()
        {
            InitializeComponent();
        }

        private async void SfButton_Clicked(object sender, System.EventArgs e)
        {
            if(PasswordEntry.Text == ConfirmPasswordEntry.Text && NameEntry.Text!=string.Empty)
            {
                Usuarios usuario = new Usuarios
                {
                    Login = NameEntry.Text,
                    Password = PasswordEntry.Text,
                    Email = Email.gettext(),
                    Res = 0,
                Msg = 0
                };
                registro.IsEnabled = false;
                await App.client.GetTable<Usuarios>().InsertAsync(usuario);
                
               await DisplayAlert("Excelente", "Se ha registrado correctamente", "OK");
               await Navigation.PopAsync();
            }
            else
            {
                await DisplayAlert("Error", "Las contraseñas no son iguales o no se ha Ingresado Nombre","OK");
            }
            
        }
    }
}