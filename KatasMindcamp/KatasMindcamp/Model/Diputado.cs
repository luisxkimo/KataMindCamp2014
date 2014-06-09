using System.Net;
using System;
using System.Collections.Generic;
using System.Linq;
using KatasMindcamp.libs;

namespace KatasMindcamp
{
    public class Diputado
    {
        private string name;
        private int salary;
        private string country;
        private string team;
        private List<Expense> _expenses;


        public Diputado(string name, string country, string team)
        {
            Check.Require(name != String.Empty);
            Check.Require(country != String.Empty);
            Check.Require(team != String.Empty);

            this.name = name;
            this.salary = 40;
            this.team = team;
            this.country = country;
            this._expenses = new List<Expense>();
            fiscalParadises = new List<FiscalParadise>();

        }

        public string Name { get { return name; } }
        public int Salary { get { return salary; } }
        public string Country { get { return country; } }
        public string Team { get { return team; } }
        public List<Expense> Expenses { get { return _expenses; } }
        public IList<FiscalParadise> fiscalParadises;

        public void ChangeSalary(int salary)
        {
            Check.Require(salary != null);
            this.salary = salary;
        }

        public void AddExpense(Expense expense)
        {
            Check.Require(expense != null);
            if (_expenses.Contains(expense))
                throw new ArgumentException("La dieta que intenta dar de alta ya la tiene adjudicada.");
            else
            {
                _expenses.Add(expense);
            }
        }

        public List<TaxesByCountryVM> GetDiscounts()
        {
            var sumDietas = _expenses.Sum(x => (int)x);
            List<TaxesByCountryVM> taxes = new List<TaxesByCountryVM>();

            var luxDiscount = FiscalParadise.Lux.CalculateTaxes(sumDietas);
            var bahamasDiscount = FiscalParadise.Baham.CalculateTaxes(sumDietas);
            var suizaDiscount = FiscalParadise.Suiz.CalculateTaxes(sumDietas);

            taxes.Add(luxDiscount);
            taxes.Add(bahamasDiscount);
            taxes.Add(suizaDiscount);

            return taxes;
        }

        public IEnumerable<FiscalParadise> GetFiscalParadises()
        {
            return fiscalParadises;
        }

        public void AddExpenseToFiscalParadise(Expense expense, FiscalParadise fiscalParadise)
        {
            Check.Require(_expenses.Contains(expense));

            if (!fiscalParadises.Contains(fiscalParadise))
            {
                fiscalParadises.Add(fiscalParadise);
                fiscalParadise.AddExpense(name, expense);
            }
            else
            {
                fiscalParadise.AddExpense(name, expense);
            }


        }
    }
}
