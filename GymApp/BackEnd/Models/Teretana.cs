using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.Text.Json.Serialization;
namespace BackEnd.Models
{
    [Table("Teretana")]
    public class Teretana
    {
        [Key]
        [Column("ID")]
        public int ID { get; set; }

        [Column("Naziv")]
        public string Naziv { get; set; }

        public virtual List <ClanTeretane> ClanoviTeretane{get;set;}
        public virtual List <Trening> Treninzi{get;set;}    
        public virtual List <Trener> Treneri {get;set;}
        public virtual List <Administrator> Administratori {get;set;}
        public virtual List <Obavestenje> Obavestenja{get;set;}

    }

}