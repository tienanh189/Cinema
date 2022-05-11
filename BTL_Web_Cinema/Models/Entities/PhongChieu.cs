namespace BTL_Web_Cinema.Models.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("PhongChieu")]
    public partial class PhongChieu
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public PhongChieu()
        {
            LichChieux = new HashSet<LichChieu>();
        }

        [Key]
        [DisplayName("Số phòng chiếu")]
        public int SoPhongChieu { get; set; }
        [Required]
        [DisplayName("Tên phòng chiếu")]
        [StringLength(50)]
        public string TenPhong { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<LichChieu> LichChieux { get; set; }
    }
}
