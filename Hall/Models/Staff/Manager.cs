using Kitchen.Interfaces;

namespace Hall.Models.Staff
{
	public class Manager : Employee
	{
		public Manager(OrderList list) : base(list)
		{

		}
		/// <summary>
		/// Accept the order.
		/// </summary>
		/// <param name="order">Order.</param>
		public void AcceptTheOrder(Order<IMeal> order)
		{
			orderList.Add(order);
		}
	}
}
