namespace BTL_Web_Cinema.Models.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.Web;

    [Table("Phim")]
    public partial class Phim
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Phim()
        {
            Anh = "~/Content/Images/movies_1.jpg";
            LichChieux = new HashSet<LichChieu>();
        }


        [Key]
        [DisplayName("Mã phim")]
        public int MaPhim { get; set; }

        [StringLength(100)]
        [DisplayName("Tên phim")]
        public string TenPhim { get; set; }

        public int? MaLoai { get; set; }

        [StringLength(100)]
        [DisplayName("Mô tả phim")]
        public string MoTaPhim { get; set; }

        [Column(TypeName = "money")]
        [DisplayName("Giá vé")]
        public decimal? GiaNhapPhim { get; set; }

        [StringLength(50)]
        [DisplayName("Hình ảnh")]
        public string Anh { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<LichChieu> LichChieux { get; set; }

        public virtual TheLoai TheLoai { get; set; }

        [NotMapped]
        public HttpPostedFileBase ImageUpLoad { get; set; }
    }
}
