using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MVCAsset.Models.Classes
{
    public class Handover
    {
        [Key]
   
        public int HandoverID { get; set; }

        public int EmployeeID { get; set; }
       
        [Column(TypeName = "Varchar")]
        [StringLength(10)]
        public string ASL { get; set; }
        public int DeviceID { get; set; }
        [Column(TypeName ="Varchar")]
        [StringLength(20)]
        [Required]
        public string SerialNumber { get; set; }
        [Column(TypeName = "Varchar")]
        [StringLength(300)]

        public string Description { get; set; }
        public DateTime Time { get; set; }

        public virtual Employee Employee { get; set; }
        public virtual Device Device { get; set; }

    }
}