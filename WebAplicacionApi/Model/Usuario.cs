using System.Globalization;

namespace WebAplicacionApi.Model
{
    public class Usuario
    {
        public int idUsuario { get; set; }
        public string nombreUsuario { get; set; }
        public string apellidoUsuario { get; set; }
        public string direccionUsuario { get; set; }
        public string telefonoUsuario { get; set; }
        public string correoUsuario { get; set; }

        //llaves foraneas
        //public int idPerfil { get; set; }

        // tablas a las que pertenece 
        //public Perfil perfil { get; set; }
        

    }
}
