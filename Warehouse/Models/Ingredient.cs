using System;
using System.Collections.Generic;
using Warehouse.Interfaces;

namespace Warehouse.Models
{
	public abstract class Ingredient
	{
		public string Name { get; set; }
		public StorageMethod StorMethod { get; set; }
		public int Price { get; set; }

		protected Ingredient(string name, int temperature, int price)
		{
			Name = name;
			StorMethod = new StorageMethod(temperature);
			Price = price;
		}

		public override bool Equals(object obj)
		{
			return obj is Ingredient ingredient &&
				   Name == ingredient.Name;
		}

		public override int GetHashCode()
		{
			return HashCode.Combine(Name);
		}


	}
}
