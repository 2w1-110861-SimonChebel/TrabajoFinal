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
    
    public partial class Reportes
    {
        public int idReporte { get; set; }
        public System.DateTime fecha { get; set; }
        public Nullable<int> idTipoReporte { get; set; }
        public string observaciones { get; set; }
    
        public virtual Tipos_Reportes Tipos_Reportes { get; set; }
    }
}
