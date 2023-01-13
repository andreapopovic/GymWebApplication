using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System;
namespace BackEnd.Models
{
    [Table("Termin")]
    public class Termin    {

        [Key]
        [Column("ID")]
        public int ID { get; set; }

        [Column("Naziv")]
        public string NazivTreninga { get; set; }
        [Column("KorisnickoImeTr")]
        public string KorisnickoImeTr {get;set;}

        [Column("ImeTrenera")]
        public string ImeTrenera {get;set;}

        [Column("PrezimeTrenera")]
        public string PrezimeTrenera {get;set;}
        [Column("Datum")]
        public string  Datum { get; set; }

        [Column("VremePocetka")]
        public string VremePocetka {get;set;}
        
        [Column("VremeKraja")]
        public string VremeKraja {get;set;}
        
        [Column("TrOsoba")]

         public int TrOsoba { get; set; }    

         [Column("MaxOsoba")]

         public int MaxOsoba { get; set; }       

        // public virtual List<ClanTeretane> clanovi{get;set;} 
    
        

        
    }
}