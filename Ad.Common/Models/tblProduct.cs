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
        [StringLength(20)]
        public string cProdId { get; set; }

        [Required]
        [StringLength(500)]
        public string cName { get; set; }

        public string cRange { get; set; }

        [StringLength(2)]
        public string cCategory { get; set; }

        public string cDescription1 { get; set; }

        public string cDescription2 { get; set; }

        [StringLength(100)]
        public string cResolution { get; set; }

        [StringLength(50)]
        public string cAccuracy { get; set; }

        [StringLength(20)]
        public string cPageNo { get; set; }

        [StringLength(100)]
        public string cMake { get; set; }

        public bool? iIsActive { get; set; }

        public decimal dCostPrice { get; set; }

        public decimal dQuotePrice { get; set; }

        public decimal dNetPrice { get; set; }

        public decimal? dDiscount1 { get; set; }

        public decimal? dDiscount2 { get; set; }

        public decimal? dMinStock { get; set; }

        [StringLength(5)]
        public string cDigitalAnalog { get; set; }

        [StringLength(100)]
        public string cImgName { get; set; }

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
