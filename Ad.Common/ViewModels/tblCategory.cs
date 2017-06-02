namespace Ad.Common.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("tblCategory")]
    public partial class tblCategory
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tblCategory()
        {
            tblProductMappings = new HashSet<tblProductMapping>();
        }

        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string cName { get; set; }

        [StringLength(100)]
        public string cDescription { get; set; }

        [Required]
        [StringLength(50)]
        public string cCreatedBy { get; set; }

        public DateTime dCreatedDate { get; set; }

        [StringLength(50)]
        public string cModifiedBy { get; set; }

        [StringLength(50)]
        public string dModifiedDate { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tblProductMapping> tblProductMappings { get; set; }
    }
}
