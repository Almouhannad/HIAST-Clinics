namespace Application.WaitingList.Queries;

public class GetAllWaitingListRecordsResponse
{
    public class GetAllWaitingListRecordsResponseItem
    {
        public int Id { get; set; }
        public int PatientId { get; set; }
        public string FullName { get; set; } = null!;
        public bool IsEmployee { get; set; }
        public DateTime ArrivalTime { get; set; }
    }

    public ICollection<GetAllWaitingListRecordsResponseItem> WaitingListRecords { get; set; } = null!;
}
