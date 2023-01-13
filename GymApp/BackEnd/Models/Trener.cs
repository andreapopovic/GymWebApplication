using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.Text.Json.Serialization;
namespace BackEnd.Models
{
    [Table("Trener")]
    public class Trener:KorisnikSajta
    {
       // [JsonIgnore]
      //  public virtual List<Trening> TreninziKojeDrzii{get;set;}
        
        
        
     //   public TreninziTrenera TreninziKojeDrzi{get;set;}
    public List<Zahtev> Zahtevi{get;set;}
       
    }
    
}