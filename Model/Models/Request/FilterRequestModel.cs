namespace online_shop_mvc.Models.Request
{
    public class FilterRequestModel : PagingRequestModel
    {
        public string? NameSearch { get; set; }
        public IList<decimal>? Price { get; set; }
        public IList<string>? Size { get; set; }
        public IList<string>? Color { get; set; }
    }
}
