using System.ComponentModel.DataAnnotations;

namespace Ramon_Gonzalez_AP1_P2.Models
{
    public class Producto
    {
        [Key]
        public int ProductoId { get; set; }

        [Required(ErrorMessage = "La descripción del producto es obligatoria.")]
        [StringLength(100, ErrorMessage = "La descripción no puede exceder los 100 caracteres.")]
        public string Descripcion { get; set; } = string.Empty;

        [Required(ErrorMessage = "El Peso es obligatorio.")]
        [Range(0.0, double.MaxValue, ErrorMessage = "El Peso no puede ser negativo.")]
        public double Peso { get; set; }

        [Required(ErrorMessage = "La Existencia es obligatoria.")]
        [Range(0, int.MaxValue, ErrorMessage = "La Existencia no puede ser negativa.")]
        public int Existencia { get; set; }

        public bool EsCompuesto { get; set; }
    }
}