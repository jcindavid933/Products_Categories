using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace products_categories.Models
{
    public class Product
    {
        [Key]
        public int ProductId{get;set;}
        [Required]
        [MinLength(2)]
        public string Name { get; set; }
        [Required]
        public string Description {get;set;}
        [Required]
        [Range(0.0,int.MaxValue)]
        public decimal Price {get;set;}
        public DateTime created_at {get;set;} = DateTime.Now;
        public DateTime updated_at {get;set;} = DateTime.Now;
        public List<Associations> Associations {get;set;}
        
    }
}