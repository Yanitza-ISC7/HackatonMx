using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace clinica.Models
{
    public class Alergias
    {
        public int AlergiasID { get; set; }
        [DisplayName("Alergias")]
        [Required(ErrorMessage = " Nombre de la alergia es requerido.")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Nombre de la alergia debe tener 3 caracteres minimo")]
        [DataType(DataType.Text)]
        public string Nombre { get; set; }

        [Required(ErrorMessage = " Tipo de alergia es requerido.")]
        [StringLength(30, MinimumLength = 3, ErrorMessage = "Tipo de alergia debe tener 3 caracteres minimo")]
        [DataType(DataType.Text)]
        public string Tipo { get; set; }

        public ICollection<Paciente> Paciente { get; set; }
    }
}