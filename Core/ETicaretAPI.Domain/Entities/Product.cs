using ETicaretAPI.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretAPI.Domain.Entities
{
    public class Product : BaseEntity
    {
        public string Name { get; set; }
        public int Stock { get; set; }
        public float Price { get; set; }
        public DateTime CreatedDate { get; set; }

        public ICollection<Order>? Orders { get; set; } 
        
        //Her product'ın birden fazla Order'ı oluyor. Aynı işlemmi Order üzerinde de yapınca N-N bir ilişki kurmuş oluyoruz.
    }
}
