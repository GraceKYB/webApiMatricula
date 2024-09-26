using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebAplicacionApi.Data;
using WebAplicacionApi.Model;

namespace WebAplicacionApi.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class PerfilController : ControllerBase
    {
        [HttpPost(Name = "agregarPerfil")]
        public bool Post([FromBody] Perfil oPerfil)
        {
            return PerfilData.Agregar(oPerfil);
        }
        [HttpGet(Name = "listarPerfil")]
        public List<Perfil> Get()
        {
            return PerfilData.Listar();
        }
        [HttpGet("{idPerfil}",Name ="ListarPorIdPerfil")]
        public Perfil Get(int idPerfil)
        {
            return PerfilData.ListarPorId(idPerfil);
        }
        [HttpPut(Name ="editarPerfil")]
        public bool Put([FromBody] Perfil oPerfil)
        {
            return PerfilData.Editar(oPerfil);
        }
        [HttpDelete(Name ="eliminarPerfil")]
        public bool Delete(int idPerfil)
        {
            return PerfilData.Eliminar(idPerfil);
        }
    }
}
