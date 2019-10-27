using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace clinica.Models
{
    public class clinicaContext : DbContext
    {
        // You can add custom code to this file. Changes will not be overwritten.
        // 
        // If you want Entity Framework to drop and regenerate your database
        // automatically whenever you change your model schema, please use data migrations.
        // For more information refer to the documentation:
        // http://msdn.microsoft.com/en-us/data/jj591621.aspx
    
        public clinicaContext() : base("name=clinicaContext")
        {
        }

        public System.Data.Entity.DbSet<clinica.Models.Paciente> Pacientes { get; set; }

        public System.Data.Entity.DbSet<clinica.Models.Alergias> Alergias { get; set; }

        public System.Data.Entity.DbSet<clinica.Models.EnfermedadesCongenitas> EnfermedadesCongenitas { get; set; }

        public System.Data.Entity.DbSet<clinica.Models.EnfermedadesCronicas> EnfermedadesCronicas { get; set; }

        public System.Data.Entity.DbSet<clinica.Models.ContactoEmergencia> ContactoEmergencias { get; set; }

        public System.Data.Entity.DbSet<clinica.Models.Contacto> Contactoes { get; set; }

        public System.Data.Entity.DbSet<clinica.Models.Doctor> Doctors { get; set; }

        public System.Data.Entity.DbSet<clinica.Models.Paramedico> Paramedicoes { get; set; }

        public System.Data.Entity.DbSet<clinica.Models.Emergencia> Emergencias { get; set; }

        public System.Data.Entity.DbSet<clinica.Models.Hospital> Hospitals { get; set; }

        public System.Data.Entity.DbSet<clinica.Models.HistorialMedico> HistorialMedicoes { get; set; }
    }
}
