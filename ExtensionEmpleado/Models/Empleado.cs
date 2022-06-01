using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ExtensionEmpleado.Models
{
    [Table("Empleado", Schema = "Ext")]
    public class Empleado
    {
        [Key]
        public int EmpleadoId { get; set; }

        [Required]
        [DisplayName("Nombres")]
        [MaxLength(50)]
        public string Nombre { get; set; }

        [Required]
        [DisplayName("Extensiones")]
        [MaxLength(50)]
        public string Extension { get; set; }
        [Required]
        [DisplayName("Departamentos")]
        [MaxLength(50)]
        public string Departamento { get; set; }
        [Required]
        [DisplayName("Correo")]
        [MaxLength(50)]
        public string Correo { get; set; }

    }
   
}
