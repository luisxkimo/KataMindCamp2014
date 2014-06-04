using System;
using System.Collections.Generic;
namespace KatasMindcamp
{
	interface ISaveBlackMoneyService
	{
		IEnumerable<System.Collections.Generic.Dictionary<Expense, FiscalParadises>> 
			FindSaveMoneyByName(string name);
		string SaveMyMoney(string nameDiputado, Expense tip, FiscalParadises paradise);
	}
}
