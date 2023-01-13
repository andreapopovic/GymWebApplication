using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace BackEnd.Models
{
    [Table("TreneriTreninzi")]
    public class TreneriTreninzi
    {
        [Key]
        
        public int ID { get; set; }
       
        public int TreningId {get;set;}
        public int TrenerId  {get;set;}
      
        
    }
}