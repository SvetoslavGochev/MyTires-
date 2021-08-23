namespace МоитеГуми.Test.Controllers
{
    using Xunit;
    using MyTested.AspNetCore.Mvc;
    using МоитеГуми.Controllers;
    using МоитеГуми.Models.Dealers;
    using МоитеГуми.Data.Models;
    using System.Linq;

    using static WebConstatnts;
    using МоитеГуми.Models.Обява;

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

        [Fact]
        public void CreateShoulBeForAutorizationUserAndReturnView()
         => MyMvc
            .Pipeline()
            .ShouldMap(request => request
            .WithPath("/Dealers/Create")
            .WithUser())
           .To<DealersController>(c => c.Create())
            .Which()
           .ShouldHave()
           .ActionAttributes(attributes => attributes
           .RestrictingForAuthorizedRequests())
           .AndAlso()
           .ShouldReturn()
           .View();

        [Fact]
        public void GetCreateShouldbeMaped()
           => MyRouting
            .Configuration()
            .ShouldMap("/Dealers/Create")
            .To<DealersController>(c => c.Create());

        [Fact]
        public void PostCreateShouldbeMaped()
           => MyRouting
            .Configuration()
            .ShouldMap(request => request
            .WithPath("/Dealers/Create")
            .WithMethod(HttpMethod.Post))
            .To<DealersController>(c => c.Create(With.Any<BecomeDealerFormModel>()));

        [Fact]
        public void CreateShouldReturnViewOnGet()
            => MyController<DealersController>
            .Instance()
            .Calling(c => c.Create())
            .ShouldHave()
            .ActionAttributes(a => a
                .RestrictingForAuthorizedRequests());

        [Fact]
        public void CreateShouldReturnViewOnPost()
            => MyController<DealersController>
            .Instance()
            .Calling(c => c.Create())
            .ShouldReturn()
            .View();
        //1
        [Theory]
        [InlineData("dealer", "1234567")]
        public void PostCreateShouldBeForAuthorizeduserAndReturnView(string dealerName,
            string phoneNumber)
            => MyController<DealersController>
            .Instance(c => c
            .WithUser())
            .Calling(c => c.Create(new BecomeDealerFormModel
            {
                Name = dealerName,
                PhoneNumber = phoneNumber
            }))
            .ShouldHave()
            .ActionAttributes(a => a
            .RestrictingForHttpMethod(HttpMethod.Post)
            .RestrictingForAuthorizedRequests())
            .ValidModelState()
            .Data(data => data.WithSet<Dealer>(dealer =>
            {
                dealer.Any(d =>
                d.Name == dealerName &&
                d.PhoneNumber == phoneNumber &&
                d.UserId == TestUser.Identifier);
            }))
            .TempData(tempData => tempData
            .ContainingEntryWithKey(GlobalMessageKey))
            .AndAlso()
            .ShouldReturn()
            .Redirect(r => r
            .To<ОбяваController>(c => c.All(With.Any<ObqwiSearchingModel>())));
              
        ///2
        ///
        //[Fact]
        //public void
    }
}
