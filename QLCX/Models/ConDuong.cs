//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace QLCX.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class ConDuong
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ConDuong()
        {
            this.Cays = new HashSet<Cay>();
            this.ConDuongQuans = new HashSet<ConDuongQuan>();
        }
    
        public int MaDuong { get; set; }
        public string TenDuong { get; set; }
        public Nullable<int> ChieuDai { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Cay> Cays { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ConDuongQuan> ConDuongQuans { get; set; }
    }
}
