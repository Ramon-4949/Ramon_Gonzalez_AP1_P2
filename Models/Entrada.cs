using Ramon_Gonzalez_AP1_P2.Models;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Ramon_Gonzalez_AP1_P2.Models
{
    public class Entrada
    {
        [Key]
        public int EntradaId { get; set; }

        [Required(ErrorMessage = "La Fecha es obligatoria.")]
        public DateTime Fecha { get; set; }

        [Required(ErrorMessage = "El Concepto es obligatorio.")]
        [StringLength(200, ErrorMessage = "El Concepto no puede exceder los 200 caracteres.")]
        public string Concepto { get; set; } = string.Empty;

        [Required(ErrorMessage = "El Peso Total es obligatorio.")]
        [Range(0.0, double.MaxValue, ErrorMessage = "El Peso Total no puede ser negativo.")]
        public double PesoTotal { get; set; }

        public ICollection<EntradaDetalle> Detalle { get; set; } = new List<EntradaDetalle>();
    }
}