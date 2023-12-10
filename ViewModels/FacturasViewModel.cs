using jal_crud.Models;
using jal_crud.Services;
using System.ComponentModel;
using System.Windows.Input;

namespace jal_crud.ViewModels
{
    class FacturasViewModel : BaseViewModel
    {
        #region Variables locales
        private int _facturaId;
        private DateTime _fecha;
        private decimal _subtotal;
        private decimal _descuento;
        private decimal _monto;
        private int _clienteId;
        private int _tipoFacturaId;
        List<clsFacturasBE> _facturas;


        private clsFacturasBE _factura;        
        
        public clsFacturasBE Factura {
            get { return _factura; }
            set
            {
                if(_factura != value)
                {
                    _factura = value;
                    OnPropertyChanged(nameof(Factura));
                }
            }
        }


        public int FacturaId
        {
            get { return _facturaId; }
            set
            {
                if (_facturaId != value)
                {
                    _facturaId = value;
                    OnPropertyChanged(nameof(FacturaId));
                }
            }
        }

        public List<clsFacturasBE> Facturas
        {
            get { return _facturas; }
            set
            {
                if (_facturas != value)
                {
                    _facturas = value;
                    OnPropertyChanged(nameof(Facturas));
                }
            }
        }

        public DateTime Fecha
        {
            get { return _fecha; }
            set
            {
                if (_fecha != value)
                {
                    _fecha = value;
                    OnPropertyChanged(nameof(Fecha));
                }
            }
        }

        public decimal Subtotal
        {
            get { return _subtotal; }
            set
            {
                if (_subtotal != value)
                {
                    _subtotal = value;
                    OnPropertyChanged(nameof(Subtotal));
                }
            }
        }

        public decimal Descuento
        {
            get { return _descuento; }
            set
            {
                if (_descuento != value)
                {
                    _descuento = value;
                    OnPropertyChanged(nameof(Descuento));
                }
            }
        }

        public decimal Monto
        {
            get { return _monto; }
            set
            {
                if (_monto != value)
                {
                    _monto = value;
                    OnPropertyChanged(nameof(Monto));
                }
            }
        }

        public int ClienteId
        {
            get { return _clienteId; }
            set
            {
                if (_clienteId != value)
                {
                    _clienteId = value;
                    OnPropertyChanged(nameof(ClienteId));
                }
            }
        }

        public int TipoFacturaId
        {
            get { return _tipoFacturaId; }
            set
            {
                if (_tipoFacturaId != value)
                {
                    _tipoFacturaId = value;
                    OnPropertyChanged(nameof(TipoFacturaId));
                }
            }
        }
        #endregion

        #region Command
        private ICommand _saveCommand;
        private ICommand _borrarCommand;
        private ICommand _getFacturaCommand;

        
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
        public ICommand getFacturaCommand
        {
            get
            {
                return _getFacturaCommand ??
                    (_getFacturaCommand = new Command((obj) =>
                    {
                        int Id = int.Parse((string)obj);
                        getFactura(Id);
                    }));
            }
        }



        private void Save()
        {
            try
            {
                // Validate properties
                if (Fecha == DateTime.MinValue)
                {
                    App.Current.MainPage.DisplayAlert("Aviso", "Fecha no puede estar vacía", "Aceptar");
                    return;
                }

                if (Subtotal <= 0)
                {
                    App.Current.MainPage.DisplayAlert("Aviso", "El Subtotal debe ser mayor que cero", "Aceptar");
                    return;
                }

                if (Descuento < 0 || Descuento > 100)
                {
                    App.Current.MainPage.DisplayAlert("Aviso", "El Descuento debe estar entre 0 y 100", "Aceptar");
                    return;
                }

                if (Monto <= 0)
                {
                    App.Current.MainPage.DisplayAlert("Aviso", "El Monto debe ser mayor que cero", "Aceptar");
                    return;
                }

                if (ClienteId <= 0)
                {
                    App.Current.MainPage.DisplayAlert("Aviso", "ClienteId debe ser mayor que cero", "Aceptar");
                    return;
                }

                if (TipoFacturaId <= 0)
                {
                    App.Current.MainPage.DisplayAlert("Aviso", "TipoFacturaId debe ser mayor que cero", "Aceptar");
                    return;
                }

                
                DataService data = new DataService();
                data.FacturasSave(Fecha, Subtotal, Descuento, Monto, ClienteId, TipoFacturaId);
                App.Current.MainPage.DisplayAlert("Aviso", "Guardado correctamente.", "Aceptar");
            }
            catch (Exception ex)
            {
                var x = ex;
                // Handle exceptions if needed
            }
        }

        private void Borrar(int FacturaId)
        {
            DataService data = new DataService();
            string resultado = data.FacturasDeleteGetById(FacturaId);
            App.Current.MainPage.DisplayAlert("Aviso", resultado, "Aceptar");
        }
        #endregion

        public FacturasViewModel()
        {
            getDatos();
        }

        private void getDatos()
        {
            DataService data = new DataService();
            Facturas = data.FacturasGet();
        }

        private void getFactura(int FacturaId)
        {
            DataService data = new DataService();
            var result = data.FacturasGetById(FacturaId);

            if (result != null)
            {
                Facturas.Clear();
                Facturas.Add(new clsFacturasBE
                {
                    Fecha = DateTime.Now,
                    Subtotal = result.Subtotal,
                    Descuento = result.Descuento,
                    Monto = result.Monto,
                    ClienteId = result.ClienteId,
                    TipoFacturaId = result.TipoFacturaId
                });
          }
        }
    }
}
