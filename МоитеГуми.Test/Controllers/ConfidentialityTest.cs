namespace МоитеГуми.Test.Controllers
{
    using MyTested.AspNetCore.Mvc;
    using Xunit;
    using МоитеГуми.Controllers;

    public class ConfidentialityTest
    {
        [Fact]
        public void CreateShouldReturnViewOnPost()
           => MyController<ConfidentialityController>
           .Instance()
           .Calling(c => c.Index())
           .ShouldReturn()
           .View();
    }
}
