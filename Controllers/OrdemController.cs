using API.Data.VO;
using API.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrdemController : ControllerBase
    {
        private OrdemService _ordemService;

        public OrdemController(OrdemService ordemService)
        {
            _ordemService = ordemService;
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(List<OrdemVO>))]
        [Authorize("Bearer")]
        public IActionResult Get()
        {
            return Ok(_ordemService.FindAll());
        }

        [HttpGet("{id}")]
        [ProducesResponseType(200, Type = typeof(OrdemVO))]
        [ProducesResponseType(404)]
        [Authorize("Bearer")]
        public IActionResult Get(string id)
        {
            var result = _ordemService.FindById(id);

            if(result == null)
            {
                return NotFound();
            }

            return Ok(result);
        }

        [HttpPost]
        [Route("new")]
        [ProducesResponseType(200, Type = typeof(OrdemVO))]
        [ProducesResponseType(409)]
        [Authorize("Bearer")]
        public IActionResult Post([FromBody] OrdemVO ordem)
        {
            var result = _ordemService.Create(ordem);

            if (result == null) return Conflict();

            return Ok();
        }

        [HttpPost]
        [Route("func")]
        [Authorize("Bearer")]
        public IActionResult Post([FromBody]string ordemId, string pesId, int time)
        {
            _ordemService.AddPessoa(ordemId, pesId, time);
            return Ok();
        }

        [HttpPut]
        [Route("update")]
        [Authorize("Bearer")]
        public IActionResult Put([FromBody]OrdemVO ordem)
        {
            _ordemService.Update(ordem);
            return Ok();
        }

        [HttpDelete]
        [Route("delete/{num}")]
        [Authorize("Bearer")]
        public IActionResult Delete(int num)
        {
            _ordemService.Delete(num);
            return NoContent();
        }

    }
}
