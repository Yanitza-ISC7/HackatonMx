using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace clinica.Models
{
    public class Paciente
    {
        public int PacienteID{ get; set; }
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

        [Required(ErrorMessage = " Especificacion de genero es requerido.")]
        [StringLength(10, MinimumLength = 5, ErrorMessage = "Ejemplo de identificador: Masculino/Femenino")]
        public string Sexo { get; set; }

        [Required(ErrorMessage = " Curp es requerida.")]
        [StringLength(19, MinimumLength = 18, ErrorMessage = "Curp debe de contener 18 caracteres minimo")]
        public string Curp { get; set; }

        [Required(ErrorMessage = " Telefono es requerido.")]
        [DataType(DataType.PhoneNumber)]
        [Phone]
        public string Telefono { get; set; }

        [Required(ErrorMessage = " Tipo de sangre es requerido.")]
        [StringLength(5, MinimumLength = 2, ErrorMessage = "Tipo de sangre contiene 2 caracteres minimo")]
        [DisplayName("Tipo de sangre:")]
        public string TipoSangre { get; set; }

        [StringLength(20, MinimumLength = 5, ErrorMessage = "Ingrese su numero de seguro")]
        [DisplayName("Numero de seguro social:")]
        public string Seguro { get; set; }

        [DisplayName("Enfermedades Cronicas:")]
        public int? EnfermedadesCronicasID { get; set; }
        public virtual EnfermedadesCronicas EnfermedadesCronicas { get; set; }

        [DisplayName("Enfermedades Congenitas:")]
        public int? EnfermedadesCongenitasID { get; set; }
        public virtual EnfermedadesCongenitas EnfermedadesCongenitas { get; set; }

        [DisplayName("Alergias:")]
        public int? AlergiasID { get; set; }
        public virtual Alergias Alergias { get; set; }

        public ICollection<Emergencia> Emergencia { get; set; }
        public ICollection<Contacto> Contacto { get; set; }
        public ICollection<HistorialMedico> HistorialMedico { get; set; }

    }
}