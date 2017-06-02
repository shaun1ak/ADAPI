namespace Ad.Common.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("tblCategorySortOrder")]
    public partial class tblCategorySortOrder
    {
        public int Id { get; set; }

        [Required]
        [StringLength(2)]
        public string cCategory { get; set; }

        public int iOrder { get; set; }
    }
}
