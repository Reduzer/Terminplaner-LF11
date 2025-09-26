using Microsoft.EntityFrameworkCore;
using Shared;

namespace Datenbankanbindung
{
	public class TerminVerwalterContext : DbContext
	{
		public TerminVerwalterContext(DbContextOptions<TerminVerwalterContext> options) : base(options) { }

		public DbSet<Termin> Termine { get; set; }
		public DbSet<Participant> Participants { get; set; }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder);

			modelBuilder.Entity<Termin>(entity =>
			{
				entity.ToTable("Termine");

				entity.HasKey(e => e.nID);
				entity.Property(e => e.sName);
				entity.Property(e => e.sStartDate);
				entity.Property(e => e.sEndDate);
				entity.Property(e => e.sStartTime);
				entity.Property(e => e.sEndTime);
				entity.Property(e => e.sLocation);
				entity.Property(e => e.vnParticipants);
				entity.Property(e => e.bIsRepeating);
				entity.Property(e => e.nRepititionInterval);
				entity.Property(e => e.sNameForRepitition);
				entity.Property(e => e.sDescription);
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
