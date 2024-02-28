using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Core.Domains
{
    [DataContract]
    public class Product : AbstractDomain<string>
    {
        [DataMember]
        public virtual string ProductName { get; set; }
        [DataMember]
        public virtual string Title { get; set; }
        [DataMember]
        public virtual string Description { get; set; }
        
        public virtual Category Category { get; set; }

        [DataMember]
        public virtual string CategoryId { get; set; }

        [DataMember]
        public virtual decimal Price { get; set; }

       
    }
}
