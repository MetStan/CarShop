using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static CarShop.Data.DataConstants;

namespace CarShop.Data.Model
{
    public class Issue
    {
        [Key]
        [Required]
        [MaxLength(IdMaxLength)]
        public string Id { get; set; } = Guid.NewGuid().ToString();

        [Required]
        [MaxLength(DescriptionMaxLength)]
        public string Description { get; set; }

        public bool IsFixed { get; set; } = false;

        [Required]
        [MaxLength(IdMaxLength)]
        [ForeignKey(nameof(Car))]
        public string CarId { get; set; }
        public Car Car { get; set; }
    }
}
