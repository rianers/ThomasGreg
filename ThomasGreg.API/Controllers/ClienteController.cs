using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using ThomasGreg.API.Inputs;
using ThomasGreg.Application.Repositories;
using ThomasGreg.Domain;

namespace ThomasGreg.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClienteController : ControllerBase
    {
        [HttpGet("{email}")]
        public async Task<IActionResult> Get(string email, [FromServices] ClienteApplication clienteApplication)
        {
            Cliente cliente = await clienteApplication.BuscarCliente(email);

            return Ok(cliente);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] ClienteInput clienteInput, [FromServices] ClienteApplication clienteApplication)
        {
            await clienteApplication.InserirCliente(clienteInput.Nome, clienteInput.Email, clienteInput.Logotipo, clienteInput.Logradouro);

            return RedirectToAction(nameof(Get), new { email = clienteInput.Email });
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] ClienteInput clienteInput, [FromServices] ClienteApplication clienteApplication)
        {
            await clienteApplication.AtualizarCliente(clienteInput.Nome, clienteInput.Email, clienteInput.Logotipo);

            return RedirectToAction(nameof(Get), new { email = clienteInput.Email });
        }

        [HttpDelete("{email}")]
        public async Task<IActionResult> Delete(string email, [FromServices] ClienteApplication clienteApplication)
        {
            await clienteApplication.RemoverCliente(email);

            return RedirectToAction(nameof(Get), new { email = email });
        }
    }
}
