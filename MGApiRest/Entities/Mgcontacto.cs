using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MGApiRest.Entities
{
    public partial class Mgcontacto
    {
        public Mgcontacto()
        {
            Mgcliente = new HashSet<Mgcliente>();
        }
        [Key]
        public int ConId { get; set; }
        [Required(ErrorMessage = "This field is Required")]
        [StringLength(15)]
        public string ConIdentificacion { get; set; }
        [Required(ErrorMessage = "This field is Required")]
        [StringLength(50)]
        public string ConNombreCompleto { get; set; }
        [Required(ErrorMessage = "This field is Required")]
        [StringLength(60)]
        public string ConDireccion { get; set; }
        [Required(ErrorMessage = "This field is Required")]
        [StringLength(15)]
        public string ConTelefono { get; set; }
        [DataType(DataType.Date)]
        public DateTime ConFechaCreacion { get; set; }
        public virtual ICollection<Mgcliente> Mgcliente { get; set; }
    }
}
