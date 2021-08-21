namespace МоитеГуми.Data.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using static DataConstatnt.Category;

    public class Category
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(NameMaxLength)]
        public string Name { get; set; }

        public ICollection<Обява> Обяви { get; init; } = new List<Обява>();
    }
}
