using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Beertap.Data
{
    public class OfficeMap: EntityTypeConfiguration<Office>
    {
        public OfficeMap()
        {
            HasKey(o => o.OfficeId);

            Property(o => o.OfficeId).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            Property(o => o.Location).IsRequired().HasMaxLength(100);

            ToTable("Office");
        }
    }
}
