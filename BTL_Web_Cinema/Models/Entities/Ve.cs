namespace BTL_Web_Cinema.Models.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Ve")]
    public partial class Ve
    {
        public Ve() { }
        public Ve(int masc)
        {
            MaSuatChieu=masc;
        }

        [Key]
        [DisplayName("Mã vé")]
        public int MaVe { get; set; }
        [Required(ErrorMessage = "Hãy chọn mã suất chiếu")]
        [DisplayName("Mã suất chiếu")]
        public int? MaSuatChieu { get; set; }

        [StringLength(50)]
        [DisplayName("Tên người dùng")]
        public string UserName { get; set; }
        [Required(ErrorMessage = "Hãy chọn số ghế")]
        [Range(1, 100, ErrorMessage = "Số ghế từ 1 đến 100")]
        [DisplayName("Số ghế")]
        public int? SoGhe { get; set; }

        public virtual LichChieu LichChieu { get; set; }

        public virtual User User { get; set; }
    }
}
