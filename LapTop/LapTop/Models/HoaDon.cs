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
    
    public partial class HoaDon
    {
        internal bool tinhtranggiaohang;
        internal bool dathanhtoan;

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public HoaDon()
        {
            this.CTHoaDons = new HashSet<CTHoaDon>();
        }
    
        public int ma { get; set; }
        public int makh { get; set; }
        public Nullable<System.DateTime> ngaysuat { get; set; }
        public double thanhtien { get; set; }
        public Nullable<System.DateTime> ngaydat { get; set; }
    
        public virtual Account Account { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CTHoaDon> CTHoaDons { get; set; }
    }
}
