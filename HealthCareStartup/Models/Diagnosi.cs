//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace HealthCareStartup.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Diagnosi
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Diagnosi()
        {
            this.OnlineOrders = new HashSet<OnlineOrder>();
        }
    
        public int DiagID { get; set; }
        public Nullable<int> DocID { get; set; }
        public Nullable<int> PatID { get; set; }
        public Nullable<int> HospID { get; set; }
        public string Details { get; set; }
        public string Results { get; set; }
    
        public virtual Doctor Doctor { get; set; }
        public virtual Hospital Hospital { get; set; }
        public virtual Patient Patient { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<OnlineOrder> OnlineOrders { get; set; }
    }
}
