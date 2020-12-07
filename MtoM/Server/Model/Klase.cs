using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MtoM.Server
{
	public class Artikal
	{
		public int ID { get; set; }
		public string Naziv { get; set; }

		public ICollection<Racun> Racuni { get; set; }
		public List<Racun_Artikal> RAs { get; set; }
	}

	public class Racun
	{
		public int RbR { get; set; }
		public DateTime DatumIzdavanja { get; set; }

		public ICollection<Artikal> Artikli { get; set; }
		public List<Racun_Artikal> RAs { get; set; }
	}

	public class Racun_Artikal
	{
		public int R_FK { get; set; }
		public Racun Racun { get; set; }

		public int A_FK { get; set; }
		public Artikal Artikal { get; set; }

		public int Kolicina { get; set; }
	}
}
