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

        public ImageSource QrCodeImage { get; set; }

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

        public async Task GenerateQrCode()
        {

            Miembro miembroVisitante = await getMiembro();

            var barcodeWriter = new ZXing.Mobile.BarcodeWriter
            {
                Format = ZXing.BarcodeFormat.QR_CODE,
                Options = new ZXing.Common.EncodingOptions
                {
                    Width = 300,
                    Height = 300
                }
            };

            var barcode = barcodeWriter.Write("Bienvenido " + miembroVisitante.nombreMiembro + " a tu gimnasio favorito!");
            QrCodeImage = ImageSource.FromStream(() => new MemoryStream(barcode));

        }

    }
}
