namespace online_shop_mvc.Models.Request
{
    public class PagingRequestModel
    {
        public int PageIndex { get; set; }
        public int PageSize { get; set; } = 5;
    }
}
