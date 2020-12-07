using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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

		public void DajSve()
		{
			_baza.Artikli.ToList();
			_baza.RAs.ToList();
			var rac = _baza.Racuni.ToList();

			var racZaKlijenta = new List<MtoM.Shared.Racun>();
			
			foreach(Racun r in rac)
			{
				var trenutniRacun = new Shared.Racun { Rbr = r.RbR, DatumIzdavanja = r.DatumIzdavanja };
				
				r.Artikli.ToList().ForEach(a => 
					{
						trenutniRacun.Artikals.Add
								(new MtoM.Shared.Artikal { ID = a.ID, Naziv = a.Naziv });
						trenutniRacun.Kolicine.Add(_baza.RAs.Find(a.ID, r.RbR).Kolicina);
					 });
				
				racZaKlijenta.Add(trenutniRacun);
			}

			foreach (var r in racZaKlijenta)
			{
				_log.LogInformation($"{r.Rbr} -- {r.DatumIzdavanja}");
				_log.LogInformation("-----------------------------");
				r.Artikals.ForEach(a => 
					_log.LogInformation($"{a.ID} -- {a.Naziv}"));
				r.Kolicine.ForEach(k =>
					_log.LogInformation($"Kolicina: {k}"));
			}

			Clients.Caller.SendAsync("evo", racZaKlijenta[0]);
		}
	}
}
