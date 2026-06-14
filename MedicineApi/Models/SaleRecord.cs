namespace MedicineApi.Models
{
    public class SaleRecord
    {
        public int Id { get; set; }
        public required string MedicineName { get; set; }
        public int QuantitySold { get; set; }
        public decimal Price { get; set; }
        public DateTime SoldOn { get; set; }
    }
}