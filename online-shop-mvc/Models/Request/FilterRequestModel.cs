namespace online_shop_mvc.Models.Request
{
    public class FilterRequestModel : PagingRequestModel
    {
        public string NameSearch { get; set; }
        public decimal Price { get; set; }
        public int[] Size { get; set; }
        public int[] Color { get; set; }
    }
}
