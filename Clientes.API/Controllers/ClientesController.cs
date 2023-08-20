using Clientes.Application.Commands.CreateCliente;
using Clientes.Application.Commands.DeleteCliente;
using Clientes.Application.Commands.UpdateCliente;
using Clientes.Application.Queries.GetAllClientes;
using Clientes.Application.Queries.GetByIdClientes;
using Clientes.Core.Entities;
using Clientes.Core.Repositories;
using MediatR;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Clientes.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientesController : ControllerBase
    {
        
        private readonly IMediator _mediator;
        public ClientesController(IMediator mediator)
        {
            _mediator = mediator;
        }


        // GET: api/<ClientesController>
        [HttpGet]
        public async Task<IActionResult> GetAllClientes()
        {
            var getAllClientes = new GetAllClientesQuery();
            var clientes = await _mediator.Send(getAllClientes);

            return Ok(clientes);
        }

        // GET api/<ClientesController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdClientes(int id)
        {
            var getByIdCliente = new GetByIdClientesQuery(id);
            var cliente = await _mediator.Send(getByIdCliente);

            return Ok(cliente);
        }

        // POST api/<ClientesController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreateClienteCommand cliente)
        {
            if(!ModelState.IsValid)
            {
                var mensagens = ModelState.SelectMany(x => x.Value.Errors).Select(e => e.ErrorMessage).ToList();
                return BadRequest(mensagens);
            }
            var id = await _mediator.Send(cliente);
            if (id <= 0)
            {
                return BadRequest(id);
            }
            return CreatedAtAction(nameof(GetByIdClientes),new { id }, cliente);
        }

        // PUT api/<ClientesController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCliente(int id, [FromBody] UpdateClienteCommand command)
        {
            if (!ModelState.IsValid)
            {
                var mensagens = ModelState.SelectMany(x => x.Value.Errors).Select(e => e.ErrorMessage).ToList();
                return BadRequest(mensagens);
            }
            command.Id = id;
            var result = await _mediator.Send(command);
            return Ok(); //200, 204 ou 201 se criasse um novo recurso.
        }

        // DELETE api/<ClientesController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCliente(int id)
        {
            var deleteCliente = new DeleteClienteCommand(id);
            var cliente = await _mediator.Send(deleteCliente);

            if (cliente == 0)
            {
                return BadRequest();
            }
            return NoContent();
        }
    }
}
