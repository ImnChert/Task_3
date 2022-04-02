using Hall.Models;
using Hall.Services;
using Kitchen.Interfaces;
using System;
using System.Collections.Generic;

namespace Hall
{
	public class Client
	{
		private int _id;

		public Client()
		{
			var rand = new Random();
			_id = rand.Next();
		}

		/// <summary>
		/// Ordering an order.
		/// </summary>
		/// <param name="selectedDishes">Ordered dishes.</param>
		/// <param name="creator">Creator.</param>
		/// <returns>Order.</returns>
		public Order<IMeal> ToOrder(List<IMeal> selectedDishes, Creator creator)
			=> creator.CreateAnOrder(new Order<IMeal>(selectedDishes, _id));
	}
}
