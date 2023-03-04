namespace Forum.Model.Common
{
    public interface IPaging
    {
        int RecordsPerPage { get; set; }
        int Page { get; set; }
        int TotalRecords { get; set; }
        int Skip { get; }
    }
}