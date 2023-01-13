using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System;
namespace BackEnd.Models
{
    [Table("Clanarina")]
    public class Clanarina
    {
        
        [Column("ID")]
        public int ID { get; set; }

        [Column("Iznos")]
        
        public int Iznos{get;set;}

        [Column("Placena")]
        public bool Placena {get;set;}

        [Column("DatumPoslednjegPlacanja")]
        public string DatumPoslednjegPlacanja{get;set;}

       
    }
}