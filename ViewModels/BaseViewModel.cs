using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace jal_crud.ViewModels
{
    class BaseViewModel
    {
        public event PropertyChangingEventHandler PropertyChange;
        protected virtual void OnPropertyChange([CallerMemberName] string propertyName =  null )
        {
            PropertyChange?.Invoke(this, new PropertyChangingEventArgs(propertyName));
        }
    }
}
