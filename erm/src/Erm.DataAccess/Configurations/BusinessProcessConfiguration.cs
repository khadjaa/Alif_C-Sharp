namespace Erm.DataAccess;

public sealed BusinessProcessConfiguration : IEntityTypeConfiguration<BusinessProcess>
{
    public void Configure(EntityTypeBuilder<BusinessProcess> builder)
    {
        builder.ToTable("business_process");

        builder
        .Property(bp => bp.Id)
        .HasColumnName("id")
        .IsRequired();

        builder
        .Property(bp => bp.Name)
        .HasColumnName("name")
        .HasColumnType("VARCHAR(50)")
        .IsRequired();

        builder
        .Property(bp => bp.Domain)
        .HasColumnName("domain")
        .HasColumnType("VARCHAR(50)")
        .IsRequired();

        builder
        .HasMany(bp => bp.RiskProfiles)
        .WithOne(bp => bp.BusinessProcess)
        .HasForeignKey(fk => fk.BusinessProcessId)
        .IsRequired();

        builder.HasKey(k => k.Id);
    }
}