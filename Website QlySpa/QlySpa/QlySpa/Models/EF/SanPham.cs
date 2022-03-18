namespace QlySpa.Models.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("SanPham")]
    public partial class SanPham
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public SanPham()
        {
            LoaiDichVus = new HashSet<LoaiDichVu>();
        }

        [Key]
        public int idSanPham { get; set; }

        [StringLength(50)]
        public string TenSP { get; set; }

        public string Anh { get; set; }

        public double? Gia { get; set; }

        [Column(TypeName = "date")]
        public DateTime? NSX { get; set; }

        [Column(TypeName = "date")]
        public DateTime? HSD { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<LoaiDichVu> LoaiDichVus { get; set; }
    }
}
