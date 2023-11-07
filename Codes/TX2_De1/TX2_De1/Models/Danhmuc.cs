namespace TX2_De1.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Danhmuc")]
    public partial class Danhmuc
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Danhmuc()
        {
            Trangsucs = new HashSet<Trangsuc>();
        }

        [Key]
        public int MaDanhmuc { get; set; }

        [Required]
        [StringLength(50)]
        public string TenDanhmuc { get; set; }

        [StringLength(100)]
        public string Mota { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Trangsuc> Trangsucs { get; set; }
    }
}
