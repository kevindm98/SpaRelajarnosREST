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
    
    public partial class Facturacion
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Facturacion()
        {
            this.DetalleFacturas = new HashSet<DetalleFactura>();
        }
    
        public int idFactura { get; set; }
        public int idReserva { get; set; }
        public System.DateTime fechaEmision { get; set; }
        public int documentoCliente { get; set; }
        public decimal total { get; set; }
        public string metodoPago { get; set; }

		[JsonIgnore]
		public virtual Cliente Cliente { get; set; }
		[JsonIgnore]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DetalleFactura> DetalleFacturas { get; set; }
		[JsonIgnore]
		public virtual Reserva Reserva { get; set; }
    }
}
