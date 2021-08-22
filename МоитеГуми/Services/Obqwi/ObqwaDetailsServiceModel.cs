namespace МоитеГуми.Services.Obqwi
{
    public class ObqwaDetailsServiceModel : ObqwaServicesModel
    {
        public int DealerId { get; init; }

        public int CategoryId { get; init; }

        public string CategoryName { get; set; }

        public string DealerName { get; init; }

        public string UserId { get; init; }
    }
}
