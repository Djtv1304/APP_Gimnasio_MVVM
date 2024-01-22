using APP_Gimnasio.Models;
using PropertyChanged;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace APP_Gimnasio.ViewModels
{
    [AddINotifyPropertyChangedInterface]
    public class HistorialPagoPageViewModel
    {

        public ObservableCollection<Pago> listaPagos { get; set;}

        public HistorialPagoPageViewModel()
        {

            cargarPagos();

        }

        public string getIdMiembro()
        {

            return Preferences.Get("idMiembro", "0");

        }
        public string getCorreo()
        {

            return Preferences.Get("email", "0");

        }

        public async Task<List<Pago>> GetPagos()
        {

            int.TryParse(getIdMiembro(), out int id);

            List<Pago> ListaPagos = await Util.Util._APIService.GetPagosPorMiembro(id);

            return ListaPagos;

        }

        public async void cargarPagos()
        {

            listaPagos = new ObservableCollection<Pago>(await GetPagos());

        }

        public ICommand OnClickNuevoPago =>
            new Command(async () =>
            {

                await Application.Current.MainPage.Navigation.PushAsync(new NuevoPagoPage());

            });

    }
}
