namespace МоитеГуми.Services.Obqwi
{
    using AutoMapper;
    using AutoMapper.QueryableExtensions;
    using System.Collections.Generic;
    using System.Linq;
    using МоитеГуми.Data;
    using МоитеГуми.Data.Models;
    using МоитеГуми.Models.Обява;

    public class ObqwaService : IObqwiServices
    {
        private readonly ApplicationDbContext data;
        private readonly IMapper mapper;

        public ObqwaService(ApplicationDbContext data, IMapper mapper)
        {
            this.data = data;
            this.mapper = mapper;
        }

        public ObqwaQueryServicesModel All(
             string marka = null,
            string searchTerm = null,
            ObqwiSorting obqwiSorting = ObqwiSorting.DateCreated,
            int currentPage = 1,
            int obqwiPerPage = int.MaxValue,
            bool publicOnly = true)
        {
            var obqwaQuery = this.data.Обяви
                .Where(o => !publicOnly || o.IsPublic);

            if (!string.IsNullOrWhiteSpace(marka))
            {
                obqwaQuery = obqwaQuery.Where(o => o.Marka == marka);
            }

            if (!string.IsNullOrWhiteSpace(searchTerm))
            {
                obqwaQuery = obqwaQuery
                    .Where(o =>
                    o.Marka.ToLower().Contains(searchTerm.ToLower()) ||
                    o.Size.ToLower().Contains(searchTerm.ToLower()) ||
                    o.Description.ToLower().Contains(searchTerm.ToLower()));
            }

            obqwaQuery = obqwiSorting switch
            {
                ObqwiSorting.DateCreated => obqwaQuery.OrderByDescending(o => o.Id),
                ObqwiSorting.Year => obqwaQuery.OrderByDescending(o => o.Year),
                ObqwiSorting.Marka => obqwaQuery.OrderBy(o => o.Marka).ThenBy(o => o.Size),
                _ => obqwaQuery.OrderByDescending(o => o.Id)

            };

            var CountObqwi = obqwaQuery.Count();

            var obqwi = GetObqwi(obqwaQuery
                .Skip((currentPage - 1) * obqwiPerPage)
                .Take(obqwiPerPage)
               );

            return new ObqwaQueryServicesModel
            {
                CountObqwi = CountObqwi,
                CurrentPage = currentPage,
                ObqwiPerPage = obqwiPerPage,
                Obqwa = obqwi
            };
        }

        public IEnumerable<string> AllMarki()
         => this.data.Обяви
               .Select(o => o.Marka)
                .Distinct()
                .OrderBy(x => x)
                .ToList();// samo unikalnite vzima

        public IEnumerable<ObqwaServicesModel> ByUser(string userId)
          => this.GetObqwi(this.data
              .Обяви
              .Where(o => o.Dealer.UserId == userId));


        private IEnumerable<ObqwaServicesModel> GetObqwi(IQueryable<Обява> obqwaQuery)
        => obqwaQuery
            .ProjectTo<ObqwaServicesModel>(this.mapper.ConfigurationProvider)
               .ToList();

        public IEnumerable<ObqwaCategoryServiceModel> AllCategories()
            => this.data
            .Categories
            .ProjectTo<ObqwaCategoryServiceModel>(this.mapper.ConfigurationProvider)
            .ToList();
        public ObqwaDetailsServiceModel Details(int obqwaId)
             => this.data
                .Обяви
                .Where(o => o.Id == obqwaId)
                .ProjectTo<ObqwaDetailsServiceModel>(this.mapper.ConfigurationProvider)
                .FirstOrDefault();

        public bool CategoryExist(int categoryId)
            => this.data.Categories.Any(c => c.Id == categoryId);

        public int Create(string marka, string description, int year, int categoryId, string imageUrl, string size, int dealerId)
        {
            var obqvaData = new Обява
            {
                Marka = marka,
                Description = description,
                Year = year,
                CategoryId = categoryId,
                ImageUrl = imageUrl,
                Size = size,
                DealerId = dealerId,
                IsPublic = false
            };

            this.data.Обяви.Add(obqvaData);
            this.data.SaveChanges();

            return obqvaData.Id;
        }

        public bool Edit(
            int obqwaId,
            string marka,
            string description,
            int year,
            int categoryId,
            string imageUrl,
            string size,
            bool isPublic)
        {
            var obqvaData = this.data.Обяви.Find(obqwaId);

            if (obqvaData == null)
            {
                return false;
            }

            obqvaData.Marka = marka;
            obqvaData.Description = description;
            obqvaData.Year = year;
            obqvaData.CategoryId = categoryId;
            obqvaData.ImageUrl = imageUrl;
            obqvaData.Size = size;
            obqvaData.IsPublic = isPublic;

            this.data.SaveChanges();

            return true;
        }

        public bool IsByDealer(int obqwaId, int dealerId)
        => this.data
            .Обяви
            .Any(o => o.Id == obqwaId && o.DealerId == dealerId);

        public void DeleteAnoncment(int Id)
        {
            var deleteObqwa = this.data
                  .Обяви
                  .Where(o => o.Id == Id)
                  .FirstOrDefault();

            this.data.Remove(deleteObqwa);
            this.data.SaveChanges();
        }

        public Обява Info(int Id)
        {
            var obqvaData = this.data.Обяви.Find(Id);


            return obqvaData;
        }

        public IEnumerable<LatestObqwaServiseModel> Latest()
        => this.data
              .Обяви
              .Where(o => o.IsPublic)
              .OrderByDescending(c => c.Id)
              .ProjectTo<LatestObqwaServiseModel>(this.mapper.ConfigurationProvider)
              .Take(3)
              .ToList();

        public void ChangeVisibility(int obqwaId)
        {
            var obqwa = this.data.Обяви.Find(obqwaId);

            obqwa.IsPublic = !obqwa.IsPublic;

            this.data.SaveChanges();
        }
    }
}
