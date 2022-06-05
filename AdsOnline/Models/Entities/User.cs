using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace AdsOnline.Models.Entities
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        [Column(TypeName = "Varchar")]
        [StringLength(30)]
        public string FirstName { get; set; }
        [Column(TypeName = "Varchar")]
        [StringLength(30)]
        public string LastName { get; set; }
        [Column(TypeName = "Varchar")]
        [StringLength(250)]
        public string Image { get; set; }
    }
}