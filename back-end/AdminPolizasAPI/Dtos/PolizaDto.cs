using AdminPolizasAPI.Entidades;
using System.ComponentModel.DataAnnotations;

namespace AdminPolizasAPI.Dtos
{
    public class PolizasCoberturasDto
    {
        [Required]
        public int CoberturaId { get; set; }
        
        public decimal MontoAsegurado { get; set; }
    }

    public class PolizaRequestDto
    {
        [Required]
        [MaxLength(256)]
        public string Nombre { get; set; }

        public List<PolizasCoberturasDto> PolizasCoberturas { get; set; }
    }

    public class PolizaResponseDto
    {
        public int Id { get; set; }

        public string Nombre { get; set; }

        public List<PolizasCoberturasDto> PolizasCoberturas { get; set; }
    }


    
}
