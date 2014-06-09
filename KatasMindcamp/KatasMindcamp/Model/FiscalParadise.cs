using System.Collections.Generic;
using System.Linq;
using System.Net;
using System;
using KatasMindcamp.libs;

namespace KatasMindcamp
{
    public class FiscalParadise
    {
        private string name;
        private decimal tax;
        private decimal limitAmount;

        private Dictionary<string, Expense> expensesForDiputado;

        public static readonly FiscalParadise Lux = new Luxemburgo();
        public static readonly FiscalParadise Suiz = new Suiza();
        public static readonly FiscalParadise Baham = new Bahamas();

        protected FiscalParadise(string name, decimal tax, decimal limitAmount)
        {
            Check.Require(name != String.Empty);

            this.name = name;
            this.tax = tax;
            this.limitAmount = limitAmount;
            expensesForDiputado = new Dictionary<string, Expense>();
        }
        public string Name { get { return name; } }
        public decimal Tax { get { return tax; } }

        public TaxesByCountryVM CalculateTaxes(decimal sumBlackMoney)
        {
            if (sumBlackMoney > limitAmount)
                return new TaxesByCountryVM(this.Name, sumBlackMoney * (Tax / 100));
            else
                return new TaxesByCountryVM(this.Name, 0);
        }

        public List<Expense> GetExpenses(string diputado)
        {
            return expensesForDiputado.Where(x => x.Key == diputado).Select(x => x.Value).ToList();
        }

        public void AddExpense(string diputado, Expense expense)
        {
            Expense z;

            if (expensesForDiputado.ContainsValue(expense))
                throw new ArgumentException("No es posible agregar esta dieta a este país porque ya esta agregada");
            if (expensesForDiputado.TryGetValue(diputado,out z) && expensesForDiputado[diputado] == expense)
                throw new ArgumentException("Este diputado ya ha almacenado la dieta especificada en este país.");
            else
                expensesForDiputado.Add(diputado, expense);
        }

        public void ClearExpenses()
        {
            expensesForDiputado.Clear();
        }

        private class Luxemburgo : FiscalParadise
        {
            public Luxemburgo() : base("Luxemburgo", 2m, 15) { }
        }

        private class Suiza : FiscalParadise
        {
            public Suiza() : base("Suiza", 1m, 10m) { }
        }

        private class Bahamas : FiscalParadise
        {
            public Bahamas() : base("Bahamas", 1.5m, 10m) { }
        }
    }


}
