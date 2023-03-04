using Forum.Model.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Forum.Model
{
    public class PagedResult<TEntityModel> : IPagedResult<TEntityModel>
    {
        public IEnumerable<TEntityModel> Item { get; set; }
        public int RecordsPerPage { get; set; }
        public int Page { get; set; }
        public int TotalRecords { get; set; }
    }
}