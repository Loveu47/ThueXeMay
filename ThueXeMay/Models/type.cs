//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ThueXeMay.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class type
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public type()
        {
            this.bikes = new HashSet<bike>();
        }
    
        public string type1 { get; set; }
        public Nullable<int> price_hour { get; set; }
        public Nullable<int> price_day { get; set; }
        public Nullable<int> price_month { get; set; }
        public string image { get; set; }
        public int id_type { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<bike> bikes { get; set; }
    }
}