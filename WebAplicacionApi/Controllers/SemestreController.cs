using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebAplicacionApi.Data;
using WebAplicacionApi.Model;

namespace WebAplicacionApi.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class SemestreController : ControllerBase
    {
        [HttpPost(Name = "agregaarSemestre")]
        public bool Post([FromBody] Semestre oSemestre)
        {
            return SemestreData.Agregar(oSemestre);
        }
        [HttpGet(Name = "ListarSemesre")]
        public List<Semestre> Get()
        {
            return SemestreData.Listar();
        }
        [HttpGet("{idSemestre}", Name = "ListarPorIdSemestre")]
        public Semestre Get(int idSemestre)
        {
            return SemestreData.ListarPorId(idSemestre);
        }
        [HttpPut(Name = "EditarSemestre")]
        public bool Put([FromBody] Semestre oSemestre)
        {
            return SemestreData.Editar(oSemestre);
        }
        [HttpDelete(Name = "eliminarSemestre")]
        public bool Delete(int idSemestre)
        {
            return SemestreData.Eliminar(idSemestre);
        }
    }
}
