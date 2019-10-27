using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace clinica.Models
{
    public class Paramedico
    {
        public int ParamedicoID { get; set; }

        [Required(ErrorMessage = " Nombre es requerido.")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Nombre debe tener 3 caracteres minimo")]
        [DataType(DataType.Text)]
        public string Nombre { get; set; }

        [Required(ErrorMessage = " Apellido es requerido.")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Nombre debe tener 3 caracteres minimo")]
        [DataType(DataType.Text)]
        public string Apellido { get; set; }

        [Required(ErrorMessage = " Edad es requerido.")]
        [Range(0, 99, ErrorMessage = "Edad entre 0 y 99")]
        public int Edad { get; set; }

        [DisplayName("Numero de trabajador:")]
        [Required(ErrorMessage = " Numero de trabajador es requerido")]
        [StringLength(30, MinimumLength = 18, ErrorMessage = "Numero de trabajador debe tener minimo ")]
        public string NumTrabajador { get; set; }

        public ICollection<Emergencia> Emergencia { get; set; }

    }
}