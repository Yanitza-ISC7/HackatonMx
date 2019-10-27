using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace clinica.Models
{
    public class HistorialMedico
    {
        public int HistorialMedicoID { get; set; }

        [Required(ErrorMessage = " Diagnostico es requerido.")]
        [StringLength(300, MinimumLength = 3, ErrorMessage = "Descripcion diagnostica del paciente")]
        [DataType(DataType.Text)]
        public string Diagnostico { get; set; }

        [Required(ErrorMessage = " Tratamiento es requerido.")]
        [StringLength(300, MinimumLength = 3, ErrorMessage = "Descripcion del tratamiento del paciente")]
        [DataType(DataType.Text)]
        public string Tratamiento { get; set; }

        [StringLength(300, MinimumLength = 3, ErrorMessage = "Descripcion de Examenes medicos del paciente")]
        [DataType(DataType.Text)]
        public string ExamenMedico { get; set; }

        [Required(ErrorMessage = " Peso es requerido")]
        [RegularExpression(@"^\d+\.\d{0,2}$")]
        [Range(0, 999.99)]
        public decimal Peso { get; set; }

        [Required(ErrorMessage = " Altura es requerido")]
        [RegularExpression(@"^\d+\.\d{0,2}$")]
        [Range(0, 999.99)]
        public decimal Altura { get; set; }

        [Required(ErrorMessage = " fecha de realizacion es requerido")]
        [DisplayName("Fecha de realizacion")]
        [DisplayFormat(DataFormatString = "{0:dd.MM.yyyy}")]
        [DataType(DataType.Date)]
        public DateTime FechaRealizacion { get; set; }

        [DisplayName("Datos paciente")]
        public int PacienteID { get; set; }
        public virtual Paciente Paciente { get; set; }

        [DisplayName("Datos doctor")]
        public int DoctorID { get; set; }
        public virtual Doctor Doctor { get; set; }

    }
}