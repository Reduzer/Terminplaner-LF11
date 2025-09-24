using Microsoft.EntityFrameworkCore;
using Shared;

namespace Datenbankanbindung
{
	public class TerminVerwalterContext : DbContext
	{
		public TerminVerwalterContext(DbContextOptions<TerminVerwalterContext> options) : base(options) { }

		public DbSet<Termin> Termine => Set<Termin>();
		public DbSet<Participant> Participants => Set<Participant>();

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder);

			modelBuilder.Entity<Termin>(entity =>
			{
				entity.ToTable("Termine");

				entity.HasKey(e => e.nID);
				entity.Property(e => e.sName);
				entity.Property(e => e.oStartDate);
				entity.Property(e => e.oEndDate);
				entity.Property(e => e.sLocation);
				entity.Property(e => e.voParticipants);
				entity.Property(e => e.oColor);
				entity.Property(e => e.bIsRepeating);
				entity.Property(e => e.nRepititionInterval);
				entity.Property(e => e.sNameForRepitition);
			});

			modelBuilder.Entity<Participant>(entity =>
			{
				entity.ToTable("Participants");

				entity.HasKey(e => e.nID);
				entity.Property(e => e.sName);
			});
		}
	}
}
