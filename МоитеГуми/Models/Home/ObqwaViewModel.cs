namespace МоитеГуми.Models.Home
{
    using System.Collections.Generic;
    public class ObqwaViewModel
    {
        public int CountAnnouncement { get; init; }
        public int CountUsers { get; init; }

        public List<ObqwaIndexViewModel> obqwi { get; init; }
    }
}
