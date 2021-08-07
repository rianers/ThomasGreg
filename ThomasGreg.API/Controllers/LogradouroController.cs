using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using ThomasGreg.API.Inputs;
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
            Cliente cliente = await logradouroHandler.BuscarLogradouro(email, logradouro);

            return Ok(cliente);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] LogradouroInput logradouroInput, [FromServices] LogradouroHandler logradouroHandler)
        {
            await logradouroHandler.AdicionarLogradouro(logradouroInput.Email, logradouroInput.Logradouro);

            return Ok(RedirectToAction(nameof(Get), new { email = logradouroInput.Email, logradouro = logradouroInput.Logradouro }));
        }

        [HttpPut("{logradouro}")]

        public async Task<IActionResult> Update(string logradouroAntigo, [FromBody] LogradouroInput logradouroInput, [FromServices] LogradouroHandler logradouroHandler)
        {
            await logradouroHandler.AtualizarLogradouro(logradouroInput.Email, logradouroAntigo, logradouroInput.Logradouro);

            return Ok(RedirectToAction(nameof(Get), new { email = logradouroInput.Email, logradouro = logradouroInput.Logradouro }));
        }

        [HttpDelete]

        public async Task<IActionResult> Delete([FromBody] LogradouroInput logradouroInput, [FromServices] LogradouroHandler logradouroHandler)
        {
            await logradouroHandler.RemoverLogradouro(logradouroInput.Email, logradouroInput.Logradouro);

            return Ok(RedirectToAction(nameof(Get), new { email = logradouroInput.Email, logradouro = logradouroInput.Logradouro }));
        }
    }
}
