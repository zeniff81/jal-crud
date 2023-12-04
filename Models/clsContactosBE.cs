using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace jal_crud.Models
{
    [Table("Contactos")]
    public class clsContactosBE
    {
        public int ContactosId { get; set; }
        public DateTime Fecha { get; set; }
        public String Nombres { get; set; }
        public String Apellidos { get; set; }
        public String Direccion { get; set; }
        public String Telefono { get; set; }

        public clsContactosBE()
        {
            
        }
    }    
}
