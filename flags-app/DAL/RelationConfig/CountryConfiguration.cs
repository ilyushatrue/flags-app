using DAL.Models.Flags.Attributes;
using DAL.Models.Flags;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using DAL.Models;

namespace DAL.RelationConfig;

internal class CountryConfiguration : IEntityTypeConfiguration<Country>
{
    public void Configure(EntityTypeBuilder<Country> builder)
    {
        builder
            .HasOne(c => c.Flag)
            .WithOne(f => f.Country)
            .HasForeignKey<Flag>(f => f.CountryId);
    }
}