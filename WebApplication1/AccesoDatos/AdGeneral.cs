﻿using Easy_Stock.Entidades;
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
    }
}