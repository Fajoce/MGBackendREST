using MGApiRest.DTO;
using MGApiRest.Services.Interfaces.Clients;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MGApiRest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientesController : ControllerBase
    {
        public readonly IClients _Irepositorio;

        public ClientesController(IClients repositorio)
        {
            _Irepositorio = repositorio;
        }
        // GET: api/<Clientes>
        [HttpGet]
        public async Task<IEnumerable<MGClienteDTO>> GetAllClients()
        {
            return await _Irepositorio.GetAll();
        }


        [HttpGet("Masdeuno")]
        public async Task<IEnumerable<ClienteMasDeUncontactoDTO>> GetClientsWMT2Contacts()
        {
            return await  _Irepositorio.GetClientsWMTContacts();
        }
        // GET api/<Clientes>/5
        [HttpGet("{id}")]
        public async Task<MGClienteDTO> Get(int id)
        {
            return await _Irepositorio.GetClientById(id);
        }


        // POST api/<Clientes>
        [HttpPost]
        public async Task<string> Post([FromBody] MGClienteDTO clientes)
        {
            return await _Irepositorio.CreateClientAsync(clientes);
        }

        // PUT api/<Clientes>/5
        [HttpPut("{id}")]
        public async Task<ActionResult<MGClienteDTO>> Put(int id, [FromBody] MGClienteDTO cliente)
        {
            if (id != cliente.CliId)
            {
                return BadRequest();
            }

            await _Irepositorio.UpdateClientAsync(cliente);

            return NoContent();
        }

        // DELETE api/<Clientes>/5
        [HttpDelete("{id}")]
        public async Task<bool> Delete(int id)
        {
            return await _Irepositorio.DeleteClientAsync(id);
        }
    }
}
