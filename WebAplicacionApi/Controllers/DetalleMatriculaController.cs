using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebAplicacionApi.Data;
using WebAplicacionApi.Model;

namespace WebAplicacionApi.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class DetalleMatriculaController : ControllerBase
    {
        [HttpPost(Name = "agregarDetalleMatricula")]
        public bool Post([FromBody] DetalleMatricula oDetalleMatricula)
        {
            return DetalleMatriculaData.Agregar(oDetalleMatricula);
        }
        [HttpGet(Name = "ListarDetalleMatricula")]
        public List<DetalleMatricula> Get()
        {
            return DetalleMatriculaData.Listar();
        }
        [HttpGet("{idDetalleMatricula}", Name = "ListarPorIdDetalleMatricula")]
        public DetalleMatricula Get(int idDetalleMatricula)
        {
            return DetalleMatriculaData.ListarPorId(idDetalleMatricula);
        }
        [HttpPut(Name ="editarDetalleMatricula")]
        public bool Put([FromBody] DetalleMatricula oDetalleMatricula)
        {
            return DetalleMatriculaData.Editar(oDetalleMatricula);
        }
        [HttpDelete(Name ="eliminarDetalleMatricula")]
        public bool Delete(int idDetalleMatricula)
        {
            return DetalleMatriculaData.Eliminar(idDetalleMatricula);
        }
    }
}
