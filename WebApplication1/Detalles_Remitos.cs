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
    
    public partial class Detalles_Remitos
    {
        public int idDetalleRemito { get; set; }
        public Nullable<int> idProducto { get; set; }
        public Nullable<int> cantidad { get; set; }
    
        public virtual Productos Productos { get; set; }
    }
}