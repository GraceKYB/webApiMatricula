using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebAplicacionApi.Data;
using WebAplicacionApi.Model;

namespace WebAplicacionApi.Controllers
{
   
    [ApiController]
    [Route("api/[controller]")]
    public class UsuarioPerfilController : ControllerBase
    {
        [HttpPost(Name ="agregarUsuarioPerfil")]
        public bool Post([FromBody] UsuarioPerfil oUsuarioPerfil)
        {
            return UsuarioPerfilData.Agregar(oUsuarioPerfil);
        }
        [HttpGet(Name ="listarUsuarioPerfil")]
        public List<UsuarioPerfil> Get()
        {
            return UsuarioPerfilData.Listar();
        }
        [HttpGet("{idUsuarioPerfil}",Name ="ListarPorIdUsuarioPerfil")]
        public UsuarioPerfil Get(int idUsuarioPerfil)
        {
            return UsuarioPerfilData.ListarPorId(idUsuarioPerfil);
        }
        [HttpPut(Name ="EditarUsuarioPerfil")]
        public bool Put([FromBody]UsuarioPerfil oUsuarioPerfil)
        {
            return UsuarioPerfilData.Editar(oUsuarioPerfil);
        }
        [HttpDelete(Name ="EliminarUsuarioPerfil")]
        public bool Delete(int idUsuarioPerfil)
        {
            return UsuarioPerfilData.Eliminar(idUsuarioPerfil);
        }
    }
}
