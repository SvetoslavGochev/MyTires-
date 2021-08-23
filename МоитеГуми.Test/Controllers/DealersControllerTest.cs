namespace МоитеГуми.Test.Controllers
{
    using Xunit;
    using MyTested.AspNetCore.Mvc;
    using МоитеГуми.Controllers;

    public class DealersControllerTest
    {  
        [Fact]
        public void ControllerTest()
          => MyController<DealersController>
            .Instance()
            .Calling(c => c.Create())
            .ShouldHave()
            .ActionAttributes(a => a
            .RestrictingForAuthorizedRequests())
            .AndAlso()
            .ShouldReturn()
            .View();

        [Fact]
        public void RouteTest()
            => MyRouting
            .Configuration()
            .ShouldMap("/Dealers/Create")
            .To<DealersController>(c => c.Create());

    }
}
