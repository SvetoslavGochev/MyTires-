namespace МоитеГуми.Models.Api
{
    using МоитеГуми.Models.Обява;
    public class AllObqwiApiRequestModel //dannite koito idvat se request
    {
        public string Marka { get; set; }// za dropdown na markite
        //towa e selektiranata Marka
        //tuka sa vsi4ki marki
        public string SearchTerm { get; set; }

        public string Size { get; set; }


        public ObqwiSorting Sorting { get; set; }

        public int CurrentPage { get; set; } = 1;

        public int ObqwiPerPage { get; init; } = 10;
    }
}
