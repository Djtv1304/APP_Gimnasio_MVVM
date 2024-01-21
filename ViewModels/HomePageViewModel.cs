using APP_Gimnasio.Models;
using Microsoft.Maui.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace APP_Gimnasio.ViewModels
{
    public class HomePageViewModel
    {

        public async void validarLogin()
        {

            if (Preferences.Get("idMiembro", "0").Equals("0"))
            {

                await App.Current.MainPage.Navigation.PushAsync(new LoginPage());

            }

        }

        public string getCorreo()
        {

            return Preferences.Get("email", "0");

        }

        public string getIdMiembro()
        {

            return Preferences.Get("idMiembro", "0");

        }

        public string getIdMembresia()
        {

            return Preferences.Get("idMembresia", "0");

        }

        public ICommand OnClickHistorialPagos =>
            new Command(async () =>
            {

                await App.Current.MainPage.Navigation.PushAsync(new HistorialPagoPage());

            });

        public ICommand OnClickHistorialVisitas =>
            new Command(async () =>
            {

                await App.Current.MainPage.Navigation.PushAsync(new HistorialVisitasPage());

            });

        public ICommand OnClickDetallesMembresia =>
            new Command(async () =>
            {

                int.TryParse(getIdMembresia(), out int id);
                Membresia membresia = await Util.Util._APIService.GetMembresiaByID(id);

                Preferences.Set("nombreMembresia", membresia.nombreMembresia);
                Preferences.Set("duracionMembresia", membresia.duracionMembresia.ToString());
                Preferences.Set("precioMembresia", membresia.precioMembresia.ToString());

                await App.Current.MainPage.Navigation.PushAsync(new DetallesMembresiaPage());

            });

        public ICommand OnClickDetallesMiembro =>
            new Command(async () =>
            {

                await App.Current.MainPage.Navigation.PushAsync(new DetallesMiembroPage());

            });

    }
}
