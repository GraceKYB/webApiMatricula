using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebAplicacionApi.Data;
using WebAplicacionApi.Model;

namespace WebAplicacionApi.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class SemestreMateriaController : ControllerBase
    {
        [HttpPost(Name = "agregarSemestreMateria")]
        public bool Post([FromBody] SemestreMateria oSemestreMateria)
        {
            return SemestreMateriaData.Agregar(oSemestreMateria);
        }
        [HttpGet(Name = "listarSemestreMateria")]
        public List<SemestreMateria> Get()
        {
            return SemestreMateriaData.Listar();
        }
        [HttpGet("{idSemestreMateria}",Name ="listarPorIdSemestreMateria")]
        public SemestreMateria Get(int idSemestreMateria)
        {
            return SemestreMateriaData.ListarPorId(idSemestreMateria);
        }
        [HttpPut(Name ="editarSemestreMateria")]
        public bool Put([FromBody] SemestreMateria oSemestreMateria)
        {
            return SemestreMateriaData.Editar(oSemestreMateria);
        }
        [HttpDelete(Name ="elimnarSemestreMateria")]
        public bool Delete (int idSemestreMateria)
        {
            return SemestreMateriaData.Eliminar(idSemestreMateria);        }

    }
}
