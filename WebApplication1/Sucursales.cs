//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Easy_Stock
{
    using System;
    using System.Collections.Generic;
    
    public partial class Sucursales
    {
        public int idSucursal { get; set; }
        public string nombre { get; set; }
        public string direccion { get; set; }
        public Nullable<int> idDeposito { get; set; }
        public Nullable<int> idLocalidad { get; set; }
        public Nullable<int> idProvincia { get; set; }
    
        public virtual Depositos Depositos { get; set; }
        public virtual Localidades Localidades { get; set; }
        public virtual Provincias Provincias { get; set; }
    }
}