namespace WebAplicacionApi.Model
{
    public class Materia
    {
        public int idMateria { get; set; }
        public string codMateria { get; set; }
        public string nomMateria { get; set; }
        public string nomDocente { get; set; }

        //CLave foranea
        public int idUsuario { get; set;}
        //tablas relacionada
       // public Usuario usuario { get; set; }
    }
}
