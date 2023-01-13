using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.Text.Json.Serialization;
namespace BackEnd.Models
{
    [Table("Obavestenje")]
    public class Obavestenje
    {
        [Key]
        [Column("ID")]
        public int ID { get; set; }

        [Column("Sadrzaj")]
        public string Sadrzaj { get; set; }
    }
}