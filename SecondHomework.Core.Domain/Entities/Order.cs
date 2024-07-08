
using SecondHomework.Core.Domain.Core;
using System.Data.SqlTypes;

namespace SecondHomework.Core.Domain.Entities
{
	public class Order : BaseEntity<Guid>
	{

        public Order()
        {
            IsCompleted = false;
        }
        public Guid TableThatOrderIsFor { get; set; }
        public double SubAmount { get;  set; }
		public bool IsCompleted { get; set; }	

        public Table Table { get; set; }
        public IList<OrderDish> OrderDishes { get; set; }


	}
}
