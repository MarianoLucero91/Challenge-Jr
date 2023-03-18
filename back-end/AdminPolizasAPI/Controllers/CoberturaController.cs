using AdminPolizasAPI.Dtos;
using AdminPolizasAPI.Entidades;
using AdminPolizasAPI.Repositories.IRepositories;
using Microsoft.AspNetCore.Mvc;

namespace AdminPolizasAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CoberturasController : ControllerBase
    {
        private readonly ICoberturaRepository _repository;

        public CoberturasController(ICoberturaRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Cobertura>> GetCoberturas()
        {
            var coberturas =  _repository.GetAll();
            return Ok(coberturas);
        }

        [HttpGet("{id}")]
        public ActionResult<Cobertura> GetCobertura([FromRoute] int id)
        {
            var cobertura =  _repository.GetCoberturaById(id);
            if (cobertura == null)
            {
                return NotFound();
            }
            return Ok(cobertura);
        }

        [HttpPost]
        public ActionResult<Cobertura> AddCobertura(CoberturaDto cobertura)
        {            
            var model = _repository.AddCobertura(new Cobertura { Nombre = cobertura.Nombre });
            return Ok(model);
        }

        [HttpPut("{id}")]
        public ActionResult<Cobertura> UpdateCobertura([FromRoute] int id, [FromBody] CoberturaDto request)
        {
            var cobertura = _repository.GetCoberturaById(id);

            if (cobertura == null)
            {
                return NotFound();
            }

            _repository.UpdateCobertura(new Cobertura { Nombre = request.Nombre, Id = id });

            return Ok(cobertura);
        }

        [HttpDelete("{id}")]
        public ActionResult<Cobertura> DeleteCobertura(int id)
        {
            var cobertura =  _repository.GetCoberturaById(id);
            if (cobertura == null)
            {
                return NotFound();
            }

            _repository.DeleteCobertura(cobertura);

            return NoContent();
        }
    }
}

