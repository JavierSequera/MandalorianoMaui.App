using DAL;
using Entidades;
using MandalorianoMaui.ViewModels.Utilidades;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MandalorianoMaui.ViewModels
{
    public class MandalorianoVM:clsVMBase
    {
        #region Atributos
        private ObservableCollection<clsMision> listaMisiones; 

        private clsMision misionSeleccionada;

        private DelegateCommand mostrarDetallesCommand;

        private Boolean datosMisionEsVisible;
        #endregion

        #region propiedades

        public ObservableCollection<clsMision> ListaMisiones { 

            get { return listaMisiones; } 
            set { listaMisiones = value; }}

        public clsMision MisionSeleccionada { 

            get { return misionSeleccionada; } 
            set {
                if (misionSeleccionada != value)
                {
                    misionSeleccionada = value;
                    mostrarDetallesCommand.RaiseCanExecuteChanged();
                    DatosMisionEsVisible = false;
                    NotifyPropertyChanged(nameof(datosMisionEsVisible));
                }
            }     
        }

        //fdf

        public DelegateCommand MostrarDetallesCommand {

            get {
                mostrarDetallesCommand = new DelegateCommand(mostrarContenidoMision_execute, mostrarContenidoMision_canExecute);
                return mostrarDetallesCommand;
            } }

        public Boolean DatosMisionEsVisible { 

            get { return datosMisionEsVisible; } 
            set { datosMisionEsVisible = value; NotifyPropertyChanged(); } }

       


        #endregion

        #region Constructores

        public MandalorianoVM()
        {
            ListaMisiones = clsListaMisionesBL.obtenerListaMisiones();
        }

        #endregion

        #region Comandos
        /// <summary>
        /// Método que muestra la información de una misión seleccionada haciendo visible el texto mediante booleano.
        /// </summary>
        /// <exception cref="NotImplementedException"></exception>
        private void mostrarContenidoMision_execute()
        {
            DatosMisionEsVisible = true;
            NotifyPropertyChanged("datosMisionEsVisible");
            NotifyPropertyChanged("misionSeleccionada");

        }
        /// <summary>
        /// Método que cambia el estado del botón.
        /// </summary>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        private bool mostrarContenidoMision_canExecute()
        {
            bool mostrar = false;
            if (MisionSeleccionada != null)
            {
                mostrar = true;
            }
            return mostrar;
        }
        #endregion
    }

}

