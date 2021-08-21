namespace МоитеГуми.Test.Services
{
    using Xunit;
    using МоитеГуми.Data.Models;
    using МоитеГуми.Services.Dealers;
    using МоитеГуми.Test.Mocks;

    public class DealerServeceTest
    {
        private const string UserId = "Id";

        [Fact]
        public void IsDealerShouldReturnTrueUserIsDealer()
        {
            var dealerServices = GetDealerService();

            var result = dealerServices.IsDealer(UserId);

            Assert.True(result);
        }
        [Fact]
        public void IsDealerShouldReturnFalseUserIsDealer()
        {
            var dealerServices = GetDealerService();

            var result = dealerServices.IsDealer("UserID");

            Assert.False(result);
        }

        private static IDealerService GetDealerService()
        {
            var data = DataBaseMock.Instance;

            data.Dealers.Add(new Dealer { UserId = UserId });
            data.SaveChanges();

            return new DealerServise(data); 
        }

    }
}
