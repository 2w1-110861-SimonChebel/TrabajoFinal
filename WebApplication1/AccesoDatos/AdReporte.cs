using Easy_Stock.Entidades;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace Easy_Stock.AccesoDatos
{
    public static class AdReporte
    {
        static StringBuilder sbSql = null;
        private static readonly string cadenaConexion = System.Configuration.ConfigurationManager.ConnectionStrings["conexion"].ConnectionString.ToString();

        public static Reporte ObtenerTotalFacturado(Reporte auxRepo)
        {
            sbSql = null;
            Reporte oReporte = null;
            List<Factura> lstFacturas;
            try
            {
                sbSql = new StringBuilder(auxRepo.query.comando);

                using (SqlDataReader dr = SqlHelper.ExecuteReader(cadenaConexion, CommandType.Text, sbSql.ToString(), auxRepo.query.parametros))
                {
                    if (dr.HasRows)
                    {
                        oReporte = new ReTotalFacturado();
                        lstFacturas = new List<Factura>();
                        while (dr.Read())
                        {

                            lstFacturas.Add(
                                new Factura { 
                                    nroFactura = dr.IsDBNull(0) ? default : dr.GetInt32(0),
                                    total = dr.IsDBNull(1) ? default: dr.GetDecimal(1)
                                }
                            );
                            
                        }
                        ((ReTotalFacturado)oReporte).facturas = lstFacturas;
                        ((ReTotalFacturado)oReporte).totalTodasFacturas = ((ReTotalFacturado)oReporte).CalcularTotalFacturado();


                    }
                }
            }
            catch (Exception ex)
            {
                return null;
                throw ex;
            }

            return oReporte;
        }

        public static Reporte ObtenerTotalFacturadoGrafico(Reporte auxRepo)
        {
            sbSql = null;
            Reporte oReporte = null;
            List<Factura> lstFacturas;
            try
            {
                sbSql = new StringBuilder(auxRepo.query.comando);

                using (SqlDataReader dr = SqlHelper.ExecuteReader(cadenaConexion, CommandType.Text, sbSql.ToString(), auxRepo.query.parametros))
                {
                    if (dr.HasRows)
                    {
                        oReporte = new ReTotalFacturado();
                        lstFacturas = new List<Factura>();
                        while (dr.Read())
                        {

                            lstFacturas.Add(
                                new Factura
                                {
                                    nroFactura = dr.IsDBNull(0) ? default : dr.GetInt32(0),
                                    total = dr.IsDBNull(1) ? default : dr.GetDecimal(1),
                                    fecha = dr.IsDBNull(2) ? default : dr.GetDateTime(2)
                                }
                            );

                        }
                        ((ReTotalFacturado)oReporte).facturas = lstFacturas;
                        ((ReTotalFacturado)oReporte).totalTodasFacturas = ((ReTotalFacturado)oReporte).CalcularTotalFacturado();


                    }
                }
            }
            catch (Exception ex)
            {
                return null;
                throw ex;
            }

            return oReporte;
        }


    }
}