namespace Ad.Common.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("tblEmployee")]
    public partial class tblEmployee
    {
        [Key]
        [Column(Order = 0)]
        public int ID { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(20)]
        public string cFirstName { get; set; }

        [Key]
        [Column(Order = 2)]
        [StringLength(20)]
        public string cLastName { get; set; }

        public bool? IsDeleted { get; set; }
    }
}
