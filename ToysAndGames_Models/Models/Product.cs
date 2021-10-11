using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToysAndGames_Models.Models
{
    public class Product
    {
        [Key]
        public int Product_Id { get; set; }
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }
        [MaxLength(100)]
        public string Description { get; set; }
        [Range(0,100)]
        public int AgeRestriction { get; set; }
        [Required]
        [MaxLength(50)]
        public string Company { get; set; }
        [Required]
        [Range(1,1000)]
        [Column(TypeName = "Money")]
        public decimal Price { get; set; }
    }

    public class Product1
    {
        [Key]
        public int product_Id { get; set; }
        [Required]
        [MaxLength(50)]
        public string name { get; set; }
        [MaxLength(100)]
        public string description { get; set; }
        [Range(0, 100)]
        public int ageRestriction { get; set; }
        [Required]
        [MaxLength(50)]
        public string company { get; set; }
        [Required]
        [Range(1, 1000)]
        [Column(TypeName = "Money")]
        public decimal price { get; set; }
    }
}
