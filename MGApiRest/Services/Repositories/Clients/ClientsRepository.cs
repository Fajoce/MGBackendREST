using MGApiRest.DTO;
using MGApiRest.Entities;
using MGApiRest.Services.Interfaces.Clients;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MGApiRest.Services.Repositories.Clients
{
    public class ClientsRepository : IClients
    {
        private readonly MentumGroupContext _context;
        public ClientsRepository(MentumGroupContext context)
        {
            _context = context;
        }
        public async Task<string> CreateClientAsync(GetClientsWMTContacts client)
        {
            try
            {
                var entity = new Mgcliente()
                {
                    CliIdentificacion = client.CliIdentificacion,
                    CliNombreCompleto = client.CliNombreCompleto,
                    CliDireccion = client.CliDireccion,
                    CliTelefono = client.CliTelefono,
                    CliContactoId = client.CliContactoId,
                    CliFechaCreacion = client.CliFechaCreacion
                };
                if (entity != null)
                {
                    _context.Mgcliente.Add(entity);
                    await _context.SaveChangesAsync();
                    return "Creado Con exito";
                }
                else
                {
                    return "Error al Crear el Cliente";
                }
                
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<bool> DeleteClientAsync(int id)
        {
            try
            {
                var entity = new Mgcliente()
                {
                    CliId = id
                };
                _context.Mgcliente.Attach(entity);
                _context.Mgcliente.Remove(entity);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<IEnumerable<GetClientsWMTContacts>> GetAll()
        {
            try
            {
                var lst = await _context.Mgcliente.Select(c => new GetClientsWMTContacts()
                {
                    CliId = c.CliId,
                    CliIdentificacion = c.CliIdentificacion,
                    CliNombreCompleto = c.CliNombreCompleto,
                    CliDireccion = c.CliDireccion,
                    CliTelefono = c.CliTelefono,
                    CliContactoId = c.CliContactoId,
                    CliNombreContacto = c.CliContacto.ConNombreCompleto,
                    CliFechaCreacion = c.CliFechaCreacion

                }).OrderByDescending(c=> c.CliFechaCreacion).ToListAsync();
                return lst;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<IEnumerable<ClienteMasDeUncontacto>> GetClientsWMTContacts()
        {


            var morethan = await (from c in _context.Mgcliente join con in _context.Mgcontacto
                                  on c.CliContactoId equals con.ConId
                                  group c by new { c.CliNombreCompleto, c.CliIdentificacion} into g
                                  where g.Count() > 1

                                  select new ClienteMasDeUncontacto
                                  {
                                                                         
                                      CliNombreCompleto = g.Key.CliNombreCompleto,
                                      CliIdentificacion = g.Key.CliIdentificacion,
                                      Count = g.Count()
                                  }

                                  ).ToListAsync();
            
            return morethan;
        }

        public async Task<GetClientsWMTContacts> GetClientById(int id)
        {
            try
            {
                var pedido = await _context.Mgcliente.Select(c => new GetClientsWMTContacts()
                {
                    CliId = c.CliId,
                    CliIdentificacion = c.CliIdentificacion,
                    CliNombreCompleto = c.CliNombreCompleto,
                    CliDireccion = c.CliDireccion,
                    CliTelefono = c.CliTelefono,
                    CliContactoId = c.CliContactoId,
                    CliNombreContacto = c.CliContacto.ConNombreCompleto,
                    CliFechaCreacion = c.CliFechaCreacion
                }).FirstOrDefaultAsync(c => c.CliId == id);
                return pedido;

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

 
        public async Task<bool> UpdateClientAsync(GetClientsWMTContacts cliente)
        {
            var entity = await _context.Mgcliente.FirstOrDefaultAsync(c => c.CliId == cliente.CliId);
            entity.CliIdentificacion = cliente.CliIdentificacion;
            entity.CliNombreCompleto = cliente.CliNombreCompleto;
            entity.CliDireccion = cliente.CliDireccion;
            entity.CliTelefono = cliente.CliTelefono;
            entity.CliContactoId = cliente.CliContactoId;
            entity.CliFechaCreacion = cliente.CliFechaCreacion;
            entity.CliId = cliente.CliId;
            await _context.SaveChangesAsync();
            return true; ;
        }
    }
}
