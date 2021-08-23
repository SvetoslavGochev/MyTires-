namespace МоитеГуми.Test.Controllers.Data
{
    using System.Collections.Generic;
    using System.Linq;
    using МоитеГуми.Data.Models;
    public static class Obqwi
    {
        public static IEnumerable<Обява> TenPublicAnnouncement()
         => Enumerable
             .Range(0, 10)
             .Select(i => new Обява
             {
                 IsPublic = true
             });
    }
}
