using Forum.Model;
using Forum.Model.Common;

namespace Forum.Service.Helpers
{
    public static class PagedListHelper<T>
    {
        public static IPagedResult<T> ToPagedList(IEnumerable<T> results, IPaging paging, int totalRecords)
        {
            IPagedResult<T> pagedResult = new PagedResult<T>();
            pagedResult.Item = results;
            pagedResult.Page = paging.Page;
            pagedResult.TotalRecords = totalRecords;
            pagedResult.RecordsPerPage = paging.RecordsPerPage;
            return pagedResult;
        }
    }
}