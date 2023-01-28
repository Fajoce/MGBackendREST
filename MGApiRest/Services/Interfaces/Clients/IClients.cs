using MGApiRest.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MGApiRest.Services.Interfaces.Clients
{
    public interface IClients
    {
        Task <string>CreateClientAsync(GetClientsWMTContacts client);
        Task<bool> DeleteClientAsync(int id);
        Task<GetClientsWMTContacts> GetClientById(int id);
        Task<IEnumerable<GetClientsWMTContacts>> GetAll();
        Task<bool> UpdateClientAsync(GetClientsWMTContacts genero);
        Task<IEnumerable<ClienteMasDeUncontacto>> GetClientsWMTContacts();
    }
}
