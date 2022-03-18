namespace QlySpa.Models.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("DichVu")]
    public partial class DichVu
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public DichVu()
        {
            CTHDs = new HashSet<CTHD>();
        }

        [Key]
        public int MaDV { get; set; }

        public int? idVoucher { get; set; }

        public int? idNhanVien { get; set; }

        public int? idLoaiDV { get; set; }

        public int? idKhachHang { get; set; }

        public double? Gia { get; set; }

        public DateTime? NgayTao { get; set; }

        public DateTime? NgayKT { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CTHD> CTHDs { get; set; }

        public virtual LoaiDichVu LoaiDichVu { get; set; }

        public virtual KhachHang KhachHang { get; set; }

        public virtual NhanVien NhanVien { get; set; }

        public virtual VouCher VouCher { get; set; }
    }
}
