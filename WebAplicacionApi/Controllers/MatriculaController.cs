using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebAplicacionApi.Data;
using WebAplicacionApi.Model;

namespace WebAplicacionApi.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class MatriculaController : ControllerBase
    {
        [HttpPost(Name = "agregarMatricula")]
        public bool Post([FromBody] Matricula oMatricula)
        {
            return MatriculaData.Agregar(oMatricula);
        }
        [HttpGet(Name ="listarMatricula")]
        public List<Matricula> Get()
        {
            return MatriculaData.Listar();
        }
        [HttpGet("{idMatricula}",Name ="ListarPorIdMatricula")]
        public Matricula Get(int idMatricula)
        {
            return MatriculaData.ListarPorId(idMatricula);
        }
        [HttpPut(Name ="editarMatricula")]
        public bool Put([FromBody]Matricula oMatricula)
        {
            return MatriculaData.Editar(oMatricula);
        }
        [HttpDelete(Name = "eliminarMatricula")]
        public bool Delete(int idMatricula)
        {
            return MatriculaData.Eliminar(idMatricula);
        }
    }
}
