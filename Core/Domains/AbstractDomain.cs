using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Core.Domains
{
    public class AbstractDomain<T> : IDomain
    {
        [DataMember]
        public virtual T Id { get; set; }
    
        

    }
}
