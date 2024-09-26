using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics.CodeAnalysis;
using WebAplicacionApi.Data;
using WebAplicacionApi.Model;

namespace WebAplicacionApi.Controllers
{
   
    [ApiController]
    [Route("api/[controller]")]
    public class UsuarioController : ControllerBase
    {
        [HttpPost(Name ="agregarUsuario")]
        public bool Post([FromBody]Usuario oUsuario)
        {
            return UsuarioData.Agregar(oUsuario);
        }
        [HttpGet(Name ="listarUsuario")]
        public List<Usuario> Get()
        {
            return UsuarioData.Listar();
        }
        [HttpGet("{idUsuario}",Name="ListarPorIdUsuario")]
        public Usuario Get(int idUsuario)
        {
            return UsuarioData.ListarPorId(idUsuario);
        }
        [HttpPut(Name ="editarUsuario")]
        public bool Put([FromBody]Usuario oUsuario)
        {
            return UsuarioData.Editar(oUsuario);
        }
        [HttpDelete(Name ="eliminarUsuario")]
        public bool Delete(int idUsuario)
        {
            return UsuarioData.Eliminar(idUsuario);
        }
    }
}
