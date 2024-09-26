using System.Data;
using System.Data.SqlClient;
using System.Linq.Expressions;
using WebAplicacionApi.Model;

namespace WebAplicacionApi.Data
{
    public class UsuarioData
    {
        public static bool Agregar(Usuario oUsuario)
        {
            using (SqlConnection oConexion = new SqlConnection(Conexion.rutaConexion))
            {
                SqlCommand cmd = new SqlCommand("sp_AgregarUsuario", oConexion);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@nombreUsuario", oUsuario.nombreUsuario);
                cmd.Parameters.AddWithValue("@apellidoUsuario", oUsuario.apellidoUsuario);
                cmd.Parameters.AddWithValue("@direccionUsuario", oUsuario.direccionUsuario);
                cmd.Parameters.AddWithValue("@telefonoUsuario", oUsuario.telefonoUsuario);
                cmd.Parameters.AddWithValue("@correoUsuario", oUsuario.correoUsuario);
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
        public static bool Editar(Usuario oUsuario)
        {
            using (SqlConnection oConexion = new SqlConnection(Conexion.rutaConexion))
            {
                SqlCommand cmd = new SqlCommand("sp_EditarUsuario", oConexion);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@idUsuario", oUsuario.idUsuario);
                cmd.Parameters.AddWithValue("@nombreUsuario", oUsuario.nombreUsuario);
                cmd.Parameters.AddWithValue("@apellidoUsuario", oUsuario.apellidoUsuario);
                cmd.Parameters.AddWithValue("@direccionUsuario", oUsuario.direccionUsuario);
                cmd.Parameters.AddWithValue("@telefonoUsuario", oUsuario.telefonoUsuario);
                cmd.Parameters.AddWithValue("@correoUsuario", oUsuario.correoUsuario);
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
        public static List<Usuario> Listar()
        {
            List<Usuario> olistUsuario = new List<Usuario>();
            using (SqlConnection oConexion = new SqlConnection(Conexion.rutaConexion))
            {
                SqlCommand cmd = new SqlCommand("sp_ListarUsuarios", oConexion);
                cmd.CommandType = CommandType.StoredProcedure;
                try
                {
                    oConexion.Open();
                    cmd.ExecuteNonQuery();
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            olistUsuario.Add(new Usuario()
                            {
                                idUsuario = Convert.ToInt32(dr["idUsuario"]),
                                nombreUsuario = dr["nombreUsuario"].ToString(),
                                apellidoUsuario = dr["apellidoUsuario"].ToString(),
                                direccionUsuario = dr["direccionUsuario"].ToString(),
                                telefonoUsuario = dr["telefonoUsuario"].ToString(),
                                correoUsuario = dr["correoUsuario"].ToString()
                            });
                        }
                    }
                    return olistUsuario;
                    }
                    catch(Exception ex)
                    {
                    return olistUsuario;
                }
            }
        }
        public static Usuario ListarPorId (int idUsuario)
        {
            Usuario oUsuario = new Usuario();
            using (SqlConnection oConexion = new SqlConnection(Conexion.rutaConexion))
            {
                SqlCommand cmd = new SqlCommand("sp_ListarUsuarioPorId", oConexion);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@idUsuario", idUsuario);
                try
                {
                    oConexion.Open();
                    cmd.ExecuteNonQuery();
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            oUsuario = new Usuario()
                            {
                                idUsuario = Convert.ToInt32(dr["idUsuario"]),
                                nombreUsuario = dr["nombreUsuario"].ToString(),
                                apellidoUsuario = dr["apellidoUsuario"].ToString(),
                                direccionUsuario = dr["direccionUsuario"].ToString(),
                                telefonoUsuario = dr["telefonoUsuario"].ToString(),
                                correoUsuario = dr["correoUsuario"].ToString()
                            };
                        }
                    }
                        return oUsuario;
                    }
                    catch(Exception ex)
                    {
                        return oUsuario;
                    }
                }
            }
        public static bool Eliminar (int idUsuario)
        {
            using (SqlConnection oConexion = new SqlConnection(Conexion.rutaConexion))
            {
                SqlCommand cmd = new SqlCommand("sp_EliminarUsuario", oConexion);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@idUsuario", idUsuario);
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

