namespace Bai_9_ASP_MVC.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Product")]
    public partial class Product
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Key]
        [Required (ErrorMessage = "Mã rượu không được để trống")]
        [DisplayName("Mã rượu")]
        public int ProductID { get; set; }

        [Required(ErrorMessage = "Tên rượu không được để trống!")]
        [StringLength(50)]
        [DisplayName("Tên rượu")]
        public string ProductName { get; set; }

        [Column(TypeName = "text")]
        [DisplayName("Mô tả")]
        public string Description { get; set; }

        [Column(TypeName = "numeric")]
        [Required(ErrorMessage = "Giá nhập không được để trống!")]
        [DisplayName("Giá nhập")]
        public decimal PurchasePrice { get; set; }

        [Column(TypeName = "numeric")]
        [Required(ErrorMessage = "Giá bán không được để trống!")]
        [DisplayName("Giá bán")]
        public decimal Price { get; set; }

        [Required(ErrorMessage = "Số lượng không được để trống!")]
        [DisplayName("Số lượng")]
        public int? Quantity { get; set; }

        [StringLength(20)]
        [DisplayName("Năm sản xuất")]
        public string Vintage { get; set; }

        [Required (ErrorMessage = "Mã danh mục không được để trống!")]
        [StringLength(10)]
        [DisplayName("Mã danh mục")]
        public string CatalogyID { get; set; }

        [Column(TypeName = "text")]
        [DisplayName("Hình ảnh")]
        public string Image { get; set; }

        [Required (ErrorMessage = "Vùng không được để trống!")]
        [StringLength(100)]
        [DisplayName("Vùng")]
        public string Region { get; set; }

        public virtual Catalogy Catalogy { get; set; }
    }
}
