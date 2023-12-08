using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace jal_crud.Models
{
    [Table("TipoFacturas")]
    public class clsTipoFacturasBE
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int FacturaId { get; set; }
        public string TipoFactura { get; set; }

        public virtual ICollection<clsFacturasBE> Facturas { get; set; }
    }
}
