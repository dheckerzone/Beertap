using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Beertap.Data
{
    public class BeerMap: EntityTypeConfiguration<Beer>
    {
        public BeerMap()
        {
            HasKey(b => b.BeerId);

            Property(b => b.BeerId).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(b => b.Brand);
            Property(b => b.Milliliters);

            ToTable("Beer");

            HasRequired(o => o.Office)
                .WithMany(b => b.Beers)
                .HasForeignKey(o => o.OfficeId);
        }
    }
}
