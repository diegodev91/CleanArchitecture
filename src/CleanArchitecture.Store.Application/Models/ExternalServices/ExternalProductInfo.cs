namespace CleanArchitecture.Store.Application.Models.ExternalServices
{
    public class ExternalProductInfo
    {
        public int Id { get; set; }
        public string InternationalName { get; set; }
        public string InternationalUrl { get; set; }
        public decimal InternationalPrice { get; set; }
        public string InternationalCurrency { get; set; }
    }
}   