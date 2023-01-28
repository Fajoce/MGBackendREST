using MGApiRest.DTO;
using MGApiRest.Services.Interfaces.Contacts;
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
    public class ContactosController : ControllerBase
    {
        public readonly IContacts _Irepositorio;

        public ContactosController(IContacts repositorio)
        {
            _Irepositorio = repositorio;
        }
        // GET: api/<ContactosController>
        [HttpGet]
        public async Task<IEnumerable<MGContactoDTO>> Get()
        {
            return await _Irepositorio.GetAll();
        }

        [HttpGet("Carl")]
        public async Task<IEnumerable<ClientesContactoDTO>> GetAllCarl()
        {
            return await _Irepositorio.GetAllBeginWithCarl();
        }
        // GET api/<ContactosController>/5
        [HttpGet("{id}")]
        public async Task<MGContactoDTO> Get(int id)
        {
            return await _Irepositorio.GetContactoById(id);
        }

        // POST api/<ContactosController>
        [HttpPost]
        public async Task<string> Post([FromBody] MGContactoDTO contactos)
        {
            return await _Irepositorio.CreateContactoAsync(contactos);
        }

        // PUT api/<ContactosController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult<MGContactoDTO>> Put(int id, [FromBody] MGContactoDTO contactos)
        {
            if (id != contactos.ConId)
            {
                return BadRequest();
            }

            await _Irepositorio.UpdateContactoAsync(contactos);

            return NoContent();
        }

        // DELETE api/<Clientes>/5
        [HttpDelete("{id}")]
        public async Task<bool> Delete(int id)
        {
            return await _Irepositorio.DeleteContactoAsync(id);
        }
        [HttpGet("Contacto")]
        public async Task<ContactoEnviadoDTO> GetContactToCreate()
        {
            return await _Irepositorio.GetContactoToCreate();
        }
    }
}
