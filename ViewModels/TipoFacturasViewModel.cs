using jal_crud.Models;
using jal_crud.Services;
using System.ComponentModel;
using System.Windows.Input;

namespace jal_crud.ViewModels
{
    class TipoFacturasViewModel : BaseViewModel
    {
        #region Variables locales
        int _tipoFacturaId;
        string _tipoFactura;
        List<clsTipoFacturasBE> _tipoFacturas;
        #endregion

        #region Propiedades
        public List<clsTipoFacturasBE> TipoFacturas
        {
            get
            {
                return _tipoFacturas;
            }
            set
            {
                if (_tipoFacturas != value)
                {
                    _tipoFacturas = value;
                    this.OnPropertyChanged(nameof(TipoFacturas));
                }
            }
        }
        public string TipoFactura
        {
            get
            {
                return _tipoFactura;
            }
            set
            {
                if (_tipoFactura != value)
                {
                    _tipoFactura = value;
                    this.OnPropertyChanged(nameof(TipoFactura));
                }
            }
        }
        public int TipoFacturaId
        {
            get
            {
                return _tipoFacturaId;
            }
            set
            {
                if (_tipoFacturaId != value)
                {
                    _tipoFacturaId = value;
                    this.OnPropertyChanged(nameof(TipoFacturaId));
                }
            }
        }
        #endregion

        #region Command
        private ICommand _saveCommand;
        private ICommand _borrarCommand;
        private ICommand _getTipoFacturaCommand;

        

        public ICommand SaveCommand
        {
            get
            {
                return _saveCommand ??
                    (_saveCommand = new Command((obj) =>
                    {
                        Save();
                    }));
            }
        }        
        public ICommand BorrarCommand
        {
            get
            {
                return _borrarCommand ??
                    (_borrarCommand = new Command((obj) =>
                    {
                        int Id = int.Parse((string)obj);
                        Borrar(Id);
                    }));
            }
        }
        public ICommand getTipoFacturaCommand
        {
            get
            {
                return _getTipoFacturaCommand ??
                    (_getTipoFacturaCommand = new Command((obj) =>
                    {
                        int Id = int.Parse((string)obj);
                        getTipoFactura(Id);
                    }));
            }
        }



        private void Save()
        {
            try
            {
                if (string.IsNullOrEmpty(TipoFactura))
                {
                    App.Current.MainPage.DisplayAlert("Aviso", "Faltan datos", "Aceptar");
                    return;
                }

                DataService data = new DataService();
                data.TipoFacturasSave(TipoFactura);
                App.Current.MainPage.DisplayAlert("Aviso", "Guardado correctamente.", "Aceptar");
            }
            catch (Exception ex)
            {
                var x = ex;
            }
        }
        private void Borrar(int TipoFacturaId)
        {
            DataService data = new DataService();
            string resultado = data.TipoFacturasDeleteGetById(TipoFacturaId);
            App.Current.MainPage.DisplayAlert("Aviso", resultado, "Aceptar");
        }
        #endregion

        public TipoFacturasViewModel()
        {
            getDatos();
        }

        private void getDatos()
        {
            DataService data = new DataService();
            TipoFacturas = data.TipoFacturasGet();
        }

        private void getTipoFactura(int TipoFacturaId)
        {
            DataService data = new DataService();
            var result = data.TipoFacturasGetById(TipoFacturaId);

            if (result != null)
            {
                TipoFacturas.Clear();
                TipoFacturas.Add(new clsTipoFacturasBE
                {
                    TipoFactura = result.TipoFactura,
                });
          }
        }
    }
}
