namespace МоитеГуми.Models.Dealers
{
    using System.ComponentModel.DataAnnotations;
    using static Data.Models.DataConstatnt.Dealer;
    public class BecomeDealerFormModel
    {
       
        [Required]
        [StringLength(NameMaxLength, MinimumLength = NameMinLength)]
        public string Name { get; set; }

        [Required]
        [StringLength(PhoneMaxLength, MinimumLength = PhoneMinLength)]
        [Display(Name ="Telefonen nomer")]
        public string PhoneNumber { get; set; }

    }
}
