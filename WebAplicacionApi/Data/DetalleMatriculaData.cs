using System.Data.SqlClient;
using WebAplicacionApi.Model;

namespace WebAplicacionApi.Data
{
    public class DetalleMatriculaData
    {
        public static bool Agregar(DetalleMatricula oDetalleMatricula)
        {
            using (SqlConnection oConexion = new SqlConnection(Conexion.rutaConexion))
            {
                SqlCommand cmd = new SqlCommand("sp_AgregarDetalleMatricula", oConexion);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@idMatricula", oDetalleMatricula.idMatricula);
                cmd.Parameters.AddWithValue("@idSemestreMateria", oDetalleMatricula.idSemestreMateria);

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
        public static bool Editar(DetalleMatricula oDetalleMatricula)
        {
            using (SqlConnection oConexion = new SqlConnection(Conexion.rutaConexion))
            {
                SqlCommand cmd = new SqlCommand("sp_EditarDetalleMatricula", oConexion);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@idDetalleMatricula", oDetalleMatricula.idDetalleMatricula);
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
        public static List<DetalleMatricula> Listar()
        {
            List<DetalleMatricula> olistDetalleMatricula = new List<DetalleMatricula>();
            using (SqlConnection oConexion = new SqlConnection(Conexion.rutaConexion))
            {
                SqlCommand cmd = new SqlCommand("sp_ListarDetalleMatriculas", oConexion);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                try
                {
                    oConexion.Open();
                    cmd.ExecuteNonQuery();
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            olistDetalleMatricula.Add(new DetalleMatricula()
                            {
                                idDetalleMatricula = Convert.ToInt32(dr["idDetalleMatricula"])
                            });
                        }
                    }
                    return olistDetalleMatricula;
                }
                catch (Exception ex)
                {
                    return olistDetalleMatricula;
                }
            }
        }
        public static DetalleMatricula ListarPorId(int idDetalleMatricula)
        {
            DetalleMatricula oDetalleMatricula = new DetalleMatricula();
            using (SqlConnection oConexion = new SqlConnection(Conexion.rutaConexion))
            {
                SqlCommand cmd = new SqlCommand("sp_ListarDetalleMatriculaPorId", oConexion);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@idDetalleMatricula", idDetalleMatricula);
                try
                {
                    oConexion.Open();
                    cmd.ExecuteNonQuery();
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            oDetalleMatricula = new DetalleMatricula()
                            {
                                idDetalleMatricula = Convert.ToInt32(dr["idDetalleMatricula"])
                            };
                        }
                    }
                    return oDetalleMatricula;
                }
                catch (Exception ex)
                {
                    return oDetalleMatricula;
                }

            }
        }
        public static bool Eliminar (int id)
        {
            using (SqlConnection oConexion = new SqlConnection(Conexion.rutaConexion))
            {
                SqlCommand cmd = new SqlCommand("sp_EliminarDetalleMatricula", oConexion);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@idDetalleMatricula", id);
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
