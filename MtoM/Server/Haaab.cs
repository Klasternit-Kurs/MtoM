using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.Logging;
using MtoM.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace MtoM.Server
{
	public class Haaab : Hub
	{
		private DBcon _baza { get; init; }
		private ILogger<Haaab> _log;

		public Haaab(DBcon baza, ILogger<Haaab> log)
		{
			_baza = baza;
			_log = log;
		}
		public void Novi(Radnik r)
		{
			_baza.Radniks.Add(r);
			_baza.SaveChanges();
			Clients.Caller.SendAsync("rad", _baza.Radniks.Where(r => r.Tim == null).First()); 
		}
		public void DodajTim(Tim t)
		{
			List<Radnik> rad = new List<Radnik>();
			t.Radniks.ForEach(r => rad.Add(_baza.Radniks.Find(r.ID)));
			t.Radniks = rad;
			_baza.Add(t);
			_baza.SaveChanges();
		}
		public void Dodaj(Radnik r)
		{
			var tim = _baza.Tims.First();
			tim.Radniks.Add(r);
			_baza.SaveChanges();
		}
		public void DajSve()
		{
			_baza.Radniks.ToList();
			var t = _baza.Tims.ToList();
			_log.LogInformation($"Tim ima {t[0].Radniks.Count} radnika");


			/*var n = new Nesto();
			n.Vremena.Add(DateTime.Now);
			n.Vremena.Add(DateTime.Now + new TimeSpan(7, 0, 0, 0));
			n.Vremena.Add(DateTime.Now - new TimeSpan(7, 16, 15, 0));

			n.VremenaZaBazu = JsonSerializer.Serialize<List<DateTime>>(n.Vremena);
			_log.LogInformation(n.VremenaZaBazu);



			n.Vremena = JsonSerializer.Deserialize<List<DateTime>>(n.VremenaZaBazu);

			Dictionary<string, int[]> bla = new Dictionary<string, int[]>();
			int[] a = { 4, 5, 6, 7 };
			bla.Add("asd", a);
			int[] b = { 5, 6, 3 };
			bla.Add("qwe", b);

			string zklj = JsonSerializer.Serialize(bla);
			_log.LogInformation(zklj);

			_baza.Artikli.ToList();
			_baza.RAs.ToList();
			var rac = _baza.Racuni.ToList();

			var racZaKlijenta = new List<MtoM.Shared.Racun>();
			
			foreach(Racun r in rac)
			{
				var trenutniRacun = new Shared.Racun { Rbr = r.RbR, DatumIzdavanja = r.DatumIzdavanja };
				
				r.Artikli.ToList().ForEach(a => 
					{
						
					 });
				
				racZaKlijenta.Add(trenutniRacun);
			}

			foreach (var r in racZaKlijenta)
			{
				_log.LogInformation($"{r.Rbr} -- {r.DatumIzdavanja}");
				_log.LogInformation("-----------------------------");
				
			}

			Clients.Caller.SendAsync("evo", racZaKlijenta[0]);*/
		}
	}
}
