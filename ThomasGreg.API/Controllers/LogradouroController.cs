using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ThomasGreg.API.Inputs;
using ThomasGreg.Application;
using ThomasGreg.Application.Handler;
using ThomasGreg.Domain;

namespace ThomasGreg.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LogradouroController : ControllerBase
    {
        [HttpGet("{email}/{logradouro}")]
        public async Task<IActionResult> Get(string email, string logradouro, [FromServices] LogradouroHandler logradouroHandler)
        {
            try
            {
                Logradouro logradouroEncontrado = await logradouroHandler.BuscarLogradouro(email, logradouro);

                return Ok(logradouroEncontrado);
            }
            catch (LogradouroNaoEncontradoException exception)
            {
                return BadRequest(new { exception.Message });
            }

        }

        [HttpGet("{email}")]
        public async Task<IActionResult> GetAll(string email, [FromServices] LogradouroHandler logradouroHandler)
        {
            try
            {
                IEnumerable<Logradouro> logradouros = await logradouroHandler.BuscarTodos(email);

                return Ok(logradouros);
            }
            catch (LogradouroNaoEncontradoException exception)
            {
                return BadRequest(new { exception.Message });
            }
          
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] LogradouroInput logradouroInput, [FromServices] LogradouroHandler logradouroHandler)
        {
            try
            {
                await logradouroHandler.AdicionarLogradouro(logradouroInput.Email, logradouroInput.Logradouro);

                return Ok(new { Message = $"O logradouro {logradouroInput.Logradouro} do cliente {logradouroInput.Email} foi inserido com sucesso." });
            }
            catch (Exception exception)
            {
                return BadRequest(new { exception.Message });
            }
           
        }

        [HttpPut("{logradouroAntigo}")]

        public async Task<IActionResult> Update(string logradouroAntigo, [FromBody] LogradouroInput logradouroInput, [FromServices] LogradouroHandler logradouroHandler)
        {
            try
            {
                await logradouroHandler.AtualizarLogradouro(logradouroInput.Email, logradouroAntigo, logradouroInput.Logradouro);

                return Ok(new { Message = $"O logradouro do cliente {logradouroInput.Email} foi atualizado com sucesso." });
            }
            catch (LogradouroNaoEncontradoException exception)
            {
                return BadRequest(new { exception.Message });
            }
        
        }

        [HttpDelete("{email}/{logradouro}")]

        public async Task<IActionResult> Delete(string email, string logradouro, [FromServices] LogradouroHandler logradouroHandler)
        {
            try
            {
                await logradouroHandler.RemoverLogradouro(email, logradouro);

                return Ok(new { Message = $"O logradouro do cliente {email} foi deletado com sucesso." });
            }
            catch (LogradouroNaoEncontradoException exception)
            {
                return BadRequest(new { exception.Message });
            }
          
        }
    }
}
