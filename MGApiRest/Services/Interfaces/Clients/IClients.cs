using MGApiRest.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MGApiRest.Services.Interfaces.Clients
{
    public interface IClients
    {
        Task <string>CreateClientAsync(MGClienteDTO client);
        Task<bool> DeleteClientAsync(int id);
        Task<MGClienteDTO> GetClientById(int id);
        Task<IEnumerable<MGClienteDTO>> GetAll();
        Task<bool> UpdateClientAsync(MGClienteDTO genero);
        Task<IEnumerable<ClienteMasDeUncontactoDTO>> GetClientsWMTContacts();
    }
}
