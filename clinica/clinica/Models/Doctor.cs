using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace clinica.Models
{
    public class Doctor
    {
        public int DoctorID { get; set; }

        
        [Required(ErrorMessage = " Nombre es requerido.")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Nombre debe tener 3 caracteres minimo")]
        [DataType(DataType.Text)]
        public string  Nombre { get; set; }

        [Required(ErrorMessage = " Apellido es requerido.")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Nombre debe tener 3 caracteres minimo")]
        [DataType(DataType.Text)]
        public string Apellido { get; set; }

        [Required(ErrorMessage = " Edad es requerido.")]
        [Range(0, 99, ErrorMessage = "Edad entre 0 y 99")]
        public int Edad { get; set; }

        [Required(ErrorMessage = " Especificacion de genero es requerido.")]
        [StringLength(10, MinimumLength = 5, ErrorMessage = "Ejemplo de identificador: Masculino/Femenino")]
        public string Sexo { get; set; }

        [Required(ErrorMessage = "Cedula profesional es requerido.")]
        [StringLength(20, MinimumLength = 8, ErrorMessage = "Cedula profesional debe tener 8 caracteres minimo")]
        public string CedulaProfesional { get; set; }

        [Required(ErrorMessage = " Especialidad es requerido.")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Ejemplo de especialidad: Neurologia")]
        [DataType(DataType.Text)]
        public string Especialidad { get; set; }

        public ICollection<HistorialMedico> HistorialMedico { get; set; }
    }
}