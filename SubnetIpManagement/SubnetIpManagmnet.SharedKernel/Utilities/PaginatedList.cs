
using Microsoft.EntityFrameworkCore;

namespace SubnetIpManagement.SharedKernel.Utilities
{
    public class PaginatedList<T>(List<T> items, int totalCount, int currentPage, int pageSize)
    {
        public List<T> Items { get; private set; } = items;
        public int TotalCount { get; private set; } = totalCount;
        public int PageSize { get; private set; } = pageSize;
        public int CurrentPage { get; private set; } = currentPage;
        public int TotalPages => (int)Math.Ceiling(TotalCount / (double)PageSize);
        public bool HasPreviousPage => CurrentPage > 1;
        public bool HasNextPage => CurrentPage < TotalPages;

        public static async Task<PaginatedList<T>> CreateAsync(IQueryable<T> source, int pageNumber, int pageSize)
        {
            var totalCount = await source.CountAsync();
            var items = await source.Skip((pageNumber - 1) * pageSize).Take(pageSize).ToListAsync();
            return new PaginatedList<T>(items, totalCount, pageNumber, pageSize);
        }
    }
}
