namespace МоитеГуми.Data.Models
{
    using static DataConstatnt.Connection;
    public class Connection
    {
        public int Id { get; init; }

        public string connection = ConnectionString;
    }
}
