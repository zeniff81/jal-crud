using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
    }

}
