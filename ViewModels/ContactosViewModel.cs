using jal_crud.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace jal_crud.ViewModels
{
    class ContactosViewModel : BaseViewModel
    {
        string _nombres;
        string _apellidos;
        string _direccion;
        string _telefono;


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
                    this.OnPropertyChange(nameof(Nombres));
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
                    this.OnPropertyChange(nameof(Apellidos));
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
                    this.OnPropertyChange(nameof(Telefono));
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
                    this.OnPropertyChange(nameof(Direccion));
                }
            }
        }

        private ICommand _saveCommand;
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

        private void Save()
        {
            try
            {
                if (string.IsNullOrEmpty(Nombres))
                {
                    App.Current.MainPage.DisplayAlert("Aviso", "Es necesario el nombre del contacto", "Aceptar");
                    return;
                }
                if (string.IsNullOrEmpty(Apellidos))
                {
                    App.Current.MainPage.DisplayAlert("Aviso", "Es necesario el apellidos del contacto", "Aceptar");
                    return;
                }
                if (string.IsNullOrEmpty(Direccion))
                {
                    App.Current.MainPage.DisplayAlert("Aviso", "Es necesario la dirección del contacto", "Aceptar");
                    return;
                }
                if (string.IsNullOrEmpty(Telefono))
                {
                    App.Current.MainPage.DisplayAlert("Aviso", "Es necesario el teléfono del contacto", "Aceptar");
                    return;
                }
                DataService data = new DataService();
                data.ContactosSave(Nombres, Apellidos, Direccion, Telefono);
            }catch (Exception ex)
            {
                var x = ex;
            }
        }
    }

}
