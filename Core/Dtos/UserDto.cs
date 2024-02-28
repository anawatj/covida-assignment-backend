using Core.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Core.Dtos
{
    [DataContract]
    public class UserDto
    {
        [DataMember]
        public virtual string Id { get; set; }
        [DataMember]
        public virtual string Email { get; set; }
        [DataMember]
        public virtual string FirstName { get; set; }
        [DataMember]
        public virtual string LastName { get; set; }
        [DataMember]
        public virtual string Mobile { get; set; }


        [DataMember]
        public virtual Sex Sex { get; set; }
        [DataMember]
        public virtual DateTime BirthDate { get; set; }
        [DataMember]
        public virtual bool PrivacyAccept { get; set; }
        [DataMember]
        public virtual bool NewsAccept { get; set; }
        [DataMember]
        public virtual string Jwt { get; set; }
    }
}
