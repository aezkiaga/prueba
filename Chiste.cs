using System.ComponentModel.DataAnnotations.Schema;

namespace Prueba
{
    public class Chiste
    {

        public int Id { get; set; }
        public string Titulo { get; set; }
        public string Autor { get; set; }

        public string Cuerpo { get; set; }
        [NotMapped]
        public int TematicaId { get; set; }
    }
}