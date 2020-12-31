using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CRUDApplication.Models
{
    public class Consultant
    {
        [Key] 
        public int CId { get; set; }
        
        [Required]
        [Column(TypeName = "nvarchar(100)")] 
        public String CFirstName { get; set; }
       
        [Required]
        [Column(TypeName = "nvarchar(100)")] 
        public String CLastName { get; set; }
        
    }
}
