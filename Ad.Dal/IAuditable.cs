using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ad.Dal
{
    //See http://lourenco.co.za/blog/2013/07/audit-trails-concurrency-and-soft-deletion-with-entity-framework/
    public interface IAuditable
    {
        string cCreatedBy { get; set; }
        DateTime dCreatedDate { get; set; }
        string cModifiedBy { get; set; }
        DateTime? dModifiedDate { get; set; }
    }

    public class EncryptedAttribute : Attribute
    {
    }
}
