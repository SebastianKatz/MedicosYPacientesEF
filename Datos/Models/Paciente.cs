using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos.Models
{
    [Table("Paciente")]
    public class Paciente
    {
        public int Id { get; set; }
        [Required]
        [Column(TypeName = "varchar")] //tipo de dato de SQL Server
        [MaxLength(50)] //limitamos los caracteres
        public string Nombre { get; set; }
        [Required]
        [Column(TypeName = "varchar")] //tipo de dato de SQL Server
        [MaxLength(50)] //limitamos los caracteres
        public string Apellido { get; set; }
        public DateTime fechaNacimiento { get; set; }

        public int NroHistoriaClinica { get; set; }
        public int MedicoId { get; set; }//FK clave externa

        //Propiedad de navegación
        [ForeignKey("MedicoId")]
        public Medico Medico { get; set; }
    }
}
