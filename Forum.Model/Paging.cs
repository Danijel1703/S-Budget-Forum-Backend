using Forum.Model.Common;

namespace Forum.Model
{
    public class Paging : IPaging
    {
        private int _rpp = 10;
        private int _page = 1;
        public int RecordsPerPage { get { return _rpp; } set { _rpp = value; } }
        public int Page { get { return _page; } set { _page = value; } }
        public int TotalRecords { get; set; }

        public int Skip
        {
            get => _rpp * (_page - 1);
        }
    }
}