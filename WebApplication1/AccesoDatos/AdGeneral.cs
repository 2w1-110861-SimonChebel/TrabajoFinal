using Easy_Stock.Entidades;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Web;

namespace Easy_Stock.AccesoDatos
{
    public static class AdGeneral
    {
        static StringBuilder sbSql = null;
        private static readonly string cadenaConexion = System.Configuration.ConfigurationManager.ConnectionStrings["conexion"].ConnectionString.ToString();




        public static List<Usuario> obtenerUsuarios()
        {
            sbSql = null;
            try
            {
                sbSql = new StringBuilder("SELECT idUsuario,nombre,apellido FROM Usuarios ORDER BY nombre, apellido");

                using (SqlDataReader dr = SqlHelper.ExecuteReader(cadenaConexion, CommandType.Text, sbSql.ToString()))
                {
                    List<Usuario> lstUsuarios = null;
                    if (dr.HasRows)
                    {
                        lstUsuarios = new List<Usuario>();
                        while (dr.Read())
                        {
                            lstUsuarios.Add(new Usuario
                            {
                                idUsuario = dr.IsDBNull(0) ? 0 : dr.GetInt32(0),
                                nombre = dr.IsDBNull(1) ? "N/d" : dr.GetString(1),
                                apellido = dr.IsDBNull(2) ? "N/d" : dr.GetString(2)
                            });
                        }
                    }
                    return lstUsuarios;
                }
            }
            catch (Exception ex)
            {
                return null;
                throw ex;
            }
        }

        public static List<Localidad> obtenerLocalidades()
        {
            sbSql = null;
            try
            {
                sbSql = new StringBuilder("SELECT * FROM Localidades ORDER BY localidad");

                using (SqlDataReader dr = SqlHelper.ExecuteReader(cadenaConexion, CommandType.Text, sbSql.ToString()))
                {
                    List<Localidad> lstLocalidades = null;
                    if (dr.HasRows)
                    {
                        lstLocalidades = new List<Localidad>();
                        while (dr.Read())
                        {
                            lstLocalidades.Add(new Localidad
                            {
                                idLocalidad = dr.IsDBNull(0) ? 0 : dr.GetInt32(0),
                                localidad = dr.IsDBNull(1) ? "N/d" : dr.GetString(1)
                            });
                        }
                    }
                    return lstLocalidades;
                }
            }
            catch (Exception ex)
            {
                return null;
                throw ex;
            }

        }

        public static List<EstadoProducto> ObtenerEstadosProductos()
        {
            sbSql = null;
            try
            {
                sbSql = new StringBuilder("SELECT * FROM Estados_Productos ORDER BY estado");

                using (SqlDataReader dr = SqlHelper.ExecuteReader(cadenaConexion, CommandType.Text, sbSql.ToString()))
                {
                    List<EstadoProducto> lstEstados = null;
                    if (dr.HasRows)
                    {
                        lstEstados = new List<EstadoProducto>();
                        while (dr.Read())
                        {
                            lstEstados.Add(new EstadoProducto
                            {
                                idEstadoProducto = dr.IsDBNull(0) ? 0 : dr.GetInt32(0),
                                estadoProducto = dr.IsDBNull(1) ? "N/d" : dr.GetString(1)
                            });
                        }
                    }
                    return lstEstados;
                }
            }
            catch (Exception ex)
            {
                return null;
                throw ex;
            }

        }

        public static List<TipoFactura> obtenerTiposFacturas()
        {
            sbSql = null;
            sbSql = new StringBuilder("SELECT * FROM Tipos_Facturas ");
            sbSql.Append(" ORDER BY idTipoFactura");

            using (SqlDataReader dr = SqlHelper.ExecuteReader(cadenaConexion, CommandType.Text, sbSql.ToString()))
            {
                List<TipoFactura> lstTipos = null;
                if (dr.HasRows)
                {
                    lstTipos = new List<TipoFactura>();
                    while (dr.Read())
                    {
                        lstTipos.Add(new TipoFactura
                        {
                            idTipoFactura = dr.IsDBNull(0) ? 0 : dr.GetInt32(0),
                            tipoFactura = dr.IsDBNull(1) ? "N/d" : dr.GetString(1)
                        });
                    }
                }
                return lstTipos;
            }

        }

