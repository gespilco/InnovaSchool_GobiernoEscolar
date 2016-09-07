using System;

namespace InnovaSchool.Entity
{
    public partial class EPersona
    {
        public int idPersona { get; set; }
        public string nombre { get; set; }
        public string apellidoPaterno { get; set; }
        public string apellidoMaterno { get; set; }
        public string direccion { get; set; }
        public string telefono { get; set; }
        public string correoElectronico { get; set; }
        public Nullable<int> tipoDocumentoIdentidad { get; set; }
        public string documentoIdentidad { get; set; }
        public string nacionalidad { get; set; }
        public string genero { get; set; }
        public Nullable<System.DateTime> fechaNacimiento { get; set; }
        public string celular { get; set; }
        public string usuarioCreacion { get; set; }
        public Nullable<System.DateTime> fechaCreacion { get; set; }
        public string usuarioModificacion { get; set; }
        public Nullable<System.DateTime> fechaModificacion { get; set; }
    }
}
