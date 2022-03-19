using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static CarShop.Data.DataConstants;

namespace CarShop.Data.Model
{
    public class Car
    {
        public Car()
        {
            Issues = new List<Issue>();
        }

        [Key]
        [Required]
        [MaxLength(IdMaxLength)]
        public string Id { get; set; } = Guid.NewGuid().ToString();

        [Required]
        [MaxLength(ModelNameMaxLength)]
        public string Model { get; set; }

        public int Year { get; set; }

        [Required]
        [MaxLength(PictureUrlMaxLength)]
        public string PictureUrl { get; set; }

        [Required]
        [MaxLength(PlateNumberLength)]
        public string PlateNumber { get; set; }

        [Required]
        [MaxLength(IdMaxLength)]
        [ForeignKey(nameof(Owner))]
        public string OwnerId { get; set; }
        public User Owner { get; set; }

        public ICollection<Issue> Issues { get; set; }
    }
}
