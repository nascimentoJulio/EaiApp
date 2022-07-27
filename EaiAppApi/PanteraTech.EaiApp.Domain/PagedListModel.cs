using System.Text.Json.Serialization;

namespace PanteraTech.EaiApp.Domain
{
    public class PagedListModel
    {
        [JsonIgnore]
        public int Page { get; set; }

        public int PageSize { get; set; }

        public bool HasNextPage{ get; set; }

        public bool HasPreviousPage{ get; set; }

        public bool IsFirstPage { get; set; }

        public bool IsLastPage{ get; set; }

        [JsonIgnore]
        public int PageNumber { get; set; }
    }
}
