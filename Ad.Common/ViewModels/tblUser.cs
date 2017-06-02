namespace Ad.Common.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("tblUser")]
    public partial class tblUser
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tblUser()
        {
            tblBillingAddresses = new HashSet<tblBillingAddress>();
            tblOrders = new HashSet<tblOrder>();
            tblShippingAddresses = new HashSet<tblShippingAddress>();
        }

        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string cUserId { get; set; }

        [Required]
        [StringLength(100)]
        public string cEmailId { get; set; }

        [Required]
        [StringLength(20)]
        public string cPassword { get; set; }

        public Guid? cUserGuId { get; set; }

        [StringLength(20)]
        public string cTitle { get; set; }

        [Required]
        [StringLength(50)]
        public string cFirstName { get; set; }

        [Required]
        [StringLength(50)]
        public string cMiddleName { get; set; }

        [StringLength(50)]
        public string cLastName { get; set; }

        [Required]
        [StringLength(50)]
        public string cCreatedBy { get; set; }

        public DateTime dCreatedDate { get; set; }

        [StringLength(50)]
        public string cModifiedBy { get; set; }

        public DateTime? dModifiedDate { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tblBillingAddress> tblBillingAddresses { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tblOrder> tblOrders { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tblShippingAddress> tblShippingAddresses { get; set; }
    }
}
