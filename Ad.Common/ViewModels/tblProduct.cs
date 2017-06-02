namespace Ad.Common.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("tblProduct")]
    public partial class tblProduct
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tblProduct()
        {
            tblCarts = new HashSet<tblCart>();
            tblProductMappings = new HashSet<tblProductMapping>();
        }

        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string cName { get; set; }

        [StringLength(100)]
        public string cDescription1 { get; set; }

        [StringLength(100)]
        public string cDescription2 { get; set; }

        public bool? iIsActive { get; set; }

        public double iRate { get; set; }

        [Required]
        [StringLength(50)]
        public string cCreatedBy { get; set; }

        public DateTime dCreatedDate { get; set; }

        [StringLength(50)]
        public string cModifiedBy { get; set; }

        [StringLength(50)]
        public string dModifiedDate { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tblCart> tblCarts { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tblProductMapping> tblProductMappings { get; set; }
    }
}
