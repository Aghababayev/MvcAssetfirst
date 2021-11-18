using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MVCAsset.Models.Classes
{
    public class Department
    {    [Key]
        public int DepartmentID { get; set; }
        [Column(TypeName = "Varchar")]
        [StringLength(30)]
        
      // [Index(IsUnique =true)]
      
        public string DepName { get; set; }
       
        public bool DepExisist { get; set; }
        public ICollection<Employee> Employees { get; set; }

    }
}