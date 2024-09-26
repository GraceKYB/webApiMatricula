using System.Data;
using System.Data.SqlClient;
using WebAplicacionApi.Model;

namespace WebAplicacionApi.Data
{
    public class UsuarioPerfilData
    {
        public static bool Agregar(UsuarioPerfil oUsuarioPerfil)
        {
            using (SqlConnection oConexion = new SqlConnection(Conexion.rutaConexion))
            {
                SqlCommand cmd = new SqlCommand("sp_AgregarUsuarioPerfil", oConexion);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@idUsuario", oUsuarioPerfil.idUsuario);
                cmd.Parameters.AddWithValue("@idPerfil", oUsuarioPerfil.idPerfil);
                try
                {
                    oConexion.Open();
                    cmd.ExecuteNonQuery();
                    return true;
                }
                catch (Exception ex)
                {
                    return false;
                }
            }
        }
        public static bool Editar(UsuarioPerfil oUsuarioPerfil)
        {
            using (SqlConnection oConexion = new SqlConnection(Conexion.rutaConexion))
            {
                SqlCommand cmd = new SqlCommand("sp_EditarUsuarioPerfil", oConexion);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@idUsuarioPerfil", oUsuarioPerfil.idUsuarioPerfil);
                cmd.Parameters.AddWithValue("@idUsuario", oUsuarioPerfil.idUsuario);
                cmd.Parameters.AddWithValue("@idPerfil", oUsuarioPerfil.idPerfil);
                try
                {
                    oConexion.Open();
                    cmd.ExecuteNonQuery();
                    return true;
                }
                catch (Exception ex)
                {
                    return false;
                }
            }
        }
        public static List<UsuarioPerfil> Listar()
        {
            List<UsuarioPerfil> olistUsuarioPerfil = new List<UsuarioPerfil>();
            using (SqlConnection oConexion = new SqlConnection(Conexion.rutaConexion))
            {
                SqlCommand cmd = new SqlCommand("sp_ListarUsuarioPerfil", oConexion);
                cmd.CommandType = CommandType.StoredProcedure;
                try
                {
                    oConexion.Open();
                    cmd.ExecuteNonQuery();
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            olistUsuarioPerfil.Add(new UsuarioPerfil()
                            {
                                idUsuarioPerfil = Convert.ToInt32(dr["idUsuarioPerfil"]),
                                idUsuario = Convert.ToInt32(dr["idUsuario"]),
                                idPerfil = Convert.ToInt32(dr["idPerfil"]),
                            });
                        }
                    }
                    return olistUsuarioPerfil;
                }
                catch (Exception ex)
                {
                    return olistUsuarioPerfil;
                }
            }
        }
        public static UsuarioPerfil ListarPorId(int idUsuarioPerfil)
        {
            UsuarioPerfil oUsuarioPerfil = new UsuarioPerfil();
            using (SqlConnection oConexion = new SqlConnection(Conexion.rutaConexion))
            {
                SqlCommand cmd = new SqlCommand("sp_ListarUsuarioPerfilPorID", oConexion);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@idUsuarioPerfil", idUsuarioPerfil);
                try
                {
                    oConexion.Open();
                    cmd.ExecuteNonQuery();
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            oUsuarioPerfil = new UsuarioPerfil()
                            {
                                idUsuarioPerfil = Convert.ToInt32(dr["idUsuarioPerfil"]),
                                idUsuario = Convert.ToInt32(dr["idUsuario"]),
                                idPerfil = Convert.ToInt32(dr["idPerfil"]),
                            };
                        }
                    }
                    return oUsuarioPerfil;
                }
                catch (Exception ex)
                {
                    return oUsuarioPerfil;
                }
            }
        }
        public static bool Eliminar(int idUsuarioPerfil)
        {
            using (SqlConnection oConexion = new SqlConnection(Conexion.rutaConexion))
            {
                SqlCommand cmd = new SqlCommand("sp_EliminarUsuarioPerfil", oConexion);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@idUsuarioPerfil", idUsuarioPerfil);
                try
                {
                    oConexion.Open();
                    cmd.ExecuteNonQuery();
                    return true;
                }catch (Exception ex)
                {
                    return false;
                }
            }
        }
    }
}
