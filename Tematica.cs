using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Prueba
{
    [Table("tematicas")]
    public class Tematica
    {
        [Key]
        public int Id { get; set; }
        public string Nombre { get; set; }
    }
}