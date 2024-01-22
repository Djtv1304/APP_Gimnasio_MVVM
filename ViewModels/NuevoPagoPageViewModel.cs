using APP_Gimnasio.Models;
using CommunityToolkit.Maui.Alerts;
using CommunityToolkit.Maui.Core;
using Microsoft.Maui.Controls;
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
    public class NuevoPagoPageViewModel
    {
        public DateTime PagoFecha { get; set; }
        public TimeSpan CaducidadHora { get; set; }
        public DateTime CaducidadFecha { get; set; }
        public string MontoPago { get; set; }
        public string TarjetaSeleccionada { get; set; }
        public string NumTarjeta { get; set; }
        public string CVV { get; set; }
        public string Titular { get; set; }

        public ObservableCollection<string> OpcionesTarjetas { get; set; }

        public NuevoPagoPageViewModel()
        {

            OpcionesTarjetas = new ObservableCollection<string>
            {
                "Visa",
                "MasterCard",
                "American Express"
            };

        }

        public string getIdMiembro()
        {

            return Preferences.Get("idMiembro", "0");

        }

        public ICommand OnClickPagar =>
            new Command(async () =>
            {

                try
                {
                    // Obtener valores de los controles de la interfaz de usuario
                    DateTime fechaActual = DateTime.Now; // Obtener la fecha y hora actual
                    DateTime fechaYHoraSeleccionada = new DateTime(fechaActual.Year, fechaActual.Month, fechaActual.Day, CaducidadHora.Hours, CaducidadHora.Minutes, CaducidadHora.Seconds);
                    DateTime fechaPago = fechaYHoraSeleccionada;

                    double montoPago;

                    if (!double.TryParse(MontoPago, out montoPago) || montoPago <= 0)
                    {
                        // Mostrar un Toast indicando que el monto no es válido
                        var toast = Toast.Make("Ingrese un monto válido y positivo", ToastDuration.Short, 14);
                        await toast.Show();
                        return;
                    }

                    string tipoTarjeta = TarjetaSeleccionada; // Obtener el valor seleccionado del Picker
                    string numeroTarjeta = NumTarjeta;
                    string cvvTarjeta = CVV;
                    DateTime caducidadTarjeta = CaducidadFecha.Date;
                    string titularTarjeta = Titular;

                    int.TryParse(getIdMiembro(), out int id);

                    // Validar que la fecha de pago no sea anterior a hoy
                    if (fechaPago < DateTime.Today)
                    {
                        // Mostrar un Toast indicando que la fecha de pago no es válida
                        var toast = Toast.Make("La fecha de pago no puede ser anterior a hoy", ToastDuration.Short, 14);
                        await toast.Show();
                        return;
                    }

                    // Validar que la fecha de caducidad no sea anterior a hoy
                    if (caducidadTarjeta < DateTime.Today)
                    {
                        // Mostrar un Toast indicando que la fecha de caducidad no es válida
                        var toast = Toast.Make("La fecha de caducidad no puede ser anterior a hoy", ToastDuration.Short, 14);
                        await toast.Show();
                        return;
                    }

                    // Construir el objeto de Pago
                    Pago nuevoPago = new Pago
                    {
                        miembroId = id,
                        fechaPago = fechaPago,
                        montoPago = montoPago,
                        tipoTarjeta = tipoTarjeta,
                        numeroTarjeta = numeroTarjeta,
                        cvvTarjeta = cvvTarjeta,
                        caducidadTarjeta = caducidadTarjeta,
                        titularTarjeta = titularTarjeta
                    };

                    // Llamar al servicio para realizar el pago
                    await RealizarPago(nuevoPago);
                }
                catch (Exception ex)
                {

                    // Mostrar un Toast indicando que ocurrió un error
                    var toast = Toast.Make($"Ocurrió un error al procesar el pago\nError: {ex.Message}", ToastDuration.Long, 14);
                    await toast.Show();

                }

            });

        private async Task RealizarPago(Pago nuevoPago)
        {

            // Llamar a tu servicio para realizar el pago
            await Util.Util._APIService.CreatePago(nuevoPago);
            var toast = Toast.Make("Pago realizado", ToastDuration.Short, 14);
            await toast.Show();
            // VERIFICAR
            await App.Current.MainPage.Navigation.PopAsync();
            await App.Current.MainPage.Navigation.PopAsync();

        }

        public ICommand OnClickRegresar =>
            new Command(async () =>
            {

                // VERIFICAR
                await Application.Current.MainPage.Navigation.PopAsync();

            });

    }
}
