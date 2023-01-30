using MGApiRest.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MGApiRest.DTO
{
    public class ClienteMasDeUncontactoDTO
    {
        //public int CliId { get; set; }
        //public int CliContactoId { get; set; }
       public string CliNombreCompleto { get; set; }
        public string CliIdentificacion {get; set; }
        public int Count { get; set; }
    }
}
