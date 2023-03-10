using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
namespace BackEnd.Models
{
    public class AutenticationConfiguration
    {
        public string AccessTokenSecret{get;set;}
        public int AccessTokenExpirationMinutes {get;set;}
        public string Issuer {get;set;}

        public string Audience {get;set;}
    }
}