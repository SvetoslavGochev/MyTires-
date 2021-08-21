namespace МоитеГуми.Models.Обява
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using static МоитеГуми.Data.Models.DataConstatnt.Obqwa;
    public class ObqwaModel
    {
        [Required]
        [StringLength(carMax, MinimumLength = SizeMinLength, ErrorMessage = "Maximum: {0} symbols")]
        public string Marka { get; set; }

        [Required]
        [StringLength(int.MaxValue, MinimumLength = SizeMinLength, ErrorMessage = "{0} трябжа да е с дълйина между: {2} {1} symbols")]
        public string Description { get; set; }

        [Required]
        [StringLength(int.MaxValue, MinimumLength = SizeMinLength, ErrorMessage = "Maximum: {0} symbols")]
        public string Size { get; set; }


        [Display(Name = "Image Url")]
        [Url]
        public string ImageUrl { get; set; }


        [Range(TireYearMinValue, TireYearMaxvalue)]
        public int Year { get; set; }

        [Display(Name = "Category")]
        public int CategoryId { get; set; }//uzera go pra6ta

        public IEnumerable<ObqwaCategoryServiceModel> Categories { get; set; }
    }
}
