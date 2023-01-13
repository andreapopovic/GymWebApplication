using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.Text.Json.Serialization;
namespace BackEnd.Models
{
    [Table("ClanTeretane")]
    public class ClanTeretane:KorisnikSajta
    {
        [Column("Visina")]
        public float Visina { get; set; }

        [Column("Tezina")]
        public float Tezina {get;set;}

      //  public virtual List<Trening> ZakazaniTreninzi{get;set;}

      //  [JsonIgnore]
        public Clanarina Clanarina{get;set;}
        
        [Column("ProbniTermin")]
        public bool ProbniTermin {get;set;}
        

    }
}