namespace МоитеГуми.Test.Mocks
{
    using Microsoft.EntityFrameworkCore;
    using System;
    using МоитеГуми.Data;

    public static class DataBaseMock
    {
        public static ApplicationDbContext Instance
        {
            get
            {
                var dbContext = new DbContextOptionsBuilder<ApplicationDbContext>()
                    .UseInMemoryDatabase(Guid.NewGuid().ToString())
                    .Options;

                return new ApplicationDbContext(dbContext);

            }
        }
    }
}
