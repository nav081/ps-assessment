namespace MedicineApi.Models
{
    public class Medicine
    {
        public int Id { get; set; }
        public required string FullName { get; set; }
        public string? Notes { get; set; }
        public DateTime ExpiryDate { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public required string Brand { get; set; }
    }
}