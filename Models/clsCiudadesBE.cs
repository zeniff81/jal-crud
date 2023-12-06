using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace jal_crud.Models
{
    public class clsCiudadesBE
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CiudadId { get; set; }
        
        [MaxLength(50)]
        public string Ciudad { get; set; }

        // relaciones 
        public virtual ICollection<clsContactosBE> Contactos { get; set; }
    }
}
