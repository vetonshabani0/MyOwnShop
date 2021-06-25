﻿using MyOwnShop.Core.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyOwnShop.DataAccess.SQL
{
	public class DataContext: DbContext
	{
		public DataContext()
			: base("DefaultConnection")//connected to webconfig
		{

		}
		public DbSet<Product> Products { get; set; }
		public DbSet<ProductCategory> ProductCategories { get; set; }
		public DbSet<Basket> Baskets { get; set; }
		public DbSet<BasketItem> BasketItems { get; set; }


	}
}
