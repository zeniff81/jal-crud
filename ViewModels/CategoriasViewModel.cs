using jal_crud.Models;
using jal_crud.Services;
using System.ComponentModel;
using System.Windows.Input;

namespace jal_crud.ViewModels
{
    class CategoriasViewModel : BaseViewModel
    {
        #region Variables locales
        string _categoria;
        int _categoriaId;
        List<clsCategoriasBE> _categorias;
        #endregion

        #region Propiedades
        public List<clsCategoriasBE> Categorias
        {
            get
            {
                return _categorias;
            }
            set
            {
                if (_categorias != value)
                {
                    _categorias = value;
                    this.OnPropertyChanged(nameof(Categorias));
                }
            }
        }
        public string Categoria
        {
            get
            {
                return _categoria;
            }
            set
            {
                if (_categoria != value)
                {
                    _categoria = value;
                    this.OnPropertyChanged(nameof(Categoria));
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
        #endregion

        #region Command
        private ICommand _saveCommand;
        private ICommand _borrarCommand;
        private ICommand _getCategoriaCommand;

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
        public ICommand getCategoriaCommand
        {
            get
            {
                return _getCategoriaCommand ??
                    (_getCategoriaCommand = new Command((obj) =>
                    {
                        int Id = int.Parse((string)obj);
                        getCategoria(Id);
                    }));
            }
        }



        private void Save()
        {
            try
            {
                if (string.IsNullOrEmpty(Categoria))
                {
                    App.Current.MainPage.DisplayAlert("Aviso", "Es necesario la categoría", "Aceptar");
                    return;
                }

                DataService data = new DataService();
                data.CategoriasSave(Categoria);
                App.Current.MainPage.DisplayAlert("Aviso", "Guardado correctamente.", "Aceptar");
            }
            catch (Exception ex)
            {
                var x = ex;
            }
        }
        private void Borrar(int CategoriaId)
        {
            DataService data = new DataService();
            string resultado = data.CategoriasDeleteGetById(CategoriaId);
            App.Current.MainPage.DisplayAlert("Aviso", resultado, "Aceptar");
        }
        #endregion

        public CategoriasViewModel()
        {
            getDatos();
        }

        private void getDatos()
        {
            DataService data = new DataService();
            Categorias = data.CategoriasGet();
        }

        private void getCategoria(int CategoriaId)
        {
            DataService data = new DataService();
            var result = data.CategoriasGetById(CategoriaId);

            if (result != null)
            {
                Categorias.Clear();
                Categorias.Add(new clsCategoriasBE
                {
                    CategoriaId = result.CategoriaId,
                    Categoria = result.Categoria
                });
          }
        }
    }
}
