using System;
using System.Collections.Generic;

namespace TallerModeloDBExistente.Models
{
    public partial class Alumno
    {
        public Alumno()
        {
            Domicilios = new HashSet<Domicilio>();
            Matriculas = new HashSet<Matricula>();
        }

        public int IdAlumno { get; set; }
        public string? ApPaterno { get; set; }
        public string? ApMaterno { get; set; }
        public string? Nombre { get; set; }
        public int? Edad { get; set; }

        public virtual ICollection<Domicilio> Domicilios { get; set; }
        public virtual ICollection<Matricula> Matriculas { get; set; }
    }
}
