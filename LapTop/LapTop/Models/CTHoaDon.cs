//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace LapTop.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class CTHoaDon
    {
        public int ma { get; set; }
        public Nullable<int> maHoaDon { get; set; }
        public int soluong { get; set; }
        public int maSanPham { get; set; }
    
        public virtual HoaDon HoaDon { get; set; }
        public virtual SanPham SanPham { get; set; }
    }
}