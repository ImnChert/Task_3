using Hall.Models;
using Hall.Models.Staff;
using Kitchen.Interfaces;
using System.Threading;
using Warehouse;

namespace Hall.Services
{
	public class Creator
	{
		private Manager _manager;
		private Chef _chef;
		private CollectionIngredients _ingedients;
		private Thread _myThread;

		public Creator(OrderList orderList, CollectionIngredients ingedients)
		{
			_ingedients = ingedients;
			_manager = new Manager(orderList);
			_chef = new Chef(orderList, _ingedients);
		}
		/// <summary>
		/// Create the order.
		/// </summary>
		/// <param name="order">Order.</param>
		/// <returns>Order.</returns>
		public Order<IMeal> CreateAnOrder(Order<IMeal> order)
		{
			_manager.AcceptTheOrder(order);
			_myThread = new Thread(new ParameterizedThreadStart(_chef.ProcessTheOrder));
			_myThread.Start(order);
			return order;
		}
	}
}
