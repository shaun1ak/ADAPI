namespace Ad.Common.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("tblProductMapping")]
    public partial class tblProductMapping
    {
        public int Id { get; set; }

        public int? ManufacturerId { get; set; }

        public int? CategoryId { get; set; }

        public int? ProductTypeId { get; set; }

        public int? ProductId { get; set; }

        public bool? iIsActive { get; set; }

        [Required]
        [StringLength(50)]
        public string cCreatedBy { get; set; }

        public DateTime dCreatedDate { get; set; }

        [StringLength(50)]
        public string cModifiedBy { get; set; }

        [StringLength(50)]
        public string dModifiedDate { get; set; }

        public virtual tblCategory tblCategory { get; set; }

        public virtual tblManufacturer tblManufacturer { get; set; }

        public virtual tblProduct tblProduct { get; set; }

        public virtual tblProductType tblProductType { get; set; }
    }
}
