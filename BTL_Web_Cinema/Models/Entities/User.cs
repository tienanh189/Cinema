namespace BTL_Web_Cinema.Models.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("User")]
    public partial class User
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public User()
        {
            Ves = new HashSet<Ve>();
        }

        [Key]
        [StringLength(50)]
        [Required(ErrorMessage = "Hãy nhập vào tên đăng nhập")]
        [DisplayName("Tên đăng nhập")]
        public string UserName { get; set; }
        [Required(ErrorMessage = "Hãy nhập mật khẩu")]
        [StringLength(50)]
        [DataType(DataType.Password)]
        [DisplayName("Mật khẩu")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Hãy nhập lại chính xác mật khẩu")]
        [StringLength(50)]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Hãy nhập lại chính xác mật khẩu")]
        [DisplayName("Nhập lại mật khẩu")]
        public string RePassword { get; set; }

        [Required(ErrorMessage = "Hãy nhập vào họ và tên")]
        [StringLength(50)]
        [DisplayName("Họ và tên")]
        public string TenKH { get; set; }

        [Required(ErrorMessage = "Hãy nhập vào số điện thoại")]
        [StringLength(50)]
        [DisplayName("Số điện thoại")]
        public string Phone { get; set; }

        [Required(ErrorMessage = "Hãy nhập vào email")]
        [StringLength(50)]
        [RegularExpression(@"[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Za-z]{2,4}",
        ErrorMessage = "Email không chính xác.")]
        public string Email { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Ve> Ves { get; set; }
    }
}
