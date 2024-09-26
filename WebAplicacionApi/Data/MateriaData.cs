using System.Data.SqlClient;
using WebAplicacionApi.Model;

namespace WebAplicacionApi.Data
{
    public class MateriaData
    {
        public static bool Agregar(Materia oMateria)
        {
            using (SqlConnection oConexion = new SqlConnection(Conexion.rutaConexion))
            {
                SqlCommand cmd = new SqlCommand("sp_AgregarMateria", oConexion);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@codMateria", oMateria.codMateria);
                cmd.Parameters.AddWithValue("@nomMateria", oMateria.nomMateria);
                cmd.Parameters.AddWithValue("@nomDocente", oMateria.nomDocente);
                cmd.Parameters.AddWithValue("@idUsuario", oMateria.idUsuario);
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
        public static bool Editar(Materia oMateria)
        {
            using (SqlConnection oConexion = new SqlConnection(Conexion.rutaConexion))
            {
                SqlCommand cmd = new SqlCommand("sp_EditarMateria", oConexion);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@idMateria", oMateria.idMateria);
                cmd.Parameters.AddWithValue("@codMateria", oMateria.codMateria);
                cmd.Parameters.AddWithValue("@nomMateria", oMateria.nomMateria);
                cmd.Parameters.AddWithValue("@nomDocente", oMateria.nomDocente);
                cmd.Parameters.AddWithValue("@idUsuario", oMateria.idUsuario);
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
        public static List<Materia> Listar()
        {
            List<Materia> olistMateria = new List<Materia>();
            using (SqlConnection oConexion = new SqlConnection(Conexion.rutaConexion))
            {
                SqlCommand cmd = new SqlCommand("sp_ListarMaterias", oConexion);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                try
                {
                    oConexion.Open();
                    cmd.ExecuteNonQuery();
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            olistMateria.Add(new Materia()
                            {
                                idMateria = Convert.ToInt32(dr["idMateria"]),
                                codMateria = dr["codMateria"].ToString(),
                                nomMateria = dr["nomMateria"].ToString(),
                                nomDocente = dr["nomDocente"].ToString(),
                                idUsuario = Convert.ToInt32(dr["idUsuario"])
                            });
                        }
                    }
                    return olistMateria;
                    }catch (Exception ex)
                    {
                    return olistMateria;
                    }
                 }
        }
        public static Materia ListarPorId (int idMateria)
        {
            Materia oMateria = new Materia();
            using (SqlConnection oConexion = new SqlConnection(Conexion.rutaConexion))
            {
                SqlCommand cmd = new SqlCommand("sp_ListarMaterias", oConexion);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@idMateria", idMateria);
                try
                {
                    oConexion.Open();
                    cmd.ExecuteNonQuery();
                    using(SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            oMateria = new Materia()
                            {
                                idMateria = Convert.ToInt32(dr["idMateria"]),
                                codMateria = dr["codMateria"].ToString(),
                                nomMateria = dr["nomMateria"].ToString(),
                                nomDocente = dr["nomDocente"].ToString(),
                                idUsuario = Convert.ToInt32(dr["idUsuario"])
                            };
                        }
                    }
                    return oMateria;
                }catch (Exception ex)
                {
                    return oMateria;
                }
            }
        }
        public static bool Eliminar(int idMateria)
        {
            using (SqlConnection oConexion = new SqlConnection(Conexion.rutaConexion))
            {
                SqlCommand cmd = new SqlCommand("sp_EliminarMateria", oConexion);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@idMateria", idMateria);
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
