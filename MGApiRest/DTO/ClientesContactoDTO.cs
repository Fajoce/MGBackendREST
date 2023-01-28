using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MGApiRest.DTO
{
    public class ClientesContactoDTO
    {
        public int ConId { get; set; }
        public string ConIdentificacion { get; set; }
        public string ConNombreCompleto { get; set; }
        public string ConDireccion { get; set; }
        public string ConTelefono { get; set; }
        public DateTime ConFechaCreacion { get; set; }
        public string ConNombre { get; set; }
    }
}
