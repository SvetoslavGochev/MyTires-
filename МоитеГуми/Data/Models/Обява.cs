namespace МоитеГуми.Data.Models
{
    using System.ComponentModel.DataAnnotations;
    using static МоитеГуми.Data.Models.DataConstatnt.Obqwa;
    public class Обява
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(carMax)]
        public string Marka { get; set; }

        

        [Required]
        public string Description { get; set; }

        [Required]
        public string Size { get; set; }

        [Required]
        public string ImageUrl { get; set; }

        public int Year { get; set; }

        public int CategoryId { get; set; }

        public Category Category { get; init; }

        public int DealerId { get; init; }

        public Dealer Dealer { get; init; }
    }
}
