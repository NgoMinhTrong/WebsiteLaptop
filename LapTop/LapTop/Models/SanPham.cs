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
    
    public partial class SanPham
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public SanPham()
        {
            this.CTHoaDons = new HashSet<CTHoaDon>();
        }
    
        public int ma { get; set; }
        public string ten { get; set; }
        public double gia { get; set; }
        public int soluong { get; set; }
        public string mota { get; set; }
        public int maThuongHieu { get; set; }
        public Nullable<int> maDanhMuc { get; set; }
        public string hinh { get; set; }
        public System.DateTime ngaycapnhat { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CTHoaDon> CTHoaDons { get; set; }
        public virtual DanhMuc DanhMuc { get; set; }
        public virtual thuongHieu thuongHieu { get; set; }
    }
}
