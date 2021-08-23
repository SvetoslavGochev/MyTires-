namespace МоитеГуми.Services.Obqwi
{
    using System.Collections.Generic;
    using МоитеГуми.Data.Models;
    using МоитеГуми.Models.Обява;
    public interface IObqwiServices
    {
        Обява Info(int Id);

        void DeleteAnoncment(int Id);

        ObqwaQueryServicesModel All(
            string marka = null,
            string searchTerm = null,
            ObqwiSorting obqwiSorting = ObqwiSorting.DateCreated,
            int currentPage = 1,
            int obqwiPerPage = int.MaxValue,
            bool publicOnly = true);

        IEnumerable<LatestObqwaServiseModel> Latest();


        ObqwaDetailsServiceModel Details(int obqwaId);


        int Create(
                string marka,
                string description,
                int year,
                int categoryId,
                string imageUrl,
                string size,
                int dealerId);
        bool Edit(
                int obqwaId,
                string marka,
                string description,
                int year,
                int categoryId,
                string imageUrl,
                string size,
                bool isPublic);

        IEnumerable<ObqwaServicesModel> ByUser(string userId);

        bool IsByDealer(int obqwaId, int dealerId);

        void ChangeVisibility(int obqwaId);

        IEnumerable<string> AllMarki();

        IEnumerable<ObqwaCategoryServiceModel> AllCategories();

        bool CategoryExist(int categoryId);



    }
}
