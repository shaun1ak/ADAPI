namespace daltest
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("tblCart")]
    public partial class tblCart
    {
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string CartId { get; set; }

        public int ProductId { get; set; }

        public int Qty { get; set; }

        public int Rate { get; set; }

        [Required]
        [StringLength(50)]
        public string cCreatedBy { get; set; }

        public DateTime dCreatedDate { get; set; }

        public virtual tblProduct tblProduct { get; set; }
    }
}
