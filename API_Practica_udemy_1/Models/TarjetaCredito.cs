using System.ComponentModel.DataAnnotations;

namespace API_Practica_udemy_1.Models
{
    public class TarjetaCredito
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public string Nombre { get; set; }
        [Required]
        public string Numero { get; set; }
        [Required]
        public DateTime FechaExpiracion { get; set;}
        [Required]
        public string CVV { get; set; }
    }
}
