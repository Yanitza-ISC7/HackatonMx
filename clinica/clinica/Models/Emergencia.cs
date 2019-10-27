using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace clinica.Models
{
    public class Emergencia
    {
        public int EmergenciaID { get; set; }

        [Required(ErrorMessage = " Fecha de Emergencia es requerido")]
        [DisplayName("Fecha de emergencia")]
        [DisplayFormat(DataFormatString = "{0:dd.MM.yyyy}")]
        [DataType(DataType.Date)]
        public DateTime FechaEmergencia { get; set; }

        [DisplayName("Datos del paciente:")]
        public int PacienteID { get; set; }
        public virtual Paciente Paciente { get; set; }

        [DisplayName("Datos paramedico:")]
        public int? ParamedicoID { get; set; }
        public virtual Paramedico Paramedico { get; set; }

        [DisplayName("Datos hospital a trasladar:")]
        public int? HospitalID { get; set; }
        public virtual Hospital Hospital { get; set; }
    }
}