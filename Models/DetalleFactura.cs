//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace SpaRelajarnosREST.Models
{
	using Newtonsoft.Json;
	using System;
    using System.Collections.Generic;
    
    public partial class DetalleFactura
    {
        public int idDetalleFactura { get; set; }
        public int idFactura { get; set; }
        public int idServicio { get; set; }
        public int cantidad { get; set; }
        public decimal subtotal { get; set; }

		[JsonIgnore]
		public virtual Facturacion Facturacion { get; set; }
		[JsonIgnore]
		public virtual Servicio Servicio { get; set; }
    }
}
