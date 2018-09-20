using System.Collections.Generic;

namespace TinySoldiers.Models
{
    public class Envelope<T> where T : class
    {
        public Envelope(IEnumerable<T> _items, int _pageSize, int _pageNumber, int _maxPages) {
            this.Items = _items;
            this.PageSize = _pageSize;
            this.PageNumber = _pageNumber;
            this.MaxPages = _maxPages;
        }

        public IEnumerable<T> Items { get; set; }
        public int PageSize { get; set; }
        public int PageNumber { get; set; }
        public int MaxPages { get; set; }
    }
}