using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace products_categories.Models
{
    public class Category
    {
        [Key]
        public int CategoryId{get;set;}
        [Required]
        [MinLength(2)]
        public string Name { get; set; }
        [Required]
        public DateTime created_at {get;set;} = DateTime.Now;
        public DateTime updated_at {get;set;} = DateTime.Now;
        public List<Associations> Associations {get;set;}   
    } 
}