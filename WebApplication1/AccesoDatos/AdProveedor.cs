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
    public static class AdProveedor
    {
        static StringBuilder sbSql = null;
        private static readonly string cadenaConexion = System.Configuration.ConfigurationManager.ConnectionStrings["conexion"].ConnectionString.ToString();

        public static List<Proveedor> obtenerProveedoresSimple()
        {
            sbSql = null;
            try
            {
                sbSql = new StringBuilder("SELECT idProveedor, nombre FROM Proveedores ORDER BY nombre");

                using (SqlDataReader dr = SqlHelper.ExecuteReader(cadenaConexion, CommandType.Text, sbSql.ToString()))
                {
                    List<Proveedor> lstProveedores = null;
                    if (dr.HasRows)
                    {
                        lstProveedores = new List<Proveedor>();
                        while (dr.Read())
                        {
                            lstProveedores.Add(new Proveedor
                            {
                                idProveedor = dr.IsDBNull(0) ? 0 : dr.GetInt32(0),
                                nombre = dr.IsDBNull(1) ? "N/d" : dr.GetString(1)
                            });
                        }
                    }
                    return lstProveedores;
                }
            }
            catch (Exception ex)
            {
                return null;
                throw ex;
            }
        }

        public static bool actualizarProveedor(Proveedor oProveedor)
        {
            sbSql = null;
            try
            {
                sbSql = new StringBuilder("UPDATE Proveedores SET");
                sbSql.Append(" nombre=@nombre, email=@email, telefono=@telefono, direccion=@direccion, ");
                sbSql.Append("idLocalidad=@idLocalidad, idProvincia=@idProvincia, codigoPostal=@codPostal, ");
                sbSql.Append("barrio=@barrio ");
                sbSql.Append(" WHERE idProveedor=@id");

                SqlParameter[] param = {
                        new SqlParameter("@id",oProveedor.idProveedor),
                        new SqlParameter("@nombre",oProveedor.nombre),
                        new SqlParameter("@email",oProveedor.email),
                        new SqlParameter("@telefono",oProveedor.telefono),
                        new SqlParameter("@direccion",oProveedor.direccion),
                        new SqlParameter("@idLocalidad",oProveedor.localidad.idLocalidad),
                        new SqlParameter("@idProvincia",oProveedor.provincia.idProvincia),
                        new SqlParameter("@codPostal",oProveedor.codigoPostal),
                        new SqlParameter("@barrio",oProveedor.barrio)

                };
                SqlHelper.ExecuteNonQuery(cadenaConexion, CommandType.Text, sbSql.ToString(), param);
            }
            catch (Exception ex) 
            {
                return false;
                throw ex;
            }
            return true;
        }

        public static bool eliminarProveedor(int id)
        {
            sbSql = null;
            try
            {
                sbSql.Append("UPDATE SET Habilitado=@habilitado WHERE idProveedor=@id");
                SqlParameter[] param = {
                        new SqlParameter("@id",id),
                        new SqlParameter("@habilitado",false),
                    };
                SqlHelper.ExecuteNonQuery(cadenaConexion, CommandType.Text, sbSql.ToString(), param);
            }
            catch (Exception ex)
            {
                return false;
                throw ex;
            }
            return true;
        }

        public static List<Proveedor> ObtenerProveedores(string nombre="",int id=0)
        {
            sbSql = null;
            try
            {
                SqlDataReader dr = null;
                sbSql = new StringBuilder("SELECT pr.idProveedor,pr.nombre,pr.email,pr.telefono,pr.direccion,l.idLocalidad, l.localidad, p.idProvincia,p.provincia, pr.codigoPostal,pr.barrio ");
                sbSql.Append(" FROM Proveedores pr JOIN Localidades l ON pr.idLocalidad = l.idLocalidad JOIN Provincias P ON pr.idProvincia = P.idProvincia");
                sbSql.Append(" WHERE pr.habilitado=1 ");
                if (!string.IsNullOrEmpty(nombre))
                {
                    sbSql.Append(string.Format("{0}{1}{2}", " AND pr.nombre like '%", nombre, "%'"));
                    SqlParameter[] param = {
                        new SqlParameter("@nombre",nombre)
                    };
                    dr = SqlHelper.ExecuteReader(cadenaConexion, CommandType.Text, sbSql.ToString(), param);
                }
                else if(id>0)
                {
                    sbSql.Append(" AND idProveedor=@id");
                    SqlParameter[] param = {
                        new SqlParameter("@id",id)
                    };
                    dr = SqlHelper.ExecuteReader(cadenaConexion, CommandType.Text, sbSql.ToString(),param);
                }
                else dr = SqlHelper.ExecuteReader(cadenaConexion, CommandType.Text, sbSql.ToString());

                using (dr)
                {
                    List<Proveedor> lstProveedores = null;
                    if (dr.HasRows)
                    {
                        lstProveedores = new List<Proveedor>();
                        while (dr.Read())
                        {
                            lstProveedores.Add(new Proveedor
                            {
                                idProveedor = dr.IsDBNull(0) ? 0 : dr.GetInt32(0),
                                nombre = dr.IsDBNull(1) ? "N/d" : dr.GetString(1),
                                email = dr.IsDBNull(2) ? "N/d" : dr.GetString(2),
                                telefono = dr.IsDBNull(3) ? "N/d" : dr.GetString(3),
                                direccion = dr.IsDBNull(4) ? "N/d" : dr.GetString(4),
                                localidad = new Localidad { 
                                    idLocalidad = dr.IsDBNull(5) ? 0 : dr.GetInt32(5),
                                    localidad= dr.IsDBNull(6) ? "N/d" : dr.GetString(6),
                                },
                                provincia = new Provincia { 
                                    idProvincia = dr.IsDBNull(7) ? 0 : dr.GetInt32(7),
                                    provincia = dr.IsDBNull(8) ? "N/d" : dr.GetString(8)
                                },
                                codigoPostal = dr.IsDBNull(9) ? "N/d" : dr.GetString(9),
                                barrio = dr.IsDBNull(10) ? "N/d" : dr.GetString(10)
                            });
                        }
                    }
                    return lstProveedores;
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