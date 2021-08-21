namespace МоитеГуми.Test.Controllers
{
    using AutoMapper;
    using Microsoft.AspNetCore.Mvc;
    using Moq;
    using Xunit;
    using МоитеГуми.Controllers;
    using МоитеГуми.Test.Mocks;

    public class HomeControllerTest
    {

        [Fact]
        public void ErrorShouldReturnView()
        {
            //arange 
            var homewController = new HomeController(null,null,Mock.Of<IMapper>());
            //act
            var result = homewController.Error();
            //assert
            Assert.NotNull(result);
            Assert.IsType<ViewResult>(result);
        }

    }
}
