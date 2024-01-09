using OLSoftware.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace OLSoftware.Data
{
    public class AspiranteData
    {
        public static bool registrarAspirante(Aspirante oAspirante)
        {
            using (SqlConnection oConexion = new SqlConnection(Conexion.rutaConexion))
            {
                SqlCommand cmd = new SqlCommand("registrarAspirante", oConexion);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@numeroDocumentoAspirante", oAspirante.numeroDocumentoAspirante);
                cmd.Parameters.AddWithValue("@apellidosNombresAspirante", oAspirante.apellidosNombresAspirante);
                cmd.Parameters.AddWithValue("@telefonoAspirante", oAspirante.telefonoAspirante);
                cmd.Parameters.AddWithValue("@correoElectronicoAspirante", oAspirante.correoElectronicoAspirante);
                cmd.Parameters.AddWithValue("@idUsuarioFk", oAspirante.idUsuarioFk);
                cmd.Parameters.AddWithValue("@fechaActualizacion", oAspirante.fechaActualizacion);

                try
                {
                    oConexion.Open();
                    cmd.ExecuteNonQuery();
                    return true;
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Esception, Message: \n\r" + ex.Message.ToString() + ". StackTrace: " + ex.StackTrace.ToString());
                    return false;
                }
            }
        }

        public static bool modificarAspirante(Aspirante oAspirante)
        {
            using (SqlConnection oConexion = new SqlConnection(Conexion.rutaConexion))
            {
                SqlCommand cmd = new SqlCommand("modificarAspirante", oConexion);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@idAspirantePk", oAspirante.idAspirantePk);
                cmd.Parameters.AddWithValue("@numeroDocumentoAspirante", oAspirante.numeroDocumentoAspirante);
                cmd.Parameters.AddWithValue("@apellidosNombresAspirante", oAspirante.apellidosNombresAspirante);
                cmd.Parameters.AddWithValue("@telefonoAspirante", oAspirante.telefonoAspirante);
                cmd.Parameters.AddWithValue("@correoElectronicoAspirante", oAspirante.correoElectronicoAspirante);
                cmd.Parameters.AddWithValue("@idUsuarioFk", oAspirante.idUsuarioFk);
                cmd.Parameters.AddWithValue("@fechaActualizacion", oAspirante.fechaActualizacion);

                try
                {
                    oConexion.Open();
                    cmd.ExecuteNonQuery();
                    return true;
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Esception, Message: \n\r" + ex.Message.ToString() + ". StackTrace: " + ex.StackTrace.ToString());
                    return false;
                }
            }
        }

        public static List<Aspirante> listarAspirante()//Este ya está probado
        {
            List<Aspirante> oListarAspirante = new List<Aspirante>();
            using (SqlConnection oConexion = new SqlConnection(Conexion.rutaConexion))
            {
                SqlCommand cmd = new SqlCommand("listarAspirantes", oConexion);
                cmd.CommandType = CommandType.StoredProcedure;

                try
                {
                    oConexion.Open();
                    cmd.ExecuteNonQuery();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            oListarAspirante.Add(new Aspirante()
                            {
                                idAspirantePk = Convert.ToInt32(dr["idAspirantePk"]),
                                numeroDocumentoAspirante = Convert.ToInt32(dr["numeroDocumentoAspirante"]),
                                apellidosNombresAspirante = dr["apellidosNombresAspirante"].ToString(),
                                telefonoAspirante = dr["telefonoAspirante"].ToString(),
                                correoElectronicoAspirante = dr["correoElectronicoAspirante"].ToString(),
                                idUsuarioFk = Convert.ToInt32(dr["idUsuarioFk"]),
                                fechaActualizacion = Convert.ToDateTime(dr["fechaActualizacion"].ToString())
                            });
                        }
                    }
                    return oListarAspirante;
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Esception, Message: \n\r" + ex.Message.ToString() + ". StackTrace: " + ex.StackTrace.ToString());
                    return oListarAspirante;
                }
            }
        } 

        public static Aspirante obtenerAspirante(int idAspirantePk)
        {
            Aspirante oAspirante = new Aspirante();
            using (SqlConnection oConexion = new SqlConnection(Conexion.rutaConexion))
            {
                SqlCommand cmd = new SqlCommand("obtenerAspirante", oConexion);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@idAspirantePk", idAspirantePk);

                try
                {
                    oConexion.Open();
                    cmd.ExecuteNonQuery();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            oAspirante = new Aspirante()
                            {
                                idAspirantePk = Convert.ToInt32(dr["idAspirantePk"]),
                                numeroDocumentoAspirante = Convert.ToInt32(dr["numeroDocumentoAspirante"]),
                                apellidosNombresAspirante = dr["apellidosNombresAspirante"].ToString(),
                                telefonoAspirante = dr["telefonoAspirante"].ToString(),
                                correoElectronicoAspirante = dr["correoElectronicoAspirante"].ToString(),
                                idUsuarioFk = Convert.ToInt32(dr["idUsuarioFk"]),
                                fechaActualizacion = Convert.ToDateTime(dr["fechaActualizacion"].ToString())
                            };
                        }
                    }
                    return oAspirante;
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Esception, Message: \n\r" + ex.Message.ToString() + ". StackTrace: " + ex.StackTrace.ToString());
                    return oAspirante;
                }
            }
        }

        public static bool eliminarAspirante(int idAspirantePk)
        {
            using (SqlConnection oConexion = new SqlConnection(Conexion.rutaConexion))
            {
                SqlCommand cmd = new SqlCommand("eliminarAspirante", oConexion);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@idAspirantePk", idAspirantePk);

                try
                {
                    oConexion.Open();
                    cmd.ExecuteNonQuery();
                    return true;
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Esception, Message: \n\r" + ex.Message.ToString() + ". StackTrace: " + ex.StackTrace.ToString());
                    return false;
                }
            }
        }
    }
}