using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace clinica.Models
{
    public class Hospital
    {
        public int HospitalID { get; set; }

        [Required(ErrorMessage = " Nombre es requerido.")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Nombre del hospital debe tener 3 caracteres minimo")]
        [DataType(DataType.Text)]
        public string Nombre { get; set; }

        [Required(ErrorMessage = " Direccion es requerido.")]
        [StringLength(30, MinimumLength = 3, ErrorMessage = "Ejemplo de direccion: cerro de la venta, copilco universidad, 04360, ciudad de mexico ")]
        [DataType(DataType.Text)]
        public string Direccion { get; set; }

        [Required(ErrorMessage = " Estado es requerido.")]
        [StringLength(20, MinimumLength = 3, ErrorMessage = "Ejemplo de estado: sonora")]
        [DataType(DataType.Text)]
        public string Estado { get; set; }

        [Required(ErrorMessage = " Pais es requerido.")]
        [StringLength(20, MinimumLength = 3, ErrorMessage = "Ejemplo de pais: Mexico")]
        [DataType(DataType.Text)]
        public string Pais { get; set; }

        [DisplayName("Codigo Postal: ")]
        [Range(0000, 99999, ErrorMessage = "Ejemplo de codigo postal: 84500")]
        public int CodigoPostal { get; set; }


        public ICollection<Emergencia> Emergencia { get; set; }
    }
}