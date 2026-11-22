using System.ComponentModel.DataAnnotations;

namespace FridgeTrack.Models
{
    public class Alimento
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "El nombre es obligatorio")]
        public string Nombre { get; set; } = "";

        [Required(ErrorMessage = "La categoria es obligatoria")]
        public string Categoria { get; set; } = "";

        [Range(1, 1000, ErrorMessage = "La cantidad tiene que ser entre 1 y 1000")]
        public int Cantidad { get; set; }

        [DataType(DataType.Date)]
        public DateTime FechaVencimiento { get; set; }
    }
}
