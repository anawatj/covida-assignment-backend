using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Domains;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Implements.Mappings
{
    public class UserMap:IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("Users");
            builder.HasKey(t => t.Id);
            builder.Property(t => t.Email).HasMaxLength(100).IsRequired();
            builder.Property(t => t.Password).HasMaxLength(1000).IsRequired() ;
            builder.Property(t => t.FirstName).HasMaxLength(200).IsRequired();
            builder.Property(t => t.LastName).HasMaxLength(200).IsRequired();
            builder.Property(t => t.Mobile).HasMaxLength(100).IsRequired();
            builder.Property(t => t.BirthDate);
            builder.Property(t => t.PrivacyAccept);
            builder.Property(t => t.NewsAccept);
            builder.Property(t => t.Sex).HasConversion(new EnumToStringConverter<Sex>());
        }

     
    }
}
