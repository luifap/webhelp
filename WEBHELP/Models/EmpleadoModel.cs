using System.ComponentModel.DataAnnotations;

namespace WEBHELP.Models
{
    public class EmpleadoModel
    {
        public int IdEmpleado { get; set; }

        [Required(ErrorMessage ="El Campo Nombre es obligatorio")]
        public string? Nombres { get; set; }
        [Required(ErrorMessage = "El Campo de Apellidos es obligatorio")]
        public string? Apellidos { get; set;}
        [Required(ErrorMessage = "El Campo del tipo de documento es obligatorio")]
        public string? Tipo_Documento { get; set; }
        [Required(ErrorMessage = "El Campo de Número de Documento es obligatorio")]
        public string? Identificacion { get; set; }
        [Required(ErrorMessage = "El Campo Fecha de contrato es obligatorio")]
        public string? Fecha_Contrato { get; set; }
        [Required(ErrorMessage = "El Campo del País es obligatorio")]
        public string? Pais { get; set; }
        [Required(ErrorMessage = "El Campo del Área es obligatorio")]
        public string? Area { get; set; }
        [Required(ErrorMessage = "El Campo de Subárea es obligatorio")]
        public string? Subarea { get; set; }
    }
}
