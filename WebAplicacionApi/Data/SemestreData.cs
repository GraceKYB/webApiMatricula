using System.Data;
using System.Data.SqlClient;
using WebAplicacionApi.Model;

namespace WebAplicacionApi.Data
{
    public class SemestreData
    {
        public static bool Agregar(Semestre oSemestre)
        {
            using (SqlConnection oConexion = new SqlConnection(Conexion.rutaConexion))
            {
                SqlCommand cmd = new SqlCommand("sp_AgregarSemestre", oConexion);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@descrSemestre", oSemestre.descrSemestre);
                cmd.Parameters.AddWithValue("@anioSemestre", oSemestre.anioSemestre);
                cmd.Parameters.AddWithValue("@estadoSemestre", oSemestre.estadoSemetre);
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
        public static bool Editar(Semestre oSemestre)
        {
            using (SqlConnection oConexion = new SqlConnection(Conexion.rutaConexion))
            {
                SqlCommand cmd = new SqlCommand("sp_EditarSemestre", oConexion);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@idSemestre", oSemestre.idSemestre);
                cmd.Parameters.AddWithValue("@descrSemestre", oSemestre.descrSemestre);
                cmd.Parameters.AddWithValue("@anioSemestre", oSemestre.anioSemestre);
                cmd.Parameters.AddWithValue("@estadoSemestre", oSemestre.estadoSemetre);
                try
                {
                    oConexion.Open();
                    cmd.ExecuteNonQuery();
                    return true;
                }
                catch(Exception ex)
                {
                    return false;
                }
            }
        }
        public static List<Semestre> Listar()
        {
            List<Semestre> olistaSemestre = new List<Semestre>();
            using (SqlConnection oConexion = new SqlConnection(Conexion.rutaConexion))
            {
                SqlCommand cmd = new SqlCommand("sp_ListarSemestres", oConexion);
                cmd.CommandType = CommandType.StoredProcedure;
                try
                {
                    oConexion.Open();
                    cmd.ExecuteNonQuery();
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            olistaSemestre.Add(new Semestre()
                            {
                                idSemestre = Convert.ToInt32(dr["idSemestre"]),
                                descrSemestre = dr["descrSemestre"].ToString(),
                                anioSemestre = Convert.ToInt32(dr["anioSemestre"]),
                                estadoSemetre = dr["estadoSemestre"].ToString(),

                            });

                        }
                    }
                    return olistaSemestre;
                }catch(Exception ex)
                {
                    return olistaSemestre;
                }
            }
        }
        public static Semestre ListarPorId(int idSemestre)
        {
            Semestre oSemestre = new Semestre();
            using (SqlConnection oConexion = new SqlConnection(Conexion.rutaConexion))
            {
                SqlCommand cmd = new SqlCommand("sp_ListarSemestrePorId", oConexion);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@idSemestre", idSemestre);
                try
                {
                    oConexion.Open();
                    cmd.ExecuteNonQuery();
                    using(SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            oSemestre = new Semestre()
                            {
                                idSemestre = Convert.ToInt32(dr["idSemestre"]),
                                descrSemestre = dr["descrSemestre"].ToString(),
                                anioSemestre = Convert.ToInt32(dr["anioSemestre"]),
                                estadoSemetre = dr["estadoSemestre"].ToString(),

                            };
                    }
                }
                    return oSemestre;
                }catch(Exception ex)
                {
                    return oSemestre;
                }    
            }
        }
        public static bool Eliminar(int id)
        {
            using (SqlConnection oConexion = new SqlConnection(Conexion.rutaConexion))
            {
                SqlCommand cmd = new SqlCommand("sp_EliminarSemestrePorId", oConexion);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@idSemestre", id);
                try
                {
                    oConexion.Open();
                    cmd.ExecuteNonQuery();
                    return true;
                }catch(Exception ex)
                {
                    return false;
                }
            }
        }
    }


}
