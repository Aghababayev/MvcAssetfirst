using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MVCAsset.Models.Classes
{
    public class Device
    {
       

        [Key]
        public int DeviceID { get; set; }
        [Column(TypeName ="Varchar")]
        [StringLength(30)]
        //[Index(IsUnique =true)]
        public string DevName { get; set; }
        [Column(TypeName = "Varchar" )]
        
        [StringLength(15)]
        public string SerialNumber { get; set; }
        [Column(TypeName = "Varchar")]
        [StringLength(300)]
        public string Description { get; set; }

        public bool DevExist { get; set; }

        public Icollection<Handover> Handover { get; set; }

    }
}