using Kitchen.Interfaces;
using System;
using System.Collections.Generic;

namespace Hall.Models
{
	public class Order<T> where T : IMeal
	{
		public int Number { get; set; }
		public DateTime StartOrder { get; }
		public List<T> SelectedDishes { get; }

		public Order(List<T> selectedDishes, int id)
		{
			SelectedDishes = selectedDishes;
			Number = id;
			StartOrder = DateTime.Now;
		}
	}
}
