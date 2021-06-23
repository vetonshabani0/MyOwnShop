using MyOwnShop.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyOwnShop.Core.ViewModels
{
	public class ProductManagerViewModel//Creating a dropdown list pf categories to choos from
	{
		public Product Product { get; set; }
		public IEnumerable<ProductCategory> ProductCategories { get; set; }

	}
}
