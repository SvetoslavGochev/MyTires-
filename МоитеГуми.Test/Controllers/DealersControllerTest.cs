namespace МоитеГуми.Test.Controllers
{
    using Xunit;
    using MyTested.AspNetCore.Mvc;
    using МоитеГуми.Controllers;
    using МоитеГуми.Models.Dealers;

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


    }
}
