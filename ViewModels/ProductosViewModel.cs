using jal_crud.Models;
using jal_crud.Services;
using System.ComponentModel;
using System.Windows.Input;

namespace jal_crud.ViewModels
{
    class ProductosViewModel : BaseViewModel
    {
        #region Variables locales
        int _productoId;
        string _producto;
        decimal _precio;
        decimal _costo;
        int _cantidad;
        int _categoriaId;        
        List<clsProductosBE> _Productos;
        List<clsCategoriasBE> _Categorias;
        #endregion

        #region Propiedades
        public List<clsProductosBE> Productos
        {
            get
            {
                return _Productos;
            }
            set
            {
                if (_Productos != value)
                {
                    _Productos = value;
                    this.OnPropertyChanged(nameof(Productos));
                }
            }
        }
        public string Producto
        {
            get
            {
                return _producto;
            }
            set
            {
                if (_producto != value)
                {
                    _producto = value;
                    this.OnPropertyChanged(nameof(Producto));
                }
            }
        }
        public decimal Precio
        {
            get
            {
                return _precio;
            }
            set
            {
                if (_precio != value)
                {
                    _precio = value;
                    this.OnPropertyChanged(nameof(Precio));
                }
            }
        }
        public decimal Costo
        {
            get
            {
                return _costo;
            }
            set
            {
                if (_costo != value)
                {
                    _costo = value;
                    this.OnPropertyChanged(nameof(Costo));
                }
            }
        }
        public int Cantidad
        {
            get
            {
                return _cantidad;
            }
            set
            {
                if (_cantidad != value)
                {
                    _cantidad = value;
                    this.OnPropertyChanged(nameof(Cantidad));
                }
            }
        }
        public int CategoriaId
        {
            get
            {
                return _categoriaId;
            }
            set
            {
                if (_categoriaId != value)
                {
                    _categoriaId = value;
                    this.OnPropertyChanged(nameof(CategoriaId));
                }
            }
        }
        public int ProductoId
        {
            get
            {
                return _productoId;
            }
            set
            {
                if (_productoId != value)
                {
                    _productoId = value;
                    this.OnPropertyChanged(nameof(ProductoId));
                }
            }
        }
        #endregion

        #region Command
        private ICommand _saveCommand;
        private ICommand _borrarCommand;
        private ICommand _getProductoCommand;

        

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
        public ICommand getProductoCommand
        {
            get
            {
                return _getProductoCommand ??
                    (_getProductoCommand = new Command((obj) =>
                    {
                        int Id = int.Parse((string)obj);
                        getProducto(Id);
                    }));
            }
        }



        private void Save()
        {
            try
            {
                if (string.IsNullOrEmpty(Producto))
                {
                    App.Current.MainPage.DisplayAlert("Aviso", "Faltan datos", "Aceptar");
                    return;
                }

                DataService data = new DataService();
                string ProductosSave_resultado = data.ProductosSave(Producto, Precio, Costo, Cantidad, CategoriaId);
                App.Current.MainPage.DisplayAlert("Aviso", ProductosSave_resultado, "Aceptar");
            }
            catch (Exception ex)
            {
                var x = ex;
            }
        }
        private void Borrar(int ProductoId)
        {
            DataService data = new DataService();
            string resultado = data.ProductosDeleteGetById(ProductoId);
            App.Current.MainPage.DisplayAlert("Aviso", resultado, "Aceptar");
        }
        #endregion

        public ProductosViewModel()
        {
            getDatos();
        }

        private void getDatos()
        {
            DataService data = new DataService();
            Productos = data.ProductosGet();
        }

        private void getProducto(int ProductoId)
        {
            DataService data = new DataService();
            var result = data.ProductosGetById(ProductoId);

            if (result != null)
            {
                Productos.Clear();
                Productos.Add(new clsProductosBE
                {
                    Producto = result.Producto,
                });
          }
        }
    }
}
