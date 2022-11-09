using DAL;
using Entidades;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MandalorianoMaui.ViewModels
{
    public class MandalorianoVM
    {
        public ObservableCollection<clsMision> ListaMisiones { get;}

        public MandalorianoVM(ObservableCollection<clsMision> ListaMisiones)
        {
            this.ListaMisiones = ListaMisiones; 
        }

        public MandalorianoVM()
        {
            ListaMisiones = clsListaMisionesBL.obtenerListaMisiones();
        }

    }
}
