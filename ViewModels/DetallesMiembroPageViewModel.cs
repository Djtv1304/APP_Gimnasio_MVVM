using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace APP_Gimnasio.ViewModels
{
    public class DetallesMiembroPageViewModel
    {

        public string getIdMiembro()
        {

            return Preferences.Get("idMiembro", "0");

        } 
        
        public string getNombresCompletos()
        {

            string nombre = Preferences.Get("nombre", "0");
            string apellido = Preferences.Get("apellido", "0");

            return $"{nombre} {apellido}";

        }   

        public string getCorreo()
        {

            return Preferences.Get("email", "0");

        }

        public string getFechaInscripcion()
        {

            return Preferences.Get("fechaInscripcion", "0");

        }

        public void resetUsuario()
        {

            Preferences.Set("idMiembro", "0");

        }

        public ICommand OnClickCambiar =>
            new Command(async () =>
            {

                await App.Current.MainPage.Navigation.PushAsync(new CambioContra());

            });

        public ICommand OnClickCerrarSesion =>
            new Command(async () =>
            {

                resetUsuario();
                await App.Current.MainPage.Navigation.PushAsync(new LoginPage());

            });

    }
}
