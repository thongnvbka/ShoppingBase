using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ShoppingBase.Data.EF.Extensions;
using ShoppingBase.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ShoppingBase.Data.EF.Configurations
{
    class AdvertistmentPageConfiguration :  DbEntityConfiguration<AdvertistmentPage>
    {
        public override void Configure(EntityTypeBuilder<AdvertistmentPage> entity)
        {
            entity.Property(c => c.Id).HasMaxLength(50).IsRequired();
            // etc.
        }
    
    }
}
