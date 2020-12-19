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
		
		public void UnosRac(Racun r, string artikli, string kolicine)
		{
			List<Artikal> art = JsonSerializer.Deserialize<List<Artikal>>(artikli);
			List<int> kol = JsonSerializer.Deserialize<List<int>>(kolicine);

			_baza.Racuni.Add(r);
			r.ArtikliZaBazu = JsonSerializer.Serialize(art);
			r.Kolicine = JsonSerializer.Serialize(kol);
			_baza.SaveChanges();
		}

		public void PosaljiRac()
		{
			Clients.Caller.SendAsync("Evo", _baza.Racuni.OrderBy(r => r.Rbr).Last());
		}

		public void Proveri(int s)
		{
			var art = _baza.Artikli.Find(s);
			if (art is not null)
				Clients.Caller.SendAsync("DodajArt", true, art);
			else
				Clients.Caller.SendAsync("DodajArt", false, null);
		}
	}
}
