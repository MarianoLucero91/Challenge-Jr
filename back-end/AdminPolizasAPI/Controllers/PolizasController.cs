using AdminPolizasAPI.Dtos;
using AdminPolizasAPI.Entidades;
using AdminPolizasAPI.Repositories.IRepositories;
using Microsoft.AspNetCore.Mvc;

namespace AdminPolizasAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PolizasController : ControllerBase
    {
        private readonly IPolizaRepository _repository;

        public PolizasController(IPolizaRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Poliza>> GetPolizas()
        {
            var polizas = _repository.GetAll();
            return Ok(polizas.Select(p => new PolizaResponseDto
            {
                Id = p.Id,
                Nombre = p.Nombre,
                PolizasCoberturas = p.PolizasCoberturas.Select(pc => new PolizasCoberturasDto
                {
                    CoberturaId = pc.CoberturaId,
                    MontoAsegurado = pc.MontoAsegurado
                }).ToList()
            }));
        }

        [HttpGet("{id}")]
        public ActionResult<Poliza> GetPoliza([FromRoute] int id)
        {
            var poliza = _repository.GetPolizaById(id);
            if (poliza == null)
            {
                return NotFound();
            }
            return Ok(poliza);
        }

        [HttpPost]
        public ActionResult<Poliza> AddPoliza(PolizaRequestDto poliza)
        {
            var model = _repository.AddPoliza(new Poliza
            {
                Nombre = poliza.Nombre,
                PolizasCoberturas = poliza.PolizasCoberturas.Select(s => new PolizasCoberturas
                {
                    CoberturaId = s.CoberturaId,
                    MontoAsegurado = s.MontoAsegurado

                }).ToList()
            });
            return Ok(new PolizaResponseDto
            {
                Id = model.Id,
                Nombre = model.Nombre,
                PolizasCoberturas = model.PolizasCoberturas.Select(p => new PolizasCoberturasDto
                {
                    CoberturaId = p.CoberturaId,
                    MontoAsegurado = p.MontoAsegurado
                }).ToList()
            });
        }

        [HttpPut("{id}")]
        public ActionResult<Poliza> UpdatePoliza([FromRoute] int id, [FromBody] PolizaRequestDto request)
        {
            var poliza = _repository.GetPolizaById(id);

            if (poliza == null)
            {
                return NotFound();
            }

            var model = _repository.UpdatePoliza(new Poliza
            {
                Id = id,
                Nombre = request.Nombre,
                PolizasCoberturas = request.PolizasCoberturas.Select(s => new PolizasCoberturas
                {
                    CoberturaId = s.CoberturaId,
                    MontoAsegurado = s.MontoAsegurado

                }).ToList()
            });

            return Ok(new PolizaResponseDto
            {
                Id = model.Id,
                Nombre = model.Nombre,
                PolizasCoberturas = model.PolizasCoberturas.Select(p => new PolizasCoberturasDto
                {
                    CoberturaId = p.CoberturaId,
                    MontoAsegurado = p.MontoAsegurado
                }).ToList()
            });
        }

        [HttpDelete("{id}")]
        public ActionResult<Poliza> DeletePoliza(int id)
        {
            var poliza = _repository.GetPolizaById(id);
            if (poliza == null)
            {
                return NotFound();
            }

            _repository.DeletePoliza(poliza);

            return NoContent();
        }
    }
}
