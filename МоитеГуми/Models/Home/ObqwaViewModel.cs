namespace МоитеГуми.Models.Home
{
    using System.Collections.Generic;
    using МоитеГуми.Services.Obqwi;

    public class ObqwaViewModel
    {
        public int CountAnnouncement { get; init; }
        public int CountUsers { get; init; }

        public IList<LatestObqwaServiseModel> obqwi { get; init; }
    }
}
