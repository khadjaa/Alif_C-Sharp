namespace Erm.DataAccess;

public sealed RiskProfileConfiguration : IEntityTypeConfiguration<RiskProfile>
{
    public void Configure(EntityTypeBuilder<RiskProfile> builder)
    {
        builder.ToTable("risk_profile" );

        builder
        .Property(bp => bp.Id)
        .HasColumnName("id")
        .IsRequired();

        builder
        .Property(bp => bp.RiskName)
        .HasColumnName("risk_name")
        .HasColumnType("VARCHAR(50)")
        .IsRequired();

        builder
        .Property(bp => bp.Description)
        .HasColumnName("description")
        .HasColumnType("VARCHAR(50)")
        .IsRequired();

        builder
        .Property(bp => bp.OccurreceProbability)
        .HasColumnName("occurrece_probability")
        .HasColumnType("INTEGER")
        .IsRequired();

        builder
        .Property(bp => bp.PotentialBusinessImpact)
        .HasColumnName("potential_business_impact")
        .HasColumnType("INTEGER")
        .IsRequired();

        builder.Property(bp => bp.PotentialSolution)
        .HasColumnName("potential_solution")
        .HasColumnType("VARCHAR(100)")
        .IsRequired(false);

        builder
        .HasOne(bp => bp.BusinessProcess)
        .WithMany(bp => bp.RiskProfiles)
        .HasForeignKey(fk => fk.BusinessProcessId)
        .IsRequired();

        builder
        .Property(bp => bp.BusinessProcessId)
        .HasColumnName("business_process_id")

        builder.HasKey(k => k.Id);
    }
}