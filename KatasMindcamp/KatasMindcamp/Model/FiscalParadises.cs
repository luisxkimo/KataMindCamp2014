using DesignByContract;
using System;

namespace KatasMindcamp
{
	public class FiscalParadises
	{
		private string name;
		private decimal tax;
		private decimal limitAmount;

		public static readonly FiscalParadises Lux = new Luxemburgo();
		public static readonly FiscalParadises Suiz = new Suiza();
		public static readonly FiscalParadises Baham = new Bahamas();

		protected FiscalParadises(string name, decimal tax, decimal limitAmount)
		{
			Check.Require(name != String.Empty);

			this.name = name;
			this.tax = tax;
			this.limitAmount = limitAmount;
		}

		public TaxesByCountryVM CalculateTaxes(decimal sumBlackMoney)
		{
			if (sumBlackMoney > limitAmount)
				return new TaxesByCountryVM(this.Name, sumBlackMoney * (Tax / 100));
			else
				return new TaxesByCountryVM(this.Name, 0);
		}
		public string Name { get { return name; } }
		public decimal Tax { get { return tax; } }

		private class Luxemburgo : FiscalParadises
		{
			public Luxemburgo() : base("Luxemburgo", 2m, 15) { }
		}

		private class Suiza : FiscalParadises
		{
			public Suiza() : base("Suiza", 1m, 10m) { }
		}

		private class Bahamas : FiscalParadises
		{
			public Bahamas() : base("Bahamas", 1.5m, 10m) { }
		}
	}


}
