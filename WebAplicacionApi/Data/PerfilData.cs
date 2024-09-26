using System.Data.SqlClient;
using System.Diagnostics.CodeAnalysis;
using System.Text.RegularExpressions;
using WebAplicacionApi.Model;

namespace WebAplicacionApi.Data
{
    public class PerfilData
    {
        public static bool Agregar(Perfil oPerfil)
        {
            using (SqlConnection oConexion = new SqlConnection(Conexion.rutaConexion))
            {
                SqlCommand cmd = new SqlCommand("sp_AgregarPerfil", oConexion);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@descripcionPerfil", oPerfil.descripcionPerfil);
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
        public static bool Editar(Perfil oPerfil)
        {
            using (SqlConnection oConexion = new SqlConnection(Conexion.rutaConexion))
            {
                SqlCommand cmd = new SqlCommand("sp_EditarPerfil", oConexion);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@idPerfil", oPerfil.idPerfil);
                cmd.Parameters.AddWithValue("@descripcionPerfil", oPerfil.descripcionPerfil);
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
        public static List<Perfil> Listar()
        {
            List<Perfil> olistPerfil = new List<Perfil>();
            using (SqlConnection oConexion = new SqlConnection(Conexion.rutaConexion))
            {
                SqlCommand cmd = new SqlCommand("sp_ListarPerfiles", oConexion);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                try
                {
                    oConexion.Open();
                    cmd.ExecuteNonQuery();
                    using(SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            olistPerfil.Add(new Perfil()
                            {
                                idPerfil = Convert.ToInt32(dr["idPerfil"]),
                                descripcionPerfil = dr["descripcionPerfil"].ToString()
                            });
                        }
                    }
                    return olistPerfil;
                }catch(Exception ex)
                {
                    return olistPerfil;
                }
            }
        }
        public static Perfil ListarPorId (int idPerfil)
        {
            Perfil oPerfil = new Perfil();
            using (SqlConnection oConexion = new SqlConnection(Conexion.rutaConexion))
            {
                SqlCommand cmd = new SqlCommand("sp_ListarPerfilPorId", oConexion);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@idPerfil", idPerfil);
                try
                {
                    oConexion.Open();
                    cmd.ExecuteNonQuery();
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            oPerfil=new Perfil()
                            {
                                idPerfil = Convert.ToInt32(dr["idPerfil"]),
                                descripcionPerfil = dr["descripcionPerfil"].ToString()
                            };
                        }
                    }
                    return oPerfil;
                }catch (Exception ex)
                {
                    return oPerfil;
                }

            }
        }
        public static bool Eliminar (int id)
        {
            using (SqlConnection oConexion = new SqlConnection(Conexion.rutaConexion))
            {
                SqlCommand cmd = new SqlCommand("sp_EliminarPerfil", oConexion);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@idPerfil", id);
                try
                {
                    oConexion.Open();
                    cmd.ExecuteNonQuery();
                    return true;
                } catch (Exception ex)
                {
                    return false;
                }
            }

        }
    }
}
