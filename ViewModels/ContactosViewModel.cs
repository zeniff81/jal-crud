using jal_crud.Models;
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
        #region Variables locales
        string _nombres;
        string _apellidos;
        string _direccion;
        string _telefono;
        int _ciudadId;
        List<clsContactosBE> _contactos;
        #endregion


        #region Propiedades
        public List<clsContactosBE> Contactos
        {
            get
            {
                return _contactos;
            }
            set
            {
                if (_contactos != value)
                {
                    _contactos = value;
                    this.OnPropertyChange(nameof(Contactos));
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
        public int CiudadId
        {
            get
            {
                return _ciudadId;
            }
            set
            {
                if (_ciudadId != value)
                {
                    _ciudadId = value;
                    this.OnPropertyChange(nameof(CiudadId));
                }
            }
        }
        #endregion

        #region Commands
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
                if (string.IsNullOrEmpty(CiudadId.ToString()))
                {
                    App.Current.MainPage.DisplayAlert("Aviso", "Es necesario la ciudad del contacto", "Aceptar");
                    return;
                }
                DataService data = new DataService();
                data.ContactosSave(Nombres, Apellidos, Direccion, Telefono, CiudadId);
                App.Current.MainPage.DisplayAlert("Aviso", "Guardado correctamente.", "Aceptar");
            }
            catch (Exception ex)
            {
                var x = ex;
            }
        }
        #endregion

        public ContactosViewModel()
        {
            getDatos();
        }

        private void getDatos()
        {
            DataService data = new DataService();
            Contactos = data.ContactosGet();
        }
    }

}
