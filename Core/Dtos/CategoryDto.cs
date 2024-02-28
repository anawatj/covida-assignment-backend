using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Core.Dtos
{
    [DataContract]
    public class CategoryDto
    {
        [DataMember]
        public string Id { get; set; }
        [DataMember]
        public virtual string CategoryName { get; set; }
        [DataMember]
        public virtual string Title { get; set; }
        [DataMember]
        public virtual string Description { get; set; }

    }
}
