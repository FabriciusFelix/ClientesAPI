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
        public ClientesController(IClienteRepository clienteRepository, IMediator mediator)
        {
            _mediator = mediator;
        }


        // GET: api/<ClientesController>
        [HttpGet]
        public IActionResult GetAllClientes()
        {
            var getAllClientes = new GetAllClientesQuery();
            var clientes = _mediator.Send(getAllClientes);

            return Ok(clientes);
        }

        // GET api/<ClientesController>/5
        [HttpGet("{id}")]
        public IActionResult GetByIdClientes(int id)
        {
            var getByIdCliente = new GetByIdClientesQuery(id);
            var cliente = _mediator.Send(getByIdCliente);

            return Ok(cliente);
        }

        // POST api/<ClientesController>
        [HttpPost]
        public IActionResult Post([FromBody] CreateClienteCommand cliente)
        {
            var id = _mediator.Send(cliente);
            if (id.Exception != null)
            {
                return BadRequest(id.Exception.InnerException.Message);
            }
            return CreatedAtAction(nameof(GetByIdClientes),new { id = id }, cliente);
        }

        // PUT api/<ClientesController>/5
        [HttpPut("{id}")]
        public IActionResult PutCliente(int id, [FromBody] UpdateClienteCommand command)
        {
            command.Id = id;
            command.Email = Cliente.ValidarEmail(command.Email);
            _mediator.Send(command);
            return NoContent();
        }

        // DELETE api/<ClientesController>/5
        [HttpDelete("{id}")]
        public IActionResult DeleteCliente(int id)
        {
            var deleteCliente = new DeleteClienteCommand(id);
            var cliente = _mediator.Send(deleteCliente);

            if (cliente.Id == null)
            {
                return BadRequest();
            }

            return NoContent();
        }
    }
}
