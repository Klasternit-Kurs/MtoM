using Microsoft.EntityFrameworkCore;
using MtoM.Server;
using MtoM.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MtoM.Server
{
	public class DBcon : DbContext
	{
		public DBcon(DbContextOptions<DBcon> o) : base(o) { }

		public DbSet<Racun> Racuni { get; set; }
		public DbSet<Artikal> Artikli { get; set; }
		public DbSet<Racun_Artikal> RAs { get; set; }

		public DbSet<Nesto> Nestos { get; set; }

		public DbSet<Radnik> Radniks { get; set; }
		public DbSet<Tim> Tims { get; set; }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{

			modelBuilder.Entity<Radnik>().HasKey(r => r.ID);
			modelBuilder.Entity<Tim>().HasKey(t => t.ID);

			modelBuilder.Entity<Radnik>().HasOne(r => r.Tim)
										.WithMany(t => t.Radniks)
										.HasForeignKey(r => r.Tim_FK);

			modelBuilder.Entity<Racun>().HasKey(r => r.RbR);
			modelBuilder.Entity<Artikal>().HasKey(a => a.ID);

			modelBuilder.Entity<Nesto>().HasKey(n => n.ID);

			modelBuilder.Entity<Nesto>().Ignore(n => n.Vremena);

			modelBuilder.Entity<Racun>().HasMany(r => r.Artikli)
										.WithMany(a => a.Racuni)
										.UsingEntity<Racun_Artikal>
			(
				//Obavezno u istom redosledu kao gore HasMany pa WithMany
				ra => ra
						.HasOne(ra => ra.Artikal)
						.WithMany(a => a.RAs)
						.HasForeignKey(ra => ra.A_FK),
				ra => ra
						.HasOne(ra => ra.Racun)
						.WithMany(r => r.RAs)
						.HasForeignKey(ra => ra.R_FK),
				ra => ra
						.HasKey(ra => 
							new { ra.A_FK, ra.R_FK })
			);

			modelBuilder.Entity<Artikal>().HasData
				(
					new Artikal { ID = -1, Naziv = "Bla"},
					new Artikal { ID = -2, Naziv = "A2"},
					new Artikal { ID = -3, Naziv = "A3" }
				);
			modelBuilder.Entity<Racun>().HasData
				(
					new Racun { RbR = -1, DatumIzdavanja = DateTime.Now},
					new Racun { RbR = -2, DatumIzdavanja = DateTime.Now - new TimeSpan(7, 0, 0, 0) },
					new Racun { RbR = -3, DatumIzdavanja = DateTime.Now + new TimeSpan(4, 0, 0, 0) }
				);
			modelBuilder.Entity<Racun_Artikal>().HasData
				(
					new Racun_Artikal { R_FK = -1, A_FK = -2, Kolicina = 5 },
					new Racun_Artikal { R_FK = -2, A_FK = -1, Kolicina = 2 },
					new Racun_Artikal { R_FK = -2, A_FK = -3, Kolicina = 7 },
					new Racun_Artikal { R_FK = -3, A_FK = -1, Kolicina = 1 }
				);

			modelBuilder.Entity<Tim>().HasData
			(
				new Tim { ID = -1, Naziv = "A"}
			);

			modelBuilder.Entity<Radnik>().HasData
				(
					new Radnik { ID = -1, Naziv = "Pera", Tim_FK = -1},
					new Radnik { ID = -2, Naziv = "Neko", Tim_FK = -1}
				);
			
		}
	}
}
