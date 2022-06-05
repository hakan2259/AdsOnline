using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace AdsOnline.Models.Entities
{
    public class Advert
    {
        [Key]
        public int Id { get; set; }
        [Column(TypeName ="Varchar")]
        [StringLength(100)]
        public string Title { get; set; }
        [Column(TypeName = "Varchar")]
        [StringLength(2000)]
        public string Description { get; set; }
        public decimal Price { get; set; }
        public DateTime AdvertDate { get; set; }
        public bool Status { get; set; }
        [Column(TypeName = "Varchar")]
        [StringLength(250)]
        public string Image { get; set; }
        public int CategoryId { get; set; }
        public virtual Category Category { get; set; }
        


    }
}