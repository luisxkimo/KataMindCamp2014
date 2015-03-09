using System.Linq;

namespace KatasMindcamp.Services
{
    public class TaxesCalculatorService
    {
	    public decimal CalculateTaxes(FiscalParadiseBase fiscalParadise, decimal quantity)
        {
			return quantity > fiscalParadise.LimitAmount ? quantity * (fiscalParadise.Tax / 100) : 0;
        }


		public decimal CalculateTaxesInCountryByDiputado(Diputado diputado, FiscalParadiseBase fiscalParadise)
		{
			var salaryAndExpense = diputado.Expenses.Sum(x => (int)x);
			var discounts = CalculateTaxes(fiscalParadise, salaryAndExpense);
			return discounts;
		}
    }
}
