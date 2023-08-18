using Clientes.Core.Entities;
using Clientes.Core.Repositories;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Clientes.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientesController : ControllerBase
    {
        private readonly IClienteRepository _clienteRepository;

        public ClientesController(IClienteRepository clienteRepository)
        {
            _clienteRepository = clienteRepository;
        }


        // GET: api/<ClientesController>
        [HttpGet]
        public IActionResult GetAllClientes()
        {
            var clientes = _clienteRepository.GetAllClientes();

            return Ok(clientes);
        }

        // GET api/<ClientesController>/5
        [HttpGet("{id}")]
        public IActionResult GetByIdClientes(int id)
        {
            var clientes = _clienteRepository.GetByIdCliente(id);
            return Ok(clientes);
        }

        // POST api/<ClientesController>
        [HttpPost]
        public IActionResult Post([FromBody] Cliente cliente)
        {
            _clienteRepository.AddCliente(cliente);



            return CreatedAtAction(nameof(GetByIdClientes),new { id = cliente.Id }, cliente);
        }

        // PUT api/<ClientesController>/5
        [HttpPut("{id}")]
        public IActionResult PutCliente(int id, string nome, string sobrenome, string endereco)
        {
            var putCliente = _clienteRepository.UpdateCliente(id, nome, sobrenome, endereco);
            return NoContent();
        }

        // DELETE api/<ClientesController>/5
        [HttpDelete("{id}")]
        public void DeleteCliente(int id)
        {
            var deleteCliente = _clienteRepository.InativaCliente(id);

        }
    }
}
