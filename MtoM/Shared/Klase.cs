using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MtoM.Shared
{
	public class Radnik
	{
		public int ID { get; set; }
		public string Naziv { get; set; }

		public Tim Tim { get; set; }
		public int? Tim_FK { get; set; }
	}

	public class Tim
	{
		public int ID { get; set; }
		public List<Radnik> Radniks { get; set; } = new List<Radnik>();
		public string Naziv { get; set; }
	}


	public class Nesto
	{
		public int ID { get; set; }
		public string Naziv { get; set; }

		public List<DateTime> Vremena { get; set; } = new List<DateTime>();
		public string VremenaZaBazu { get; set; }
	}

	public class Racun
	{
		public int Rbr { get; set; }
		public DateTime DatumIzdavanja { get; set; }
		public Dictionary<Artikal, int> Artikli = new Dictionary<Artikal, int>();
	
	}

	public class Artikal
	{
		public int ID { get; set; }
		public string Naziv { get; set; }
		
	}
}
