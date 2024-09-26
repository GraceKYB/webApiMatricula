using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebAplicacionApi.Data;
using WebAplicacionApi.Model;

namespace WebAplicacionApi.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class MateriaController : ControllerBase
    {
        [HttpPost(Name = "agregarMateria")]
        public bool Post([FromBody] Materia oMateria)
        {
            return MateriaData.Agregar(oMateria);
        }
        [HttpGet(Name ="listarMateria")]
        public List<Materia> Get()
        {
            return MateriaData.Listar();
        }
        [HttpGet("{idMateria}",Name ="ListarPorIdMateria")]
        public Materia Get(int idMateria)
        {
            return MateriaData.ListarPorId(idMateria);
        }
        [HttpPut(Name ="editarMateria")]
        public bool Put([FromBody]Materia oMateria)
        {
            return MateriaData.Editar(oMateria);
        }
        [HttpDelete(Name ="eliminarMateria")]
        public bool Delete(int idMateria)
        {
            return MateriaData.Eliminar(idMateria);
        }
    }
}
