using Microsoft.AspNetCore.Mvc;
using API.Services;
using API.Model;
using API.Data.VO;
using System.Collections.Generic;
using Microsoft.AspNetCore.Authorization;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PessoaController : ControllerBase
    {
        public PessoaService _pessoaService;

        public PessoaController(PessoaService pessoaService)
        {
            _pessoaService = pessoaService;
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(List<PessoaVO>))]
        public IActionResult Get()
        {
            return Ok(_pessoaService.FindAll());
        }

        [HttpGet]
        [Route("{id}")]
        [ProducesResponseType(200, Type = typeof(PessoaVO))]
        [ProducesResponseType(404)]
        //[Authorize("Bearer")]
        public IActionResult Get(string id)
        {
            var pessoa = _pessoaService.FindById(id);
            if (pessoa == null) return NotFound();
            return Ok(pessoa);
        }

        [HttpPost]
        [Route("new")]
        [ProducesResponseType(200, Type = typeof(PessoaVO))]
        [ProducesResponseType(400)]
        //[Authorize("Bearer")]
        public IActionResult Post([FromBody] PessoaVO pessoa)
        {
            if (pessoa == null) return BadRequest();
            return new ObjectResult(_pessoaService.Create(pessoa));
        }

        [HttpPost]
        [Route("ord/{pessoaId}/{ordemId}/{time}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        //[Authorize("Bearer")]
        public IActionResult Post(string pessoaId, string ordemId, int time)
        {
            if (pessoaId == null || ordemId == null) return BadRequest();
            _pessoaService.JoinOrdem(pessoaId, ordemId, time);
            return NoContent();
        }

        [HttpPut("{id}")]
        [ProducesResponseType(200, Type = typeof(PessoaVO))]
        [ProducesResponseType(400)]
        //[Authorize("Bearer")]
        public IActionResult Put([FromBody]PessoaVO pessoa)
        {
            if (pessoa == null) return BadRequest();
            return new ObjectResult(_pessoaService.Update(pessoa));
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(200)]
        //[Authorize("Bearer")]
        public IActionResult Delete(string id)
        {
            _pessoaService.Delete(id);
            return Ok();
        }
    }
}
