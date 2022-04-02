namespace Hall.Models.Staff
{
	public abstract class Employee
	{
		protected OrderList orderList;

		protected Employee(OrderList orderList)
		{
			this.orderList = orderList;
		}
	}
}
