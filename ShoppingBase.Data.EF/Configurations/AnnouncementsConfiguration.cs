using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ShoppingBase.Data.EF.Extensions;
using ShoppingBase.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ShoppingBase.Data.EF.Configurations
{
    class AnnouncementsConfiguration : DbEntityConfiguration<Announcement>
    {
        public override void Configure(EntityTypeBuilder<Announcement> entity)
        {
            entity.Property(c => c.Id).HasMaxLength(128).IsRequired();
        }
    }
}
