using jal_crud.Models;
using jal_crud.Services;
using System.ComponentModel;
using System.Windows.Input;

namespace jal_crud.ViewModels
{
    class ClientesViewModel : BaseViewModel
    {
        #region Variables locales
        int _ClienteId;
        string _Cliente;
        string _nombres;
        string _apellidos;
        string _direccion;
        string _telefono;
        List<clsClientesBE> _Clientes;
        #endregion

        #region Propiedades
        public List<clsClientesBE> Clientes
        {
            get
            {
                return _Clientes;
            }
            set
            {
                if (_Clientes != value)
                {
                    _Clientes = value;
                    this.OnPropertyChanged(nameof(Clientes));
                }
            }
        }
        public string Nombres
        {
            get
            {
                return _nombres;
            }
            set
            {
                if (_nombres != value)
                {
                    _nombres = value;
                    this.OnPropertyChanged(nameof(Nombres));
                }
            }
        }
        public string Apellidos
        {
            get
            {
                return _apellidos;
            }
            set
            {
                if (_apellidos != value)
                {
                    _apellidos = value;
                    this.OnPropertyChanged(nameof(Apellidos));
                }
            }
        }
        public string Direccion
        {
            get
            {
                return _direccion;
            }
            set
            {
                if (_direccion != value)
                {
                    _direccion = value;
                    this.OnPropertyChanged(nameof(Direccion));
                }
            }
        }
        public string Telefono
        {
            get
            {
                return _telefono;
            }
            set
            {
                if (_telefono != value)
                {
                    _telefono = value;
                    this.OnPropertyChanged(nameof(Telefono));
                }
            }
        }
        public int ClienteId
        {
            get
            {
                return _ClienteId;
            }
            set
            {
                if (_ClienteId != value)
                {
                    _ClienteId = value;
                    this.OnPropertyChanged(nameof(ClienteId));
                }
            }
        }
        #endregion

        #region Command
        private ICommand _saveCommand;
        private ICommand _borrarCommand;
        private ICommand _getClienteCommand;

        public event PropertyChangedEventHandler PropertyChanged;

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
        public ICommand getClienteCommand
        {
            get
            {
                return _getClienteCommand ??
                    (_getClienteCommand = new Command((obj) =>
                    {
                        int Id = int.Parse((string)obj);
                        getCliente(Id);
                    }));
            }
        }



        private void Save()
        {
            try
            {
                if (
                    string.IsNullOrEmpty(Nombres) &&
                    string.IsNullOrEmpty(Apellidos) &&
                    string.IsNullOrEmpty(Direccion) &&
                    string.IsNullOrEmpty(Telefono)
                    )
                {
                    App.Current.MainPage.DisplayAlert("Aviso", "Faltan datos", "Aceptar");
                    return;
                }

                DataService data = new DataService();
                data.ClientesSave(Nombres, Apellidos, Direccion, Telefono);
                App.Current.MainPage.DisplayAlert("Aviso", "Guardado correctamente.", "Aceptar");
            }
            catch (Exception ex)
            {
                var x = ex;
            }
        }
        private void Borrar(int ClienteId)
        {
            DataService data = new DataService();
            string resultado = data.ClientesDeleteGetById(ClienteId);
            App.Current.MainPage.DisplayAlert("Aviso", resultado, "Aceptar");
        }
        #endregion

        public ClientesViewModel()
        {
            getDatos();
        }

        private void getDatos()
        {
            DataService data = new DataService();
            Clientes = data.ClientesGet();
        }

        private void getCliente(int ClienteId)
        {
            DataService data = new DataService();
            var result = data.ClientesGetById(ClienteId);

            if (result != null)
            {
                Clientes.Clear();
                Clientes.Add(new clsClientesBE
                {
                    ClienteId = result.ClienteId,
                    Nombres = result.Nombres,
                    Apellidos = result.Apellidos,
                    Direccion = result.Direccion,
                    Telefono = result.Telefono,
                });
          }
        }
    }
}
