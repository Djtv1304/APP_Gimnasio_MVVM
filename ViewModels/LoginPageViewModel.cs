

using APP_Gimnasio.Models;
using APP_Gimnasio.Util;
using CommunityToolkit.Maui.Alerts;
using CommunityToolkit.Maui.Core;
using Microsoft.Maui.Controls;
using PropertyChanged;
using System.Windows.Input;

namespace APP_Gimnasio.ViewModels
{
    [AddINotifyPropertyChangedInterface]
    public class LoginPageViewModel
    {

        public string Username { get; set; }

        public string Password { get; set; }



        public ICommand OnClickLogin =>
            new Command(async () => {

                Miembro miembro = new Miembro
                {
                    emailMiembro = Username,
                    passwordMiembro = Password,
                };

                
                Miembro miembro2 = await Util.Util._APIService.LoginMiembro(miembro);

                if (miembro2 != null)
                {
                    Preferences.Set("idMiembro", miembro2.idMiembro.ToString());
                    Preferences.Set("idMembresia", miembro2.idMembresia.ToString());
                    Preferences.Set("nombre", miembro2.nombreMiembro);
                    Preferences.Set("apellido", miembro2.apellidoMiembro);
                    Preferences.Set("email", miembro2.emailMiembro);
                    Preferences.Set("fechaInscripcion", miembro2.fechaInscripcion.ToString());


                    var toast = Toast.Make("Ingreso Correcto", ToastDuration.Short, 14);
                    await toast.Show();
                    
                    await App.Current.MainPage.Navigation.PushAsync(new HomePage());
                }
                else
                {
                    var toast = Toast.Make("Nombre de usuario o password incorrecto", ToastDuration.Short, 14);
                    await toast.Show();
                }

            });

    }
}
