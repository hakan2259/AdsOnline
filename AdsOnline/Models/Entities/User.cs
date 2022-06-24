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
        [StringLength(15)]
        public string Phone { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(500)]
        public string Address { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(250)]
        public string Image { get; set; }
        [Column(TypeName = "Varchar")]
        [StringLength(50)]
        public string Email { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(20)]
        public string Password { get; set; }
        public bool Status { get; set; }

    }
}