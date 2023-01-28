using MGApiRest.DTO;
using MGApiRest.Entities;
using MGApiRest.Services.Interfaces.Contacts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MGApiRest.Services.Repositories.Contacts
{
    public class ContactsRepository : IContacts
    {
        private readonly MentumGroupContext _context;
        public ContactsRepository(MentumGroupContext context)
        {
            _context = context;
        }
        public async Task<string> CreateContactoAsync(MGContactoDTO contacto)
        {
            try
            {
                var entity = new Mgcontacto()
                {
                    ConIdentificacion = contacto.ConIdentificacion,
                    ConNombreCompleto = contacto.ConNombreCompleto,
                    ConDireccion = contacto.ConDireccion,
                    ConTelefono = contacto.ConTelefono,
                   ConFechaCreacion = contacto.ConFechaCreacion
                };
                if (entity != null)
                {
                    _context.Mgcontacto.Add(entity);
                    await _context.SaveChangesAsync();
                    return "Contacto Creado Con exito";
                }
                else
                {
                    return "Error al Crear el Contacto";
                }

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<bool> DeleteContactoAsync(int id)
        {
            try
            {
                var entity = new Mgcontacto()
                {
                    ConId = id
                };
                _context.Mgcontacto.Attach(entity);
                _context.Mgcontacto.Remove(entity);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<IEnumerable<MGContactoDTO>> GetAll()
        {
            try
            {
                var lst = await _context.Mgcontacto.Select(c => new MGContactoDTO()
                {
                    ConId = c.ConId,
                    ConIdentificacion = c.ConIdentificacion,
                    ConNombreCompleto = c.ConNombreCompleto,
                    ConDireccion = c.ConDireccion,
                    ConTelefono = c.ConTelefono,
                    ConFechaCreacion = c.ConFechaCreacion

                }).OrderByDescending(c => c.ConFechaCreacion).ToListAsync();
                return lst;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<MGContactoDTO> GetContactoById(int id)
        {
            try
            {
                var contacto = await _context.Mgcontacto.Select(c => new MGContactoDTO()
                {
                    ConId = c.ConId,
                    ConIdentificacion = c.ConIdentificacion,
                    ConNombreCompleto = c.ConNombreCompleto,
                    ConDireccion = c.ConDireccion,
                    ConTelefono = c.ConTelefono,
                    ConFechaCreacion = c.ConFechaCreacion
                }).FirstOrDefaultAsync(c => c.ConId == id);
                return contacto;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<ContactoEnviadoDTO> GetContactoToCreate()
        {
            try
            {
                Random r = new Random();
                //var cantidad = _context.Mgcontacto.Count();
                var id = r.Next(1, 5);
                var contacto = await _context.Mgcontacto.Select(c => new ContactoEnviadoDTO()
                {
                    ConId = c.ConId,
                    ConIdentificacion = c.ConIdentificacion,
                    ConNombreCompleto = c.ConNombreCompleto,
                    //ConDireccion = c.ConDireccion,
                    //ConTelefono = c.ConTelefono,
                    //ConFechaCreacion = c.ConFechaCreacion
                }).FirstOrDefaultAsync(c => c.ConId == id);
                   return contacto;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<bool> UpdateContactoAsync(MGContactoDTO contacto)
        {
            var entity = await _context.Mgcontacto.FirstOrDefaultAsync(c => c.ConId == contacto.ConId);
            entity.ConIdentificacion = contacto.ConIdentificacion;
            entity.ConNombreCompleto = contacto.ConNombreCompleto;
            entity.ConDireccion = contacto.ConDireccion;
            entity.ConTelefono = contacto.ConTelefono;
            entity.ConFechaCreacion = contacto.ConFechaCreacion;
            entity.ConId = contacto.ConId;
            await _context.SaveChangesAsync();
            return true; ;
        }
    }
}
