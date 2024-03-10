using DAL.Models.Flags.Attributes;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DAL.Relations.Flags.Attributes;

internal class FlagAreaConfiguration : IEntityTypeConfiguration<FlagArea>
{
    public void Configure(EntityTypeBuilder<FlagArea> builder)
    {
        builder
            .HasOne(fa => fa.Parent)
            .WithMany(fa => fa.Children)
            .HasForeignKey(fa => fa.ParentId);

        builder
            .HasOne(fa => fa.Flag)
            .WithOne(fa => fa.Area)
            .HasForeignKey<FlagArea>(fa => fa.FlagId);

        builder
            .HasOne(fa => fa.Color)
            .WithMany(c => c.FlagAreaColors)
            .HasForeignKey(fa => fa.ColorId);

        builder
            .HasMany(fa => fa.Patterns)
            .WithOne(fp => fp.Area)
            .HasForeignKey(fa => fa.AreaId);
    }
}
