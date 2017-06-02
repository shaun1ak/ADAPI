namespace daltest
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("tblShippingAddress")]
    public partial class tblShippingAddress
    {
        public int Id { get; set; }

        public int UserId { get; set; }

        [StringLength(50)]
        public string cAddress1 { get; set; }

        [StringLength(50)]
        public string cAddress2 { get; set; }

        [StringLength(25)]
        public string cCity { get; set; }

        [StringLength(20)]
        public string cState { get; set; }

        [StringLength(20)]
        public string cCountry { get; set; }

        [StringLength(10)]
        public string cPIN { get; set; }

        [StringLength(20)]
        public string cPhone1 { get; set; }

        [StringLength(20)]
        public string cPhone2 { get; set; }

        [Required]
        [StringLength(50)]
        public string cCreatedBy { get; set; }

        public DateTime dCreatedDate { get; set; }

        [StringLength(50)]
        public string cModifiedBy { get; set; }

        public DateTime? dModifiedDate { get; set; }

        public virtual tblUser tblUser { get; set; }
    }
}
