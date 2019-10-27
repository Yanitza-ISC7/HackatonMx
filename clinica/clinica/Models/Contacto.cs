using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace clinica.Models
{
    public class Contacto
    {
        public int ContactoID { get; set; }

        [DisplayName("Datos Paciente:")]
        public int PacienteID { get; set; }
        public virtual Paciente Paciente { get; set; }

        [DisplayName("Contactos de emergenciamj:")]
        public int ContactoEmergenciaID { get; set; }
        public virtual ContactoEmergencia ContactoEmergencia { get; set; }

    }
}