        public static List<TipoTransaccion> obtenerTiposTransacciones(int idTipo = 0)
        {
            sbSql = null;
            try
            {
                sbSql = new StringBuilder("SELECT * FROM Tipos_Transacciones ");
                if (idTipo > 0) sbSql.Append(" WHERE idTipoTransaccion=@idTipo");
                sbSql.Append(" ORDER BY tipoTransaccion");
                SqlParameter[] param = {
                    new SqlParameter("@idTipo",idTipo)
                };


                using (SqlDataReader dr = SqlHelper.ExecuteReader(cadenaConexion, CommandType.Text, sbSql.ToString(), param))
                {
                    List<TipoTransaccion> lstTipos = null;
                    if (dr.HasRows)
                    {
                        lstTipos = new List<TipoTransaccion>();
                        while (dr.Read())
                        {
                            lstTipos.Add(new TipoTransaccion
                            {
                                idTipoTransaccion = dr.IsDBNull(0) ? 0 : dr.GetInt32(0),
                                tipoTransaccion = dr.IsDBNull(1) ? "N/d" : dr.GetString(1)
                            });
                        }
                    }
                    return lstTipos;
                }
            }
            catch (Exception ex)
            {
                return null;
                throw ex;
            }

        }

        public static Empresa obtenerDatosEmpresa()
        {
            sbSql = null;
            try
            {
                sbSql = new StringBuilder("SELECT * FROM Empresas");

                using (SqlDataReader dr = SqlHelper.ExecuteReader(cadenaConexion, CommandType.Text, sbSql.ToString()))
                {
                    Empresa oEmpresa = null;
                    if (dr.HasRows)
                    {
                        dr.Read();
                        oEmpresa = new Empresa
                        {
                            idEmpresa = dr.IsDBNull(0) ? 0 : dr.GetInt32(0),
                            nombre = dr.IsDBNull(1) ? "N/d" : dr.GetString(1),
                            cuit = dr.IsDBNull(2) ? "N/d" : dr.GetString(2),
                            inicioActividades = dr.IsDBNull(3) ? DateTime.Today : dr.GetDateTime(3),
                            direccion = dr.IsDBNull(4) ? "N/d" : dr.GetString(4)
                        };


                    }
                    return oEmpresa;
                }
            }
            catch (Exception ex)
            {
                return null;
                throw ex;
            }

        }

        public static List<Provincia> obtenerProvincias()
        {
            sbSql = null;
            try
            {
                sbSql = new StringBuilder("SELECT * FROM Provincias ORDER BY provincia");

                using (SqlDataReader dr = SqlHelper.ExecuteReader(cadenaConexion, CommandType.Text, sbSql.ToString()))
                {
                    List<Provincia> lstProvincias = null;
                    if (dr.HasRows)
                    {
                        lstProvincias = new List<Provincia>();
                        while (dr.Read())
                        {
                            lstProvincias.Add(new Provincia
                            {
                                idProvincia = dr.IsDBNull(0) ? 0 : dr.GetInt32(0),
                                provincia = dr.IsDBNull(1) ? "N/d" : dr.GetString(1)
                            });
                        }
                    }
                    return lstProvincias;
                }
            }
            catch (Exception ex)
            {
                return null;
                throw ex;
            }
        }

        public static List<Sexo> obtenerSexos()
        {
            sbSql = null;
            try
            {
                sbSql = new StringBuilder("SELECT * FROM Sexos");

                using (SqlDataReader dr = SqlHelper.ExecuteReader(cadenaConexion, CommandType.Text, sbSql.ToString()))
                {
                    List<Sexo> lstSexos = null;
                    if (dr.HasRows)
                    {
                        lstSexos = new List<Sexo>();
                        while (dr.Read())
                        {
                            lstSexos.Add(new Sexo
                            {
                                idSexo = dr.IsDBNull(0) ? 0 : dr.GetInt32(0),
                                sexo = dr.IsDBNull(1) ? "N/d" : dr.GetString(1)
                            });
                        }
                    }
                    return lstSexos;
                }
            }
            catch (Exception ex)
            {
                return null;
                throw ex;
            }
        }

        public static List<TipoEmpresa> obtenerTiposEmpresa()
        {
            sbSql = null;
            try
            {
                sbSql = new StringBuilder("SELECT * FROM Tipos_Empresas ORDER BY tipoEmpresa");

                using (SqlDataReader dr = SqlHelper.ExecuteReader(cadenaConexion, CommandType.Text, sbSql.ToString()))
                {
                    List<TipoEmpresa> lstTipos = null;
                    if (dr.HasRows)
                    {
                        lstTipos = new List<TipoEmpresa>();
                        while (dr.Read())
                        {
                            lstTipos.Add(new TipoEmpresa
                            {
                                idTipoEmpresa = dr.IsDBNull(0) ? 0 : dr.GetInt32(0),
                                tipoEmpresa = dr.IsDBNull(1) ? "N/d" : dr.GetString(1)
                            });
                        }
                    }
                    return lstTipos;
                }
            }
            catch (Exception ex)
            {
                return null;
                throw ex;
            }
        }
        public static List<Marca> obtenerMarcas()
        {
            sbSql = null;
            try
            {
                sbSql = new StringBuilder("SELECT * FROM Marcas ORDER BY marca");

                using (SqlDataReader dr = SqlHelper.ExecuteReader(cadenaConexion, CommandType.Text, sbSql.ToString()))
                {
                    List<Marca> lstMarcas = null;
                    if (dr.HasRows)
                    {
                        lstMarcas = new List<Marca>();
                        while (dr.Read())
                        {
                            lstMarcas.Add(new Marca
                            {
                                idMarca = dr.IsDBNull(0) ? 0 : dr.GetInt32(0),
                                marca = dr.IsDBNull(1) ? "N/d" : dr.GetString(1)
                            });
                        }
                    }
                    return lstMarcas;
                }
            }
            catch (Exception ex)
            {
                return null;
                throw ex;
            }
        }

        public static List<TipoCliente> obtenerTiposClientes()
        {
            sbSql = null;
            try
            {
                sbSql = new StringBuilder("SELECT * FROM Tipos_Clientes ORDER BY idTipoCliente");

                using (SqlDataReader dr = SqlHelper.ExecuteReader(cadenaConexion, CommandType.Text, sbSql.ToString()))
                {
                    List<TipoCliente> lstTipos = null;
                    if (dr.HasRows)
                    {
                        lstTipos = new List<TipoCliente>();
                        while (dr.Read())
                        {
                            lstTipos.Add(new TipoCliente
                            {
                                idTipoCliente = dr.IsDBNull(0) ? 0 : dr.GetInt32(0),
                                tipoCliente = dr.IsDBNull(1) ? "N/d" : dr.GetString(1)
                            });
                        }
                    }
                    return lstTipos;
                }
            }
            catch (Exception ex)
            {
                return null;
                throw ex;
            }
        }


        public static List<FormaPago> obtenerFormasDePago()
        {
            sbSql = null;
            try
            {
                sbSql = new StringBuilder("SELECT * FROM Formas_Pago ORDER BY formaPago");

                using (SqlDataReader dr = SqlHelper.ExecuteReader(cadenaConexion, CommandType.Text, sbSql.ToString()))
                {
                    List<FormaPago> lstFormasPago = null;
                    if (dr.HasRows)
                    {
                        lstFormasPago = new List<FormaPago>();
                        while (dr.Read())
                        {
                            lstFormasPago.Add(new FormaPago
                            {
                                idFormaPago = dr.IsDBNull(0) ? 0 : dr.GetInt32(0),
                                formaPago = dr.IsDBNull(1) ? "N/d" : dr.GetString(1),
                                porcentajeRecargo = dr.IsDBNull(2) ? 0 : dr.GetInt32(2)
                            });
                        }
                    }
                    return lstFormasPago;
                }
            }
            catch (Exception ex)
            {
                return null;
                throw ex;
            }
        }

        public static bool ReestablecerClave(string email, string clave)
        {
            sbSql = null;

            try
            {
                sbSql = new StringBuilder("UPDATE Usuarios SET Clave = @clave WHERE email = @email");

                SqlParameter[] parametros = {new SqlParameter("@email",email), new SqlParameter("@clave",clave) };

                SqlHelper.ExecuteNonQuery(cadenaConexion, CommandType.Text, sbSql.ToString(), parametros);
            }
            catch (Exception ex)
            {
                return false;
                throw ex;
            }
            return true;
        }


  
    }
}