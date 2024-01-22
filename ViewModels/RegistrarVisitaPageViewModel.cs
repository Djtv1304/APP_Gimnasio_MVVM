using APP_Gimnasio.Models;
using PropertyChanged;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace APP_Gimnasio.ViewModels
{
    [AddINotifyPropertyChangedInterface]
    public class RegistrarVisitaPageViewModel
    {

        public string QrCode { get; set; }

        public RegistrarVisitaPageViewModel()
        {

            GenerateQrCode();

        }

        public string getIdMiembro()
        {

            return Preferences.Get("idMiembro", "0");

        }

        public async Task<Miembro> getMiembro()
        {

            int.TryParse(getIdMiembro(), out int id);

            Miembro miembro = await Util.Util._APIService.GetMiembroByID(id);

            return miembro;

        }

        public async void GenerateQrCode()
        {

            Miembro miembroVisitante = await getMiembro();

            QrCode = $"Bienvenido {miembroVisitante.nombreMiembro} a su gimnasio favorito!";

        }
    }
}
