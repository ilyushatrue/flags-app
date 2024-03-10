using DAL.Models.Flags;
using DAL.Models.Flags.Attributes;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DAL.Relations.Flags;

internal class FlagConfiguration : IEntityTypeConfiguration<Flag>
{
    public void Configure(EntityTypeBuilder<Flag> builder)
    {
        builder
            .HasOne(f => f.Country)
            .WithOne(c => c.Flag)
            .HasForeignKey<Flag>(f => f.CountryId);

        builder
            .HasOne(f => f.Area)
            .WithOne(c => c.Flag)
            .HasForeignKey<FlagArea>(f => f.FlagId);
    }
}
