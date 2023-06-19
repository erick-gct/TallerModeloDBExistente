using System;
using System.Collections.Generic;

namespace TallerModeloDBExistente.Models
{
    public partial class Matricula
    {
        public int IdMatricula { get; set; }
        public int? IdAlumno { get; set; }
        public int? NumeroMaterias { get; set; }
        public string? DescripcionMaterias { get; set; }

        public virtual Alumno? IdAlumnoNavigation { get; set; }
    }
}
