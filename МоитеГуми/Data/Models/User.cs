namespace МоитеГуми.Data.Models
{
    using Microsoft.AspNetCore.Identity;
    using System.ComponentModel.DataAnnotations;
    using static МоитеГуми.Data.Models.DataConstatnt.User;
    public class User : IdentityUser
    {
        [MaxLength(FullNameMaxLength)]
        public string FullName { get; set; }     
    }
}
