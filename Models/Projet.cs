using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CRUDApplication.Models
{
    public class Projet
    {
        [Key] 
        public int PId { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(100)")]
        public String PName { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(300)")]
        public String Psubject { get; set; }
        
    }
}
