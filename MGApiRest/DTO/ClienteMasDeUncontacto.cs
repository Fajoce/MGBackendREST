using MGApiRest.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MGApiRest.DTO
{
    public class ClienteMasDeUncontacto
    {
        public int CliId { get; set; }
       public Mgcliente mgcliente { get; set; }
        public int Count { get; set; }
    }
}
