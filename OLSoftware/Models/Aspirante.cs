using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OLSoftware.Models
{
    public class Aspirante
    {
        public int idAspirantePk { get; set; }
        public int numeroDocumentoAspirante { get; set; }
        public string apellidosNombresAspirante { get; set; }
        public string telefonoAspirante { get; set; }
        public string correoElectronicoAspirante { get; set; }
        public int idUsuarioFk { get; set; }
        public DateTime fechaActualizacion { get; set; }
    }
}