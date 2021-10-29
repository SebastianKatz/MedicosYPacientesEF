using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowssEF.Models
{
    [Table("Habitacion")]
    public class Habitacion
    {
        public int Id { get; set; }
        public int Numero { get; set; }

        [Required]
        [Column(TypeName = "varchar")]
        [MaxLength(12)]
        public string Estado { get; set; }

        //Mi foreign key
        public int ClinicaId { get; set; }

        //Propiedad de navegacion
        [ForeignKey("ClinicaId")]
        public Clinica Clinica { get; set; }
    }

}
