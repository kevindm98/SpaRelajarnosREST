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
    
    public partial class Especialidad
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Especialidad()
        {
            this.EspecialidadEmpleadoes = new HashSet<EspecialidadEmpleado>();
        }
    
        public int idEspecialidad { get; set; }
        public string nombre { get; set; }

		[JsonIgnore]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<EspecialidadEmpleado> EspecialidadEmpleadoes { get; set; }
    }
}
