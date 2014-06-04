using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KatasMindcamp
{
	public class TaxesByCountryVM
	{
		public string Country { get; set; }
		public decimal Discount { get; set; }

		public TaxesByCountryVM(string country, decimal discount)
		{
			this.Country = country;
			this.Discount = discount;
		}

	}
}
