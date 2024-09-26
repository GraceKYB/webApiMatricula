namespace WebAplicacionApi.Model
{
    public class UsuarioPerfil
    {
        public int idUsuarioPerfil { get; set; }

        //claves 

        public int idUsuario { get; set; }
        public int idPerfil { get; set; }
    }
}
