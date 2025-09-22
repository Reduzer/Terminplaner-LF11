using Shared;
using Microsoft.EntityFrameworkCore;

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

			modelBuilder.Entity<Termin>(entity => {
				entity.ToTable("Termine");

				entity.HasKey( e => e.nID);
				entity.Property( e => e.sName);
				entity.Property( e => e.oStartDate);
				entity.Property( e => e.oEndDate);
				entity.Property( e => e.sLocation);
				entity.Property( e => e.voParticipants);
				entity.Property( e => e.oColor);
				entity.Property( e => e.bIsRepeating);
				entity.Property( e => e.nRepititionInterval);
				entity.Property( e => e.sNameForRepitition);
			});

			modelBuilder.Entity<Participant>(entity => {
				entity.ToTable("Participants");

				entity.HasKey( e => e.nID);
				entity.Property( e => e.sName);
			});
		}

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) 
		{
			optionsBuilder.UseSqlite("Host=host.docker.internal,5432;Database=hotline_db;TrustServerCertificate = True;Username=admin;Password=password");
		}
	}
}
