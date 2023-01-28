using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MGApiRest.Entities
{
    public partial class Mgcliente
    {
        [Key]
        public int CliId { get; set; }
        [Required(ErrorMessage ="This field is Required")]
        [StringLength(15)]
        public string CliIdentificacion { get; set; }
        [Required(ErrorMessage = "This field is Required")]
        [StringLength(50)]
        public string CliNombreCompleto { get; set; }
        [Required(ErrorMessage = "This field is Required")]
        [StringLength(60)]
        public string CliDireccion { get; set; }
        [Required(ErrorMessage = "This field is Required")]
        [StringLength(15)]
        public string CliTelefono { get; set; }
        [DataType(DataType.Date)]
        public DateTime CliFechaCreacion { get; set; }
        [ForeignKey("CliContactoId")]
        public int? CliContactoId { get; set; }
        public virtual Mgcontacto CliContacto { get; set; }
    }
}
