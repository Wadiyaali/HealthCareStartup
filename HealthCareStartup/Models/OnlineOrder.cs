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
    
    public partial class OnlineOrder
    {
        public int OrderID { get; set; }
        public Nullable<int> MedID { get; set; }
        public Nullable<int> DiagID { get; set; }
        public Nullable<int> Quantity { get; set; }
    
        public virtual Diagnosi Diagnosi { get; set; }
        public virtual Medicine Medicine { get; set; }
    }
}
