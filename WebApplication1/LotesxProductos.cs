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
    
    public partial class LotesxProductos
    {
        public int idLotexProducto { get; set; }
        public Nullable<int> idProducto { get; set; }
        public Nullable<int> idLote { get; set; }
    
        public virtual Lotes Lotes { get; set; }
        public virtual Productos Productos { get; set; }
    }
}
