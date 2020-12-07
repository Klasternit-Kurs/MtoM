using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MtoM.Shared
{
	public class Racun
	{
		public int Rbr { get; set; }
		public DateTime DatumIzdavanja { get; set; }
		public Dictionary<Artikal, int> Artikli = new Dictionary<Artikal, int>();
		public List<Artikal> Artikals = new List<Artikal>();
		public List<int> Kolicine = new List<int>();
	}

	public class Artikal
	{
		public int ID { get; set; }
		public string Naziv { get; set; }
		
	}
}
