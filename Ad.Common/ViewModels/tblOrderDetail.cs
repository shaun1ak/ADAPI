namespace Ad.Common.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("tblOrderDetail")]
    public partial class tblOrderDetail
    {
        public int Id { get; set; }

        public int OrderId { get; set; }

        public int ProductId { get; set; }

        public int Qty { get; set; }

        public int Rate { get; set; }

        [Required]
        [StringLength(50)]
        public string cCreatedBy { get; set; }

        public DateTime dCreatedDate { get; set; }

        [StringLength(50)]
        public string cModifiedBy { get; set; }

        public DateTime? dModifiedDate { get; set; }

        public virtual tblOrder tblOrder { get; set; }
    }
}
