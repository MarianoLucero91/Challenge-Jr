using System.ComponentModel.DataAnnotations;

namespace AdminPolizasAPI.Dtos
{
    public class CoberturaDto
    {
        [Required]
        [MaxLength(256)]
        public string Nombre { get; set; }
    }
}
