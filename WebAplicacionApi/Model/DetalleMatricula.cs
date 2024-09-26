namespace WebAplicacionApi.Model
{
    public class DetalleMatricula
    {
        public int idDetalleMatricula { get; set; }

        //clave foraneas
        public int idMatricula { get; set; }
        public int idSemestreMateria { get; set; }

        //tablas relacionadas
        //public Matricula matricula { get; set; }
        //public SemestreMateria semestreMateria { get; set; }
    }
}
