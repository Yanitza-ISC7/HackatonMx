using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace clinica.Models
{
    public class ContactoEmergencia
    {
        public int ContactoEmergenciaID { get; set; }

        [Required(ErrorMessage = " Nombre es requerido.")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Nombre del hospital debe tener 3 caracteres minimo")]
        [DataType(DataType.Text)]
        public string Nombre { get; set; }

        [Required(ErrorMessage = " Apellido es requerido.")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Nombre debe tener 3 caracteres minimo")]
        [DataType(DataType.Text)]
        public string Apellido { get; set; }

        [Required(ErrorMessage = " Telefono es requerido.")]
        [DataType(DataType.PhoneNumber)]
        [Phone]
        public string Telefono { get; set; }

        [Required(ErrorMessage = " Correo electronico es requerido.")]
        [DisplayName("Correo electronico:")]
        [DataType(DataType.EmailAddress)]
        [EmailAddress]
        public string CorreoElectronico { get; set; }


        [Required(ErrorMessage = " Parentesco es requerido.")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Ejemplo de identificador de parentesco: Madre/Padre")]
        [DataType(DataType.Text)]
        public string Parentesco { get; set; }

        public ICollection<Contacto> Contacto { get; set; }
    }
}