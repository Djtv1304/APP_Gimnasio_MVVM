using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APP_Gimnasio.ViewModels
{
    public class DetallesMembresiaPageViewModel
    { 
    
        public string getMembresia()
        {

            return Preferences.Get("nombreMembresia", "0");

        }

        public string getDuracionMembresia()
        {

            return Preferences.Get("duracionMembresia", "0");

        }

        public string getPrecioMembresia()
        {

            return Preferences.Get("precioMembresia", "0");

        }
    
    }
}
