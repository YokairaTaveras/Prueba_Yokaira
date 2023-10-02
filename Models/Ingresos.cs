using System.ComponentModel.DataAnnotations;

namespace Prueba_Yokaira.Models
{
    public class Ingresos
    {
        [Key]
        public int IngresoId { get; set; }

        [Required(ErrorMessage = "Este campo es necesario")]
        public DateTime Fecha { get; set; }

        [Required(ErrorMessage = "Este campo es necesario")]
        public string Concepto { get; set; } = string.Empty;

        [Required(ErrorMessage = "Este campo es necesario")]
        [Range(1, 5000)]
        public int Monto { get; set; }
    }
}
