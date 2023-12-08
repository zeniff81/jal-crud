using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace jal_crud.Models
{
    [Table("Categorias")]
    public class clsCategoriasBE
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)] 
        public int CategoriaId { get; set; }
        public string Categoria { get; set;}

        public virtual ICollection<clsProductosBE> Productos { get; set; }
    }
}
