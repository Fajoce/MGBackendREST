using MGApiRest.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MGApiRest.Services.Interfaces.Contacts
{
    public interface IContacts
    {
        Task<string> CreateContactoAsync(MGContactoDTO contacto);
        Task<bool> DeleteContactoAsync(int id);
        Task<MGContactoDTO> GetContactoById(int id);
        Task<IEnumerable<MGContactoDTO>> GetAll();
        Task<bool> UpdateContactoAsync(MGContactoDTO contacto);
        Task<ContactoEnviadoDTO> GetContactoToCreate();
    }
}
