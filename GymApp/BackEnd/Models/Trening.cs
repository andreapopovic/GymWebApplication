using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace BackEnd.Models
{
    [Table("Trening")]
    public class Trening
    {
        [Key]
        [Column("ID")]
        public int ID { get; set; }

        [Column("Naziv")]
        public string Naziv { get; set; }

        [Column("Tip")]
        public string Tip {get;set;} //individualni,grupni

        [Column("Cena")]
        public int Cena { get; set; }

        [JsonIgnore]
        public Teretana Teretana{get;set;}

        
     // public TreneriTreninga TreneriTreninga{get;set;}
         
        public virtual List<Termin> Termini {get;set;}
        
    }
}