using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CRUDApplication.Models
{
    public class Affectation
    {
        [Key]
        public int AId { get; set; }
        
        [Required] 
        public int PId { get; set; }
       
        [Required]
        public int CId { get; set; }
        
        [Required]
        public DateTime DAffecation { get; set; }
    }
}
