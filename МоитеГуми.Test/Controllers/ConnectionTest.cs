using MyTested.AspNetCore.Mvc;
using Xunit;
using МоитеГуми.Controllers;

namespace МоитеГуми.Test.Controllers
{
    public class Connectiontest
    {
        [Fact]
        public void CreateShouldReturnViewOnPost()
            => MyController<ConnectionController>
            .Instance()
            .Calling(c => c.Index())
            .ShouldReturn()
            .View();
    }
}
