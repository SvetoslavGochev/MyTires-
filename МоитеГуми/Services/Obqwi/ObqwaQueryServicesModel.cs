using System.Collections.Generic;

namespace МоитеГуми.Services.Obqwi
{
    public class ObqwaQueryServicesModel
    {
        public int CurrentPage { get; set; }

        public int CountObqwi { get; set; }

        public int ObqwiPerPage { get; set; }


        public IEnumerable<ObqwaServicesModel> Obqwa { get; init; }
    }
}
