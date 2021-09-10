using Microsoft.AspNetCore.Mvc;
using WebApp.Entidades;
using WebApp.Services;
using System.Collections.Generic;
using System.Linq;
using WebApp.Context;

namespace WebApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PessoasController : ControllerBase
    {
        private readonly IPessoaService _service;
        private AppDbContext _contexto;

        public PessoasController(IPessoaService service)
        {
            _service = service;
        }

        [HttpGet]
        public IActionResult Get()
        {
            List<Pessoa> model = _service.GetPessoas();
            List<PessoaModel> outputModel = ToOutputModel(model);

            return Ok(outputModel);
        }

        [HttpGet("{id}", Name = "GetPessoa")]
        public IActionResult GetById(int id)
        {
            Pessoa model = _service.GetPessoa(id);
            if (model == null)
            {
                return NotFound();
            }

            var outputModel = ToOutputModel(model);
            return Ok(outputModel);
        }

        [HttpPost]
        public IActionResult Create([FromBody] PessoaModel inputModel)
        {
            if (inputModel == null)
            {
                return BadRequest();
            }

            Pessoa model = ToDomainModel(inputModel);
            _service.AddPessoa(model);

            var outputModel = ToOutputModel(model);
            return CreatedAtRoute("GetPessoa", new { Id = outputModel.Id }, outputModel);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] PessoaModel inputModel)
        {
            if (inputModel == null || id != inputModel.Id)
            {
                return BadRequest();
            }

            if (!_service.PessoaExists(id))
            {
                return NotFound();
            }

            Pessoa model = ToDomainModel(inputModel);
            _service.UpdatePessoa(model);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            if (!_service.PessoaExists(id))
            {
                return NotFound();
            }

            _service.DeletePessoa(id);

            return NoContent();
        }

        // Mapeamento para a API

        private PessoaModel ToOutputModel(Pessoa pessoa)
        {
            return new PessoaModel
            {
                Id = pessoa.Id,
                Nome = pessoa.Nome,
                Sobrenome = pessoa.Sobrenome,
                Email = pessoa.Email
            };
        }

        private List<PessoaModel> ToOutputModel(List<Pessoa> pessoas)
        {
            return pessoas.Select(p => ToOutputModel(p)).ToList();
        }

        private Pessoa ToDomainModel(PessoaModel model)
        {
            return new Pessoa
            {
                Id = model.Id,
                Nome = model.Nome,
                Sobrenome = model.Sobrenome,
                Email = model.Email
            };
        }

        private PessoaModel ToInputModel(Pessoa model)
        {
            return new PessoaModel
            {
                Id = model.Id,
                Nome = model.Nome,
                Sobrenome = model.Sobrenome,
                Email = model.Email
            };
        }
    }
}
