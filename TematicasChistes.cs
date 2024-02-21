using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Prueba
{
    [Table("tematicaschistes")]
    public class TematicasChistes
    {
        [Key]
        public int IDTematica { get; set; }
        [Key]
        public int IDChiste { get; set; }
    }
}
