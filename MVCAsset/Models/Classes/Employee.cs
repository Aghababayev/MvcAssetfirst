using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MVCAsset.Models.Classes
{
    public class Employee
    {
  

        [Key]
        public int EmployeeID { get; set; }
        [Column(TypeName = "Nvarchar")]
        [StringLength(20)]
        
      
        public string Name { get; set; }
        [Column(TypeName = "Nvarchar")]
        [StringLength(30)]
    
        public string Surname { get; set; }
        
        [Column(TypeName = "Varchar")]
        [StringLength(10)]

        public string ASL { get; set; }
        [Column(TypeName = "Varchar")]
        [StringLength(30)]
        public string Position { get; set; }
        public bool EmpExsist { get; set; }

        public int DepartmentID { get; set; }
        public virtual Department Department { get; set; }

        public Icollection<Handover> Handover { get; set; }
 
    }
}