namespace PanteraTech.EaiApp.Domain
{
    public class PagedListModel
    {
        public int Page { get; set; }

        public int PageSize { get; set; }

        public bool HasNextPage{ get; set; }

        public bool HasPreviousPage{ get; set; }

        public bool IsFirstPage { get; set; }

        public bool IsLastPage{ get; set; }

        public int PageNumber { get; set; }
    }
}
