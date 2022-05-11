namespace BTL_Web_Cinema.Models.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("LichChieu")]
    public partial class LichChieu
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public LichChieu()
        {
            Ves = new HashSet<Ve>();
        }

        [Key]
        [DisplayName("Mã suất chiếu")]
        public int MaSuatChieu { get; set; }
        [DisplayName("Ngày chiếu phim")]
        public DateTime? NgayChieu { get; set; }
        
        public int? CaChieu { get; set; }

        public int? SoPhongChieu { get; set; }

        [Column(TypeName = "money")]
        [DisplayName("Giá vé")]
        public decimal? TienVe { get; set; }

        public int? MaPhim { get; set; }

        public virtual CaChieu CaChieu1 { get; set; }

        public virtual Phim Phim { get; set; }

        public virtual PhongChieu PhongChieu { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Ve> Ves { get; set; }
    }
}
