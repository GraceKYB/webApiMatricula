namespace WebAplicacionApi.Model
{
    public class Matricula
    {
        public int idMatricula { get; set; }
        public DateTime fechaMatricula { get; set; }
        public string tipoMatricula { get; set; }
        public string pagoMatricula { get; set; }

        // claves foraneas

        public int idUsuario { get; set; }
        public int idSemestre { get; set; }

        //public Usuario usuario { get; set; }
        //public Semestre semestre { get; set; }
    }
}
