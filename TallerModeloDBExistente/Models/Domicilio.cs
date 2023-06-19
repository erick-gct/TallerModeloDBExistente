using System;
using System.Collections.Generic;

namespace TallerModeloDBExistente.Models
{
    public partial class Domicilio
    {
        public int IdDomicilio { get; set; }
        public int? IdAlumno { get; set; }
        public string? Calle { get; set; }

        public virtual Alumno? IdAlumnoNavigation { get; set; }
    }
}
