using APP_Gimnasio.Models;
using CommunityToolkit.Maui.Alerts;
using CommunityToolkit.Maui.Core;
using PropertyChanged;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace APP_Gimnasio.ViewModels
{
    [AddINotifyPropertyChangedInterface]
    public class CambioContraViewModel
    {

        public string passwordActual { get; set; }

        public string passwordNueva { get; set; }

        public string getIdMiembro()
        {

            return Preferences.Get("idMiembro", "0");

        }

        public ICommand OnClickCambiarContra =>
            new Command(async () =>
            {

                int.TryParse(getIdMiembro(), out int id);

                if (passwordActual != null || passwordNueva != null)
                {

                    Miembro miembro = await Util.Util._APIService.GetMiembroByID(id);

                    if (miembro.passwordMiembro.ToString() == passwordActual)
                    {

                        miembro.passwordMiembro = passwordNueva;
                        Miembro miembroActualizado = await Util.Util._APIService.UpdateMiembro(miembro, id);

                        if (miembroActualizado != null)
                        {
                            
                            var toast = Toast.Make("Cambio exitoso", ToastDuration.Short, 14);
                            await toast.Show();
                            await App.Current.MainPage.Navigation.PopAsync();

                        }

                    }
                    else
                    {
                        var toast = Toast.Make("Contraseña incorrecta", ToastDuration.Short, 14);
                        await toast.Show();
                    }

                }
                else
                {

                    var toast = Toast.Make("No olvides completar todos los campos!", ToastDuration.Short, 14);
                    await toast.Show();

                }

            });

    }
}
