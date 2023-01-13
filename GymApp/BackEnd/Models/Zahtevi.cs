using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System;
namespace BackEnd.Models
{
    [Table("Zahtev")]
    public class Zahtev
    {
        
        [Column("ID")]
        public int ID { get; set; }

        [Column("Datum")]
        public string Datum {get;set;}

        [Column("TreningId")]
        public int TreningId{get;set;}

        [Column("TrenerId")]
        public int TrenerId{get;set;}
        [Column("TrenerIme")]
        public string TrenerIme{get;set;}

        [Column("TrenerPrezime")]
        public string TrenerPrezime{get;set;}  
     
        [Column("ClanId")]
        public int ClanId {get;set;}
      
        [Column("ClanIme")]
        public string ClanIme {get;set;}
        
        [Column("ClanPezime")]
        public string ClanPrezime {get;set;}

        [Column("VremeOd")]
        
        public string VremeOd{get;set;}

       [Column("VremeDo")]
        
        public string VremeDo{get;set;}

        [Column("Opis")]
        public string Opis {get;set;}
        [Column("Prihvacen")]
        public string Prihvacen{get;set;}



       

       
    }
}