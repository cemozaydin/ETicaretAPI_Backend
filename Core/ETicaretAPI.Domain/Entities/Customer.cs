using ETicaretAPI.Domain.Common;

namespace ETicaretAPI.Domain.Entities
{
    public class Customer : BaseEntity
    {
        public string CustomerName { get; set; }
        public ICollection<Order> Orders { get; set; }
    }
}
