using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Principal;
using System.Threading.Tasks;

namespace LrMetadataBuilder.Models
{
    public class League
    {
        [Key]
        public int Id { get; set; }
        [Display(Name = "League Name")]
        public string Name { get; set; }    
    }
}
