namespace BaiTH11.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Sanpham")]
    public partial class Sanpham
    {
        [Key]
        [DisplayName("Mã vật dụng")]
        public int Mavd { get; set; }

        [Required(ErrorMessage = "Tên vật dụng không được để trống!")]
        [DisplayName("Tên vật dụng")]
        [StringLength(100)]
        public string Tenvd { get; set; }

        [DisplayName("Ảnh")]
        [StringLength(250)]
        public string TenAnh { get; set; }

        [DisplayName("Mô tả")]
        [StringLength(250)]
        public string Mota { get; set; }

        [DisplayName("Giá tiền")]
        [Required(ErrorMessage = "Giá tiền không được để trống!")]
        public decimal Giatien { get; set; }

        [DisplayName("Số lượng")]
        public int? Soluong { get; set; }

        public int MaDanhmuc { get; set; }

        public virtual Danhmuc Danhmuc { get; set; }
    }
}
