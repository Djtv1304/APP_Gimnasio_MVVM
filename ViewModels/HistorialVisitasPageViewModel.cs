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
    public class HistorialVisitasPageViewModel
    {

        public ObservableCollection<Visita> listaVisitas { get; set;}

        public HistorialVisitasPageViewModel()
        {

           cargarVisitas();

        }

        public string GetIdMiembro()
        {

            return Preferences.Get("idMiembro", "0");

        }

        public string GetCorreo()
        {

            return Preferences.Get("email", "0");

        }

        public async Task<List<Visita>> GetVisitas()
        {

            int.TryParse(GetIdMiembro(), out int id);

            List<Visita> ListaVisitas = await Util.Util._APIService.GetVisitasPorMiembro(id);

            return ListaVisitas;

        }

        public async void cargarVisitas()
        {

            listaVisitas = new ObservableCollection<Visita>(await GetVisitas());

        }

        public ICommand OnClickRegistrarVisita =>
            new Command(async () =>
            {

                await App.Current.MainPage.Navigation.PushAsync(new RegistrarVisitaPage());

            });


    }
}
