namespace Ad.Common.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("tblDrtMediaConstraint")]
    public partial class tblDrtMediaConstraint
    {
        public int ID { get; set; }

        public DateTime? dVersion { get; set; }

        public int FyId { get; set; }

        public int MarketID { get; set; }

        public int CategoryID { get; set; }

        public int BrandID { get; set; }

        public int SubBrandID { get; set; }

        public int TouchPointID { get; set; }

        public double? fActualSpends { get; set; }

        public double? fMinAnnualSpends { get; set; }

        public double? fMaxAnnualSpends { get; set; }

        public double? fMinMonthlySpends { get; set; }

        public double? fMaxMonthlySpends { get; set; }

        public double? fThresholdSpends { get; set; }

        public int iStatus { get; set; }

        public int? ProjectDrtSubTypeID { get; set; }

        public DateTime dCreatedDate { get; set; }

        [Required]
        [StringLength(25)]
        public string cCreatedBy { get; set; }

        public DateTime? dModifiedDate { get; set; }

        [StringLength(25)]
        public string cModifiedBy { get; set; }
    }
}
