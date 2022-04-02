using Kitchen.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Hall.Models
{
	public class OrderList
	{
		public List<Order<IMeal>> ListOfOrders { get; set; }

		public OrderList()
		{
			ListOfOrders = new List<Order<IMeal>>();
		}

		/// <summary>
		/// Add the order in the ListOfOrder.
		/// </summary>
		/// <param name="order">Order.</param>
		public void Add(Order<IMeal> order)
		{
			ListOfOrders.Add(order);
		}
		/// <summary>
		/// Viewing orders for the specified period.
		/// </summary>
		/// <param name="start">From.</param>
		/// <param name="end">To.</param>
		/// <returns>List of order.</returns>
		public List<Order<IMeal>> ViewingOrdersForTheSpecifieldPeriod(DateTime start, DateTime end)
			=> (from item in ListOfOrders
				where item.StartOrder > start && item.StartOrder < end
				select item).ToList();
	}
}
