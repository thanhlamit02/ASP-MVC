namespace TX2_De1.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Trangsuc")]
    public partial class Trangsuc
    {
        [Key]
        public int MaTs { get; set; }

        [Required]
        [StringLength(100)]
        public string TenTs { get; set; }

        [Required]
        [StringLength(250)]
        public string Anh { get; set; }

        [StringLength(250)]
        public string Mota { get; set; }

        public int? Soluong { get; set; }

        public decimal Giatien { get; set; }

        public int MaDanhmuc { get; set; }

        public virtual Danhmuc Danhmuc { get; set; }
    }
}
