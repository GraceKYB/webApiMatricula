using System.Data;
using System.Data.SqlClient;
using WebAplicacionApi.Model;

namespace WebAplicacionApi.Data
{
    public class SemestreMateriaData
    {
        public static bool Agregar(SemestreMateria oSemestreMateria)
        {
            using (SqlConnection oConexion = new SqlConnection(Conexion.rutaConexion))
            {
                SqlCommand cmd = new SqlCommand("sp_AgregarSemestreMateria", oConexion);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@idSemestre", oSemestreMateria.idSemestre);
                cmd.Parameters.AddWithValue("@idMateria", oSemestreMateria.idMateria);
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
        public static bool Editar(SemestreMateria oSemestreMateria)
        {
            using (SqlConnection oConexion = new SqlConnection(Conexion.rutaConexion))
            {
                SqlCommand cmd = new SqlCommand("sp_EditarSemestreMateria", oConexion);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@idSemestreMateria", oSemestreMateria.idSemetreMateria);
                cmd.Parameters.AddWithValue("@idSemestre", oSemestreMateria.idSemestre);
                cmd.Parameters.AddWithValue("@idMateria", oSemestreMateria.idMateria);
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
        public static List<SemestreMateria> Listar()
        {
            List<SemestreMateria> olistSemestreMateria = new List<SemestreMateria>();
            using (SqlConnection oConexion = new SqlConnection(Conexion.rutaConexion))
            {
                SqlCommand cmd = new SqlCommand("sp_ListarSemestreMateria", oConexion);
                cmd.CommandType = CommandType.StoredProcedure;
                try
                {
                    oConexion.Open();
                    cmd.ExecuteNonQuery();
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            olistSemestreMateria.Add(new SemestreMateria()
                            {
                                idSemetreMateria = Convert.ToInt32(dr["idSemestreMateria"]),
                                idSemestre = Convert.ToInt32(dr["idSemestre"]),
                                idMateria = Convert.ToInt32(dr["idMateria"])
                            });
                        }
                    }
                    return olistSemestreMateria;
                }catch (Exception ex)
                {
                    return olistSemestreMateria;
                }
            }
        }
        public static SemestreMateria ListarPorId (int idSemestreMateria)
        {
            SemestreMateria oSemestreMateria = new SemestreMateria();
            using (SqlConnection oConexion = new SqlConnection(Conexion.rutaConexion))
            {
                SqlCommand cmd = new SqlCommand("sp_ListarSemestreMateriaPorId", oConexion);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@idSemestreMateria",idSemestreMateria);
                try
                {
                    oConexion.Open();
                    cmd.ExecuteNonQuery();
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            oSemestreMateria = new SemestreMateria() 
                            {
                                idSemetreMateria = Convert.ToInt32(dr["idSemestreMateria"]),
                                idSemestre = Convert.ToInt32(dr["idSemestre"]),
                                idMateria = Convert.ToInt32(dr["idMateria"])
                            };
                        }
                    }
                    return oSemestreMateria;
                }
                catch (Exception ex)
                {
                    return oSemestreMateria;
                }
            }
        }
        public static bool Eliminar (int id)
        {
            using (SqlConnection oConexion = new SqlConnection(Conexion.rutaConexion))
            {
                SqlCommand cmd = new SqlCommand("sp_EliminarSemestreMateria", oConexion);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@idSemestreMateria",id);
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