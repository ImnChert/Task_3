using Kitchen.Interfaces;
using Kitchen.Models.Foods;
using System;
using System.Linq;
using Warehouse;

namespace Hall.Models.Staff
{

	public class Chef : Employee
	{

		private CollectionIngredients _ingredients;

		public Chef(OrderList list, CollectionIngredients ingredients) : base(list)
		{
			_ingredients = ingredients;
		}

		/// <summary>
		/// Creating a dish.
		/// </summary>
		/// <param name="obj">Order.</param>
		/// <exception cref="Exception">There are no necessary ingredients.</exception>
		public void ProcessTheOrder(object? obj)
		{
			object locker = new object();

			lock (locker)
			{
				if (obj is Order<IMeal> order)
				{
					var thereAreAllIngredients = order.SelectedDishes.All(x =>
					{
						if (x is Food food)
							return CheckingTheAvailabilityOfIngredients(food) == true;
						return true;
					});

					if (!thereAreAllIngredients)
						throw new Exception();

					foreach (IMeal meal in order.SelectedDishes)
					{
						if (meal is Food food)
						{
							_ingredients = _ingredients - food.Ingredients;
							food.Create();
						}
					}
				}
			}
		}
		/// <summary>
		/// Checking available ingredients.
		/// </summary>
		/// <param name="food">Food.</param>
		/// <returns>Whether the ingredients are available.</returns>
		private bool CheckingTheAvailabilityOfIngredients(Food food)
		{
			foreach (var i in food.Ingredients.Dictionary)
			{
				if (_ingredients.FindCountOfIngredient(i.Key) <= 0)
				{
					return false;
				}
			}

			return true;
		}
	}
}
