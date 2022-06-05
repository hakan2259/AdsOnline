using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace AdsOnline.Models.Entities
{
    public class Category
    {
        [Key]
        public int Id{ get; set; }
        [Column(TypeName = "Varchar")]
        [StringLength(30)]
        public string Name { get; set; }
        [Column(TypeName = "Varchar")]
        [StringLength(100)]
        public string Description { get; set; }
        public virtual ICollection<Advert> Adverts { get; set; }
      

    }
}