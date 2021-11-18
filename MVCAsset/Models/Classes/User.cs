using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MVCAsset.Models.Classes
{
    public class User
    {   [Key]
        public int UserID { get; set; }
        [Column(TypeName ="Nvarchar")]
        [StringLength(20)]
        [Required]
        public string Username { get; set; }
        [Column(TypeName = "Nvarchar")]
        [StringLength(20)]
        [Required]
        public string Password { get; set; }
        [Column(TypeName = "char")]
        [StringLength(1)]
        [Required]
        public string Permission { get; set; }
    }
}