using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace jal_crud.Models
{
    [Table("TipoFacturas")]
    public class clsTipoFacturasBE
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int TipoFacturaId { get; set; }
        public string TipoFactura { get; set; }

        public virtual ICollection<clsFacturasBE> Facturas { get; set; }
    }
}
