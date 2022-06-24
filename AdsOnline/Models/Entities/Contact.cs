using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace AdsOnline.Models.Entities
{
    public class Contact
    {
        [Key]
        public int Id { get; set; }
        [Column(TypeName = "Varchar")]
        [StringLength(100)]
        public string UserName { get; set; }
        [Column(TypeName = "Varchar")]
        [StringLength(100)]
        public string Email { get; set; }
        [Column(TypeName = "Varchar")]
        [StringLength(15)]
        public string Phone { get; set; }
        [Column(TypeName = "Varchar")]
        [StringLength(100)]
        public string Subject { get; set; }
        [Column(TypeName = "Varchar")]
        [StringLength(2000)]
        public string Message { get; set; }
    }
}