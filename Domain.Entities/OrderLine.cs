namespace Domain.Entities
{
    public class OrderLine
    {
        public int Id { get; set; }
        public int OrderId { get; set; }
        public virtual Order Order { get; set; }
        public int ProductId { get; set; }
        public virtual Product Product { get; set; }
        public int Units { get; set; }
        public decimal Price { get; set; }
    }
}