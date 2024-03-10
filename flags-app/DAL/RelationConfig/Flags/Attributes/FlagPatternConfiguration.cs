using DAL.Models.Flags.Attributes;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace DAL.Relations.Flags.Attributes;

internal class FlagPatternConfiguration : IEntityTypeConfiguration<FlagPattern>
{
    public void Configure(EntityTypeBuilder<FlagPattern> builder)
    {
        builder
            .HasOne(fp => fp.Name)
            .WithMany(c => c.FlagPatternNames)
            .HasForeignKey(fp => fp.NameId);

        builder
            .HasOne(fp => fp.Color)
            .WithMany(c => c.FlagPatternColors)
            .HasForeignKey(fp => fp.ColorId);

        builder
            .HasOne(fp => fp.Area)
            .WithMany(fa => fa.Patterns)
            .HasForeignKey(fa => fa.AreaId);
    }
}
