namespace МоитеГуми.Test.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using System.Linq;
    using Xunit;
    using МоитеГуми.Controllers;
    using МоитеГуми.Data.Models;
    using МоитеГуми.Models.Home;
    using МоитеГуми.Services.Obqwi;
    using МоитеГуми.Services.Statistics;
    using МоитеГуми.Test.Mocks;
    using MyTested.AspNetCore.Mvc;
    using System.Collections;
    using System.Collections.Generic;
    using FluentAssertions;

    public class HomeControllerTest
    {
        [Fact]
        public void IndexShouldReturnViewWithCorrectModelAndData()
        => MyMvc
            .Pipeline()
            .ShouldMap("/")
            .To<HomeController>(C => C.Index())
            .Which(controller => controller
            .WithData(GetAnnouncement())       
            .ShouldReturn()
            .View(view => view
            .WithModelOfType<ObqwaViewModel>()
            .Passing(m => m.obqwi.Should().HaveCount(0))));
            

        [Fact]
        public void IndexShouldReturnViewWithCorectModel()
        {
            var data = DataBaseMock.Instance;
            var mapper = MapperMock.Instance;

            var announcement = Enumerable.Range(0, 10).Select(i => new Обява());

            data.Обяви.AddRange(announcement);
            data.Users.Add(new User());

            data.SaveChanges();


            var obqwaServise = new ObqwaService(data, mapper);

            var statisticServise = new StatisticsService(data);

            var homeController = new HomeController(statisticServise, obqwaServise);

            var result = homeController.Index();

            Assert.NotNull(result);

           var viewResult = Assert.IsType<ViewResult>(result);


            var model = viewResult.Model;

           var indexViewModel = Assert.IsType<ObqwaViewModel>(model);

            Assert.Equal(1, indexViewModel.CountUsers);
            Assert.Equal(10, indexViewModel.CountAnnouncement);
        }


        [Fact]
        public void ErrorShouldReturnView()
        {
            //arange 
            var homewController = new HomeController(
                null,
                null);
            //act
            var result = homewController.Error();
            //assert
            Assert.NotNull(result);
            Assert.IsType<ViewResult>(result);
        }

        private static IEnumerable<Обява> GetAnnouncement()
            => Enumerable
                .Range(0, 10)
                .Select(i => new Обява());

    }
}
