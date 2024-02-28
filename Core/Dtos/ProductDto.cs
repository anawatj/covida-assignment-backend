using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Core.Dtos
{
    [DataContract]
    public class ProductDto
    {
        [DataMember]
        public virtual string Id { get; set; }
        [DataMember]
        public virtual string ProductName { get; set; }
        [DataMember]
        public virtual string Title { get; set; }
        [DataMember]
        public virtual string Description { get; set; }

        [DataMember]
        public virtual string CategoryId { get; set; }
        [DataMember]
        public virtual string CategoryName { get; set; }

        [DataMember]
        public virtual decimal Price { get; set; }

    
    }
}
