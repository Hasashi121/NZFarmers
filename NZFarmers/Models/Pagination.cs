using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace NZFarmers
{
    // This class provides all the info needed for paginated results in the view
    public class PaginatedList<T> : List<T>
    {
        // Current page index (starts from 1, not 0)
        public int PageIndex { get; private set; }

        // Total number of pages available
        public int TotalPages { get; private set; }

        // Extra info: total item count (optional but useful)
        public int TotalCount { get; private set; }
        public int PageSize { get; private set; } 

        // Constructor: receives items to display, count, current page, and page size
        public PaginatedList(List<T> items, int count, int pageIndex, int pageSize)
        {
            PageIndex = pageIndex;
            TotalCount = count;
            PageSize = pageSize;
            TotalPages = (int)Math.Ceiling(count / (double)pageSize);

            this.AddRange(items);
        }

        // Returns true if there’s a previous page available
        public bool HasPreviousPage
        {
            get { return PageIndex > 1; }
        }

        // Returns true if there’s a next page available
        public bool HasNextPage
        {
            get { return PageIndex < TotalPages; }
        }

        // Factory method to create a paginated list from any IQueryable
        public static async Task<PaginatedList<T>> CreateAsync(IQueryable<T> source, int pageIndex, int pageSize)
        {
            // Gets the total number of items in the data set
            var count = await source.CountAsync();
            // Skips items for previous pages, takes only what we need for this page
            var items = await source.Skip((pageIndex - 1) * pageSize).Take(pageSize).ToListAsync();
            // Returns a new PaginatedList with only this page’s items and metadata
            return new PaginatedList<T>(items, count, pageIndex, pageSize);
        }
    }
}
