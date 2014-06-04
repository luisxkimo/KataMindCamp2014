using DesignByContract;
using System;
using System.Collections.Generic;
using System.Linq;

namespace KatasMindcamp
{
	public class SaveBlackMoneyService : ISaveBlackMoneyService
	{
		public Dictionary<string, Dictionary<Expense, FiscalParadises>> data;

		public SaveBlackMoneyService()
		{
			data = new Dictionary<string, Dictionary<Expense, FiscalParadises>>();
		}

		public string SaveMyMoney(string nameDiputado, Expense tip, FiscalParadises paradise)
		{
			Check.Require(nameDiputado != String.Empty);
			Check.Require(tip != null);
			Check.Require(paradise != null);

			var blackMoneyDiputado = data.Where(x=> x.Key == nameDiputado);
			var coincidence = blackMoneyDiputado.Any(x => x.Value.Keys.Contains(tip));

			if(!coincidence)
			{
				var blackMoneyDictionary = new Dictionary<Expense, FiscalParadises>();
				blackMoneyDictionary.Add(tip, paradise);

				data.Add(nameDiputado, blackMoneyDictionary);

				return "Dieta " + tip + " guardada en " + paradise.Name;
			}
			else
			{
				return "Fail";
			}
		}

		public IEnumerable<Dictionary<Expense,FiscalParadises>> FindSaveMoneyByName(string name)
		{
			var saveMoneys = data.Where(x => x.Key == name);

			return saveMoneys.Select(x => x.Value);
		}
	}
}
