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
    using System.ComponentModel;

    public partial class blog
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public blog()
        {
            this.comments = new HashSet<comment>();
        }
    
        public int id { get; set; }
        [DisplayName("Tiêu đề")]
        public string title { get; set; }
        [DisplayName("Ảnh chính")]

        public string image { get; set; }
        [DisplayName("Mở bài")]

        public string head { get; set; }
        [DisplayName("Nội dung")]

        public string content { get; set; }
        [DisplayName("Hiển thị")]

        public Nullable<bool> IsActive { get; set; }
        [DisplayName("Ngày")]

        public Nullable<System.DateTime> date { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<comment> comments { get; set; }
    }
}
