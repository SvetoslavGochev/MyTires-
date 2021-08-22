namespace МоитеГуми.Services.Obqwi
{
    public class LatestObqwaServiseModel : IObqwaModel
    {
        public int Id { get; set; }

        public string Marka { get; set; }

        public string Size { get; set; }

        public string Category { get; set; }

        public string ImageUrl { get; set; }

        public int Year { get; set; }
    }
}
