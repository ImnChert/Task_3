using Kitchen.Interfaces;
using System;
using Warehouse.Interfaces;

namespace Kitchen.Models.Drinks
{
	public abstract class Drink : IMeal
	{
		public string Title { get; set; }
		public StorageMethod StorMethod { get; set; }
		public int Price { get; set; }

		public Drink(string title, int temperature, int price)
		{
			Title = title;
			StorMethod = new StorageMethod(temperature);
			Price = price;
		}

		public override bool Equals(object obj)
		{
			return obj is Drink drink &&
				   Title == drink.Title;
		}

		public override int GetHashCode()
		{
			return HashCode.Combine(Title);
		}
	}
}
