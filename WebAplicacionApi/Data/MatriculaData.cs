using System.Data;
using System.Data.SqlClient;
using WebAplicacionApi.Model;

namespace WebAplicacionApi.Data
{
    public class MatriculaData
    {
        public static bool Agregar(Matricula oMatricula)
        {
            using (SqlConnection oConexion = new SqlConnection(Conexion.rutaConexion))
            {
                SqlCommand cmd = new SqlCommand("sp_AgregarMatricula", oConexion);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@fechaMatricula", oMatricula.fechaMatricula);
                cmd.Parameters.AddWithValue("@tipoMatricula", oMatricula.tipoMatricula);
                cmd.Parameters.AddWithValue("@pagoMatricula", oMatricula.pagoMatricula);
                cmd.Parameters.AddWithValue("@idUsuario", oMatricula.idUsuario);
                cmd.Parameters.AddWithValue("@idSemestre", oMatricula.idSemestre);
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
        public static bool Editar(Matricula oMatricula)
        {
            using (SqlConnection oConexion = new SqlConnection(Conexion.rutaConexion))
            {
                SqlCommand cmd = new SqlCommand("sp_EditarMatricula", oConexion);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@idMatricula", oMatricula.idMatricula);
                cmd.Parameters.AddWithValue("@fechaMatricula", oMatricula.fechaMatricula);
                cmd.Parameters.AddWithValue("@tipoMatricula", oMatricula.tipoMatricula);
                cmd.Parameters.AddWithValue("@pagoMatricula", oMatricula.pagoMatricula);
                cmd.Parameters.AddWithValue("@idUsuario", oMatricula.idUsuario);
                cmd.Parameters.AddWithValue("@idSemestre", oMatricula.idSemestre);
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
        public static List<Matricula> Listar()
        {
            List<Matricula> olistMatricula = new List<Matricula>();
            using (SqlConnection oConexion = new SqlConnection(Conexion.rutaConexion))
            {
                SqlCommand cmd = new SqlCommand("sp_ListarMatriculas", oConexion);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                try
                {
                    oConexion.Open();
                    cmd.ExecuteNonQuery();
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            olistMatricula.Add(new Matricula()
                            {
                                idMatricula = Convert.ToInt32(dr["idMatricula"]),
                                fechaMatricula = dr.GetDateTime(dr.GetOrdinal("fechaMatricula")),
                                tipoMatricula = dr["tipoMatricula"].ToString(),
                                pagoMatricula = dr["pagoMatricula"].ToString(),
                                idUsuario= Convert.ToInt32(dr["idUsuario"]),
                                idSemestre = Convert.ToInt32(dr["idSemestre"])
                            });
                        }
                    }
                    return olistMatricula;
                }
                catch (Exception ex)
                {
                    return olistMatricula;
                }
            }
        }
        public static Matricula ListarPorId(int idMatricula)
        {
            Matricula oMatricula = new Matricula();
            using (SqlConnection oConexion = new SqlConnection(Conexion.rutaConexion))
            {
                SqlCommand cmd = new SqlCommand("sp_ListarMatriculaPorId", oConexion);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@idMatricula", idMatricula);
                try
                {
                    oConexion.Open();
                    cmd.ExecuteNonQuery();
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            oMatricula = new Matricula()
                            {
                                idMatricula = Convert.ToInt32(dr["idMatricula"]),
                                fechaMatricula = dr.GetDateTime(dr.GetOrdinal("fechaMatricula")),
                                tipoMatricula = dr["tipoMatricula"].ToString(),
                                pagoMatricula = dr["pagoMatricula"].ToString(),
                                idUsuario = Convert.ToInt32(dr["idUsuario"]),
                                idSemestre = Convert.ToInt32(dr["idSemestre"])
                            };

                        }
                    }
                    return oMatricula;
                }
                catch (Exception ex)
                {
                    return oMatricula;
                }
            }
        }
        public static bool Eliminar (int idMatricula)
        {
            using (SqlConnection oConexion = new SqlConnection(Conexion.rutaConexion))
            {
                SqlCommand cmd = new SqlCommand("sp_ListarMatriculaPorId", oConexion);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@idMatricula", idMatricula);
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