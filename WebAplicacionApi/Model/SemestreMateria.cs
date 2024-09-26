namespace WebAplicacionApi.Model
{
    public class SemestreMateria
    {
        public int idSemetreMateria { get; set; }
    
        //claves foraneas
        public int idSemestre { get; set; }
        public int idMateria { get; set; }

        //Tblas relacionada
        //public Semestre semestre { get; set; }
        //public Materia materia { get; set; }
    }
}
