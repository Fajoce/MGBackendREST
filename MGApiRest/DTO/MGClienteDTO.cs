using MGApiRest.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MGApiRest.DTO
{
    public class MGClienteDTO
    {
        public int CliId { get; set; }
        public string CliIdentificacion { get; set; }
        public string CliNombreCompleto { get; set; }
        public string CliDireccion { get; set; }
        public string CliTelefono { get; set; }
        public DateTime CliFechaCreacion { get; set; }
        public int? CliContactoId { get; set; }
        public string CliNombreContacto { get; set; }
       // public virtual Mgcontacto CliContacto { get; set; }
    }
}
