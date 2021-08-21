namespace МоитеГуми.Services.Dealers
{
    using System.Linq;
    using МоитеГуми.Data;
    public class DealerServise : IDealerService
    {
        private readonly ApplicationDbContext data;

        public DealerServise(ApplicationDbContext data)
        {
            this.data = data;
        }

        public int IdByUser(string userId)
           => this.data
                .Dealers
                .Where(d => d.UserId == userId)
                .Select(d => d.Id)
                .FirstOrDefault();

        public bool IsDealer(string userId)
            => this.data
            .Dealers
            .Any(d => d.UserId == userId);

    }
}
