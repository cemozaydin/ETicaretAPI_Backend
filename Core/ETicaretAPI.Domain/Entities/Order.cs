using ETicaretAPI.Domain.Common;

namespace ETicaretAPI.Domain.Entities
{
    public class Order : BaseEntity
    {
        public int CustomerId { get; set; }
        public string Description { get; set; }
        public string Address { get; set; }

        public Customer Customer { get; set; }
        public ICollection<Product> Products { get; set; }

        // Bir order'ın birden fazla product ı olduğunu ifade ediyor.Aynı işlemmi Product üzerinde de yapınca N-N bir ilişki kurmuş oluyoruz.

    }
}
