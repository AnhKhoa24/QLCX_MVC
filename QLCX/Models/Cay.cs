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
    
    public partial class Cay
    {
        public int STTCay { get; set; }
        public int MaDuong { get; set; }
        public Nullable<System.DateTime> NgayTrong { get; set; }
        public Nullable<int> TuoiCayLucTrong { get; set; }
        public Nullable<System.DateTime> NgayChatBo { get; set; }
        public Nullable<int> LoaiCay { get; set; }
    
        public virtual ConDuong ConDuong { get; set; }
        public virtual LoaiCay LoaiCay1 { get; set; }
    }
}
