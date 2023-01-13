using System;
using System.IO;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using BackEnd.Models;
using System.IdentityModel.Tokens.Jwt;
using BackEnd.Services.PasswordHashers;
using BackEnd.Response;
using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens;
using Microsoft.AspNetCore.Http;
using BackEnd.Services;
using Microsoft.AspNetCore.Hosting;
namespace BackEnd.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class GymController : ControllerBase
    {
    
        private readonly JwtService _jwtService;
        private readonly IWebHostEnvironment _hostEnvironment;
        public GymContext Context{get;set;}
        public GymController(GymContext context,JwtService service,IWebHostEnvironment env)
        {
            Context=context;
            _jwtService=service;
           this. _hostEnvironment=env;
        
        }
        [Route("PreuzmiTeretanu")]
        [HttpGet]
        public async Task<List<Teretana>> PreuzmiTeretanu()
        {
            return await Context.Teretana.Include(p=>p.ClanoviTeretane).Include(p=>p.Treneri).Include(p=>p.Administratori).Include(p=>p.Treninzi).ToListAsync();

        }
       [Route("PreuzmiClanove")]
        [HttpGet]
        public async Task<List<ClanTeretane>> PreuzmiClanoveTeretane()
        {
            return await Context.ClanoviTeretane.Include(p=>p.Clanarina).ToListAsync();
        }
        [Route("PreuzmiTrenere")]
        [HttpGet]
        public async Task<List<Trener>> PreuzmiTrenere()
        {
            return await Context.Treneri.ToListAsync();
        }
         [Route("PreuzmiTreningeTrenera")]
      /*  [HttpGet]
        public async Task<List<TreninziTrenera>> PreuzmiTreningeTrenera()
        {
           return await Context.TreninziTrenera.Include(p=>p.TreninziZadatogTrenera).ToListAsync();
        }
         [Route("PreuzmiTrenereTreninga")]
        [HttpGet]
        public async Task<List<TreneriTreninga>> PreuzmiTrenereTreninga()
        {
           return await Context.TreneriTreninga.Include(p=>p.TreneriZadatogTreninga).ToListAsync();
        }
         [Route("PreuzmiTrenereTreninga/{id}")]
        [HttpGet]
        public async Task<List<Trener>> PreuzmiTrenere(int id)
        {
             var trening= await Context.Treninzi.Where(p=>p.ID==id).FirstOrDefaultAsync();
            var treneri= await Context.TreneriTreninga.Include(p=>p.TreneriZadatogTreninga).Where(p=>p.NazivTreninga==trening.Naziv).FirstOrDefaultAsync();
            return treneri.TreneriZadatogTreninga;
        }
        [Route("PreuzmiTreningeTrenera/{id}")]
        [HttpGet]
        public async Task<List<Trening>> PreuzmiTreningeTrenera(int id)
        {
            var trener= await Context.Treneri.Where(p=>p.ID==id).FirstOrDefaultAsync();
            var treninzi= await Context.TreninziTrenera.Include(p=>p.TreninziZadatogTrenera).Where(p=>p.KorisnickoImeTrenera==trener.KorisnickoIme).FirstOrDefaultAsync();
            return treninzi.TreninziZadatogTrenera;
       }
        
     */
        

       [Route("PreuzmiTreninge")]
        [HttpGet]
        public async Task<List<Trening>> PreuzmiTreninge()
        {
            return await Context.Treninzi.Include(p=>p.Termini).ToListAsync();
        }
         [Route("PreuzmiClanarine")]
        [HttpGet]
        public async Task<List<Clanarina>> PreuzmiClanarine()
        {
            return await Context.Clanarine.ToListAsync();
        }

        [Route("PreuzmiObavestenja")]
        [HttpGet]
        public async Task<List<Obavestenje>> PreuzmiObavestenje()
        {
            return await Context.Obavestenja.ToListAsync();
        }

         
        [Route("DodajObavestenje")]
        [HttpPost]
        public async Task DodajObavestenje([FromBody] Obavestenje obavestenje )
        {
            Context.Obavestenja.Add(obavestenje);
            await Context.SaveChangesAsync();

        }
        
        
        [Route("UpisiTeretanu")]
        [HttpPost]
        public async Task UpisiTeretanu([FromBody] Teretana teretana)
        {
            Context.Teretana.Add(teretana);
            await Context.SaveChangesAsync();

        }
        [Route("DodajTrening")]
        [HttpPost]
        public async Task DodajTrening([FromBody] Trening Trening)
        {
             Teretana ter= await Context.Teretana.Where(p=>p.Naziv=="DreamTeamGym").FirstOrDefaultAsync();
             Trening.Teretana=ter;
             
          //    TreneriTreninga treneri= new TreneriTreninga();
          //   treneri.NazivTreninga=Trening.Naziv;
            //  Trening.TreneriTreninga=treneri;
            Context.Treninzi.Add(Trening);
          //  Context.TreneriTreninga.Add(treneri);
            
            await Context.SaveChangesAsync();

        }
        [Route("FindUserByEmail")]
        [HttpGet]
        public async Task<ClanTeretane> FindUserByEmail(string email)
        {
            ClanTeretane kor= await Context.ClanoviTeretane.Where(p=>p.Email==email).FirstOrDefaultAsync();
            return kor;
        }
        [Route("FindAnyUserByEmail")]
         [HttpGet]
        public async Task<KorisnikSajta> FindAnyUserByEmail(string email)
        {
            ClanTeretane kor= await Context.ClanoviTeretane.Where(p=>p.Email==email).FirstOrDefaultAsync();
            if(kor==null)
            {
                Trener trener= await Context.Treneri.Where(p=>p.Email==email).FirstOrDefaultAsync();
                {
                    if(trener!=null)
                    {
                        return trener;
                    }
                     Administrator adm= await Context.Administratori.Where(p=>p.Email==email).FirstOrDefaultAsync();
                    if(adm!=null)
                    {
                        return adm;
                    }
                    else return null;
                    
                

                }
            }
            else return kor;
        }
        [Route("FindAnyUserByUserName")]
        [HttpGet]
        public async Task<KorisnikSajta> FindAnyUserByUserName(string username)
        {

            ClanTeretane kor= await Context.ClanoviTeretane.Where(p=>p.KorisnickoIme==username).FirstOrDefaultAsync();
            if(kor==null)
            {
                Trener trener= await Context.Treneri.Where(w=>w.KorisnickoIme==username).FirstOrDefaultAsync();
                {
                    if(trener!=null)
                    {
                        return trener;
                    }
                    Administrator adm= await Context.Administratori.Where(w=>w.KorisnickoIme==username).FirstOrDefaultAsync();
                    if(adm!=null)
                    {
                        return adm;
                    }
                    else return null;
                    
                

                }
            }
            else return kor;
        }
        [Route("FindTrenerByEmail")]
        [HttpGet]
        public async Task<Trener> FindTrenerByEmail(string email)
        {
            Trener kor= await Context.Treneri.Where(p=>p.Email==email).FirstOrDefaultAsync();
            return kor;
        }
        [Route("FindUserById")]
        [HttpGet]
        public async Task<KorisnikSajta> FindUserById(int id)
        {
            ClanTeretane kor= await Context.ClanoviTeretane.Where(p=>p.ID==id).FirstOrDefaultAsync();
            if(kor==null)
            {
                Trener trener= await Context.Treneri.Where(w=>w.ID==id).FirstOrDefaultAsync();
                {
                    if(trener!=null)
                    {
                        return trener;
                    }
                    Administrator adm= await Context.Administratori.Where(w=>w.ID==id).FirstOrDefaultAsync();
                    if(adm!=null)
                    {
                        return adm;
                    }
                    else return null;
                }
            }
            else return kor;
        }
  

        [Route("ObrisiClana/{id}")]
        [HttpDelete]
        public async Task ObrisiClana(int id)
        {
         ClanTeretane clan= await Context.ClanoviTeretane.Where(p=>p.ID==id).Include(p=>p.Clanarina).FirstOrDefaultAsync();
           
           var idClanarine= clan.Clanarina.ID;
           
           Clanarina clanarina=await Context.Clanarine.Where(p=>p.ID==idClanarine).FirstOrDefaultAsync();
           clan.Clanarina=null;
           Context.ClanoviTeretane.Remove(clan);
           Context.Clanarine.Remove(clanarina);
           await Context.SaveChangesAsync();
        }
        [Route("ObrisiTrening/{id}")]
        [HttpDelete]
        public async Task ObrisiTrening(int id)
        {
         
           Trening tr= await Context.Treninzi.Where(p=>p.ID==id).FirstOrDefaultAsync();
           Context.Treninzi.Remove(tr);
           
           await Context.SaveChangesAsync();
        }
        [Route("ObrisiClanarinu/{id}")]
        [HttpDelete]
        public async Task ObrisiClanarinu(int id)
        {
           Clanarina clan=await Context.Clanarine.FindAsync(id);
           
           Context.Clanarine.Remove(clan);
           await Context.SaveChangesAsync();
        }
        [Route("ObrisiObaveštenje/{id}")]
        [HttpDelete]
        public async Task ObrisiObaveštenje(int id)
        {
           Obavestenje obv=await Context.Obavestenja.FindAsync(id);
           
           Context.Obavestenja.Remove(obv);
           await Context.SaveChangesAsync();
        }
        [Route("ObrisiAdmina/{id}")]
        [HttpDelete]
        public async Task ObrisiAdmina(int id)
        {
          Administrator adm=await Context.Administratori.FindAsync(id);
           Context.Administratori.Remove(adm);
           await Context.SaveChangesAsync();
        }
        [Route("ObrisiTrenera/{id}")]
        [HttpDelete]
        public async Task ObrisiTrenera(int id)
        {
           Trener trener=await Context.Treneri.Where(p=>p.ID==id).FirstOrDefaultAsync();
          
           
         //  TreninziTrenera treninzi= await Context.TreninziTrenera.Where(p=>p.KorisnickoImeTrenera==trener.KorisnickoIme).FirstOrDefaultAsync();

           Context.Treneri.Remove(trener);
        //   Context.TreninziTrenera.Remove(treninzi);
           await Context.SaveChangesAsync();
        }

        [Route("RegisterKorisnik")]
        [HttpPost]
        public async Task<IActionResult> RegisterKorisnik([FromBody] KorisnikSajta korisnik)
        {
            if(!ModelState.IsValid)
            {
                IEnumerable<string> errors=ModelState.Values.SelectMany(v=>v.Errors.Select(e=>e.ErrorMessage));
                return BadRequest(new ErrorResponse(errors));
            }
            if(korisnik.Sifra!=korisnik.PotvrdaSifre)
            {
                return BadRequest(new ErrorResponse("Šifra se ne poklapa sa potvrdom."));
            }
           
           KorisnikSajta proveraEmaila=  await this.FindAnyUserByEmail(korisnik.Email);
           if(proveraEmaila!=null)
           {
              
               return BadRequest("Email postoji.");

           }
          KorisnikSajta proveraKorisnickogImena=await this.FindAnyUserByUserName(korisnik.KorisnickoIme);
           if(proveraKorisnickogImena!=null)
           {
               return Conflict(new ErrorResponse("Korisničko ime već postoji."));
           }
           
           string salt=BCrypt.Net.BCrypt.GenerateSalt();
          
            string confirmPass=korisnik.PotvrdaSifre+salt;
            string hashPass=BCrypt.Net.BCrypt.HashPassword(korisnik.Sifra,salt);
            string hashconfirmPass=BCrypt.Net.BCrypt.HashPassword(confirmPass,salt);
           
           Teretana ter= await Context.Teretana.Where(p=>p.Naziv=="DreamTeamGym").FirstOrDefaultAsync();
          
          if(korisnik.tip==1)
          {
              Administrator adm=new Administrator();
              adm.Ime=korisnik.Ime;
              adm.Prezime=korisnik.Prezime;
              adm.Telefon=korisnik.Telefon;
              adm.Email=korisnik.Email;
             
              adm.tip=korisnik.tip;
              adm.KorisnickoIme=korisnik.KorisnickoIme;
              adm.Teretana=ter;
              adm.Sifra=hashPass;
              adm.PotvrdaSifre=hashconfirmPass;
              adm.RAND_SALT=salt;
              
              Context.Administratori.Add(adm);
              adm.ID=await Context.SaveChangesAsync();
              return Ok(adm);
          } 
          else if(korisnik.tip==2)
          {
              Trener tr=new Trener();
              tr.Ime=korisnik.Ime;
              tr.Prezime=korisnik.Prezime;
              tr.Telefon=korisnik.Telefon;
              tr.Email=korisnik.Email;
             
              tr.tip=korisnik.tip;
              tr.KorisnickoIme=korisnik.KorisnickoIme;

              tr.Teretana=ter;
              tr.Sifra=hashPass;
              tr.PotvrdaSifre=hashconfirmPass;
              tr.RAND_SALT=salt;

           //   TreninziTrenera treninzi= new TreninziTrenera();
           //   treninzi.KorisnickoImeTrenera=tr.KorisnickoIme;
             // tr.TreninziKojeDrzi=treninzi;
              

              Context.Treneri.Add(tr);
            //  Context.TreninziTrenera.Add(treninzi);
              tr.ID=await Context.SaveChangesAsync();
              return Ok(tr);
              
          }
          else if(korisnik.tip==3)
          {
             ClanTeretane clan=new ClanTeretane();
              clan.Ime=korisnik.Ime;
              clan.Prezime=korisnik.Prezime;
              clan.Telefon=korisnik.Telefon;
              clan.Email=korisnik.Email;
              clan.tip=korisnik.tip;
              clan.KorisnickoIme=korisnik.KorisnickoIme;

              clan.Teretana=ter;
              clan.Sifra=hashPass;
              clan.PotvrdaSifre=hashconfirmPass;
              clan.RAND_SALT=salt;
              clan.ProbniTermin=true;
              Context.ClanoviTeretane.Add(clan);
              
              
              Clanarina clanarina=new Clanarina();
              clanarina.Iznos=1000;//fiksno
              clanarina.ID=clan.ID;
             // clanarina.DatumPoslednjegPlacanja="";
              clanarina.Placena=false;
              
              Context.Clanarine.Add(clanarina);
              clan.Clanarina=clanarina;
              //clan.ID=await Context.SaveChangesAsync();
              await Context.SaveChangesAsync();
              return Ok(clan);
          }

          else
          {
              return BadRequest();
          }
          
        }
     
        [Route("Login")]
        [HttpPost]
        public async Task<IActionResult> Login([FromBody] KorisnikSajta korisnik)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(new ErrorResponse("Došlo je do greške."));
            }
            var korisnickoIme=korisnik.KorisnickoIme;
            KorisnikSajta korisnikSajta= await this.FindAnyUserByUserName(korisnickoIme);
            if(korisnikSajta==null)
            {
                return BadRequest(new ErrorResponse("Član sa ovim korisničkim imenom ne postoji."));
            }
           
            
            string hashPass=BCrypt.Net.BCrypt.HashPassword(korisnik.Sifra,korisnikSajta.RAND_SALT);
            
            if(hashPass!=korisnikSajta.Sifra)
            {
                return Conflict(new ErrorResponse("Pogrešna šifra!"));
            }

            //Generisanje JWT tokena 

            SecurityKey key=new SymmetricSecurityKey(Encoding.UTF8.GetBytes("0TjrED4Ag5otmv-zXYKjlGu73glokiAtQ72HlcptvMn8dhSad-fSiPtUPnLkETbdDX3mWp4_lgac--qQfpHMATAlAK8Aw0vseATcSMTb1aUkyeKi585EqXekM5tBKqWftmmqbhW_2uVdsGT58HVdWCjVV6TSprBRCPqKWgw5l_0"));
            SigningCredentials credentials=new SigningCredentials(key,SecurityAlgorithms.HmacSha256);
            var header=new JwtHeader(credentials);
            
            var payload=new JwtPayload(korisnikSajta.ID.ToString(),null,null,null,DateTime.UtcNow.AddDays(1));
            JwtSecurityToken token=new JwtSecurityToken(header,payload); //Kreirali smo JWT token
            string jwt= new JwtSecurityTokenHandler().WriteToken(token);
           Response.Cookies.Append("jwt",jwt,new CookieOptions
           {
               HttpOnly=true
           });
            return Ok(new
           {
               message=jwt
           });
          
          
        }
        [Route("PreuzmiClana")]
        [HttpGet]
        public async Task<IActionResult> PreuzmiClana( )
        {
            
            
          try{
            //validacija tokena
               var jwt=Request.Headers["Authorization"];
            
               var token=_jwtService.Verify(jwt);
               int korisnikId=int.Parse(token.Issuer);
               KorisnikSajta korisnik= await this.FindUserById(korisnikId);
               

               if(korisnik!=null)
               {
                   if(korisnik.tip==3)
                   {
                       ClanTeretane clan=await Context.ClanoviTeretane.Where(p=>p.Email==korisnik.Email).Include(p=>p.Clanarina).FirstOrDefaultAsync();
                       return Ok(clan);

                   }
                  else if(korisnik.tip==1)
                   {
                      Administrator adm=await Context.Administratori.Where(p=>p.Email==korisnik.Email).FirstOrDefaultAsync();
                      return Ok(adm);
                   }
                  else if(korisnik.tip==2)
                  {
                      Trener trener=await Context.Treneri.Where(p=>p.Email==korisnik.Email).FirstOrDefaultAsync();
                      return Ok(trener);
                  }
                  else return BadRequest();
               }
              
               else return BadRequest(new ErrorResponse(jwt.ToString()));

           }
            catch(Exception )
            {
                return Unauthorized();

            }

        }
       
        [Route("IzmeniClana/{id}")]
        [HttpPut]
        public async Task IzmeniClana(int id,[FromBody] ClanTeretane clan)
        {
            var cl=await Context.ClanoviTeretane.Where(p=>p.ID==id).FirstOrDefaultAsync();
           
           cl.Ime=clan.Ime;
           cl.Prezime=clan.Prezime;
           cl.Godine=clan.Godine;
           cl.Telefon=clan.Telefon;
           cl.Email=clan.Email;
           cl.Visina=clan.Visina;
           cl.Tezina=clan.Tezina;
          await Context.SaveChangesAsync();
    
        }
        [Route("IzmeniDaLiJeCLanarinaPlacena/{idClana}/{izmena}")]
        [HttpPut]
        public async Task IzmeniDaLiJeCLanarinaPlacena(int idClana,int izmena)
        {
           ClanTeretane clan= await Context.ClanoviTeretane.Include(p=>p.Clanarina).Where(p=>p.ID==idClana).FirstOrDefaultAsync();
           if(izmena==0)
           {
             clan.Clanarina.Placena=false;
           }
           else if(izmena==1)
           {
               clan.Clanarina.DatumPoslednjegPlacanja=DateTime.Now.ToString("dd:MM:yyyy");
               clan.Clanarina.Placena=true;

           }
          await Context.SaveChangesAsync();
    
        }
        [Route("IzmeniAdministratora/{id}")]
        [HttpPut]
        public async Task IzmeniAdministratora(int id,[FromBody] Administrator adm)
        {
            var administr=await Context.Administratori.Where(p=>p.ID==id).FirstOrDefaultAsync();
           
           administr.Ime=adm.Ime;
           administr.Prezime=adm.Prezime;
           administr.Godine=adm.Godine;
           administr.Telefon=adm.Telefon;
           administr.Email=adm.Email;
          
          await Context.SaveChangesAsync();
    
        }
        
        [Route("IzmeniTrenera/{id}")]
        [HttpPut]
        public async Task IzmeniTrenera(int id,[FromBody]Trener trener)
        {
            var cl=await Context.Treneri.Where(p=>p.ID==id).FirstOrDefaultAsync();
           
           cl.Ime=trener.Ime;
           cl.Prezime=trener.Prezime;
           cl.Godine=trener.Godine;
           cl.Telefon=trener.Telefon;
           cl.Email=trener.Email;
          
           await Context.SaveChangesAsync();
    
        }
        [Route("IzmeniTipTreninga/{id}/{tip}")]
        [HttpPut]
        public async Task IzmeniTipTreninga(int id,string tip)
        {
           Trening trening= await Context.Treninzi.Where(p=>p.ID==id).FirstOrDefaultAsync();
           
           trening.Tip=tip;
          
          await Context.SaveChangesAsync();
    
        }
        [Route("IzmeniCenuTreninga/{id}/{cena}")]
        [HttpPut]
        public async Task IzmeniTipTreninga(int id,int cena)
        {
           Trening trening= await Context.Treninzi.Where(p=>p.ID==id).FirstOrDefaultAsync();
           
           trening.Cena=cena;
          
          await Context.SaveChangesAsync();
    
        }
        [Route("IzmeniSliku/{korIme}")]
        [HttpPut]
        public async Task<IActionResult> IzmeniSliku(string korIme,[FromForm]IFormFile profilnaFIle)
        {
            

            var korisniksajta= await this.FindAnyUserByUserName(korIme);
            if(korisniksajta==null)
            {
                return BadRequest();
            }
            else
            {
              var slikaPom= await SacuvajSliku(profilnaFIle);
              korisniksajta.Slika=  String.Format("{0}://{1}{2}/Images/{3}",Request.Scheme,Request.Host,Request.PathBase,slikaPom);
              await Context.SaveChangesAsync();
                
                return Ok();

            }
           
           
        }
        [NonAction]
        public async Task<string> SacuvajSliku(IFormFile slika)
        {
            string imeSlike= new String (Path.GetFileNameWithoutExtension(slika.FileName).Take(10).ToArray()).Replace(' ','-');
            
            imeSlike=imeSlike+DateTime.Now.ToString("yymmssfff")+Path.GetExtension(slika.FileName);
            
            var slikaPath= Path.Combine(_hostEnvironment.ContentRootPath,"Images",imeSlike);
            using (var fileStream=new FileStream(slikaPath,FileMode.Create))
            {
                await slika.CopyToAsync(fileStream);
            }
            return imeSlike;

        }
        
        [Route("DodajTreningeTrenera/{idTreninga}/{idTrenera}")]
        [HttpPost]
        public async Task DodajTreningeTrenera(int idTreninga,int idTrenera)
        {
         
            TreneriTreninzi treneritreninzi=new TreneriTreninzi();
            treneritreninzi.TrenerId=idTrenera;
            treneritreninzi.TreningId=idTreninga;
            Context.TreneriTreninzi.Add(treneritreninzi);
            await Context.SaveChangesAsync();
        }
        [Route("PreuzmiTreningeTrenera/{id}")]
        [HttpGet]
        public async Task<List<Trening>> PreuzmiTreningeTrenera(int id)
        {
            List<Trening> treninzi=new List<Trening>();
           List<TreneriTreninzi> treneritreninzi= await Context.TreneriTreninzi.Where(p=>p.TrenerId==id).ToListAsync();
            foreach (var tr in treneritreninzi)
            {
                Trening trening= await Context.Treninzi.Where(p=>p.ID==tr.TreningId).FirstOrDefaultAsync();
                treninzi.Add(trening);
                
            }
            return treninzi;
        }

        [Route("PreuzmiTrenereTreninga/{id}")]
        [HttpGet]
        public async Task<List<Trener>> PreuzmiTrenereTreninga(int id)
        {
            List<Trener> treneri=new List<Trener>();
           List<TreneriTreninzi> treneritreninzi= await Context.TreneriTreninzi.Where(p=>p.TreningId==id).ToListAsync();
            foreach (var tr in treneritreninzi)
            {
                Trener trener= await Context.Treneri.Where(p=>p.ID==tr.TrenerId).FirstOrDefaultAsync();
               treneri.Add(trener);
                
            }
            return treneri;
        }
        [Route("PreuzmiTrenereITreninge")]
        [HttpGet]
        public async Task<List<TreneriTreninzi>> PreuzmiTrenereiTreninge()
        {
           return await Context.TreneriTreninzi.ToListAsync();
        }
       [Route("KreirajNoviTermin/{id}")]
       [HttpPost]
       public async Task DodajNoviTerminTreninga(int id,[FromBody]Termin termin)
       {
           Trening trening= await Context.Treninzi.Include(p=>p.Termini).Where(p=>p.ID==id).FirstOrDefaultAsync();
          
          trening.Termini.Add(termin);
         Context.Termini.Add(termin);
           await Context.SaveChangesAsync();
       }
       [Route("ObrisiTermin/{id}")]
       [HttpDelete]
       public async Task ObrisiTermin(int id)
       {
           Termin termin= await Context.Termini.FindAsync(id);
           //Trening trening= await Context.Treninzi.Where(p=>p.Naziv==termin.NazivTreninga).FirstOrDefaultAsync();
           Context.Termini.Remove(termin);
           await Context.SaveChangesAsync();
       }
       [Route("PreuzmiTermine")]
       [HttpGet]
       public async Task<List<Termin>> PreuzmiTermine()
       {
           return await Context.Termini.ToListAsync();
       }
       [Route("PreuzmiTermine/{KorImeTrenera}/{NazivTreninga}")]
       [HttpGet]
       public async Task<List<Termin>> PreuzmiTermine(string KorImeTrenera,string NazivTreninga)
       {
            await this.ObrisiProsleTermine(NazivTreninga);
           return await Context.Termini.Where(p=>p.NazivTreninga==NazivTreninga && p.KorisnickoImeTr==KorImeTrenera).ToListAsync();
       }
       [Route("PreuzmiTermine/{NazivTreninga}")]
       [HttpGet]
       public async Task<List<Termin>> PreuzmiTermine(string NazivTreninga)
       {
           await this.ObrisiProsleTermine(NazivTreninga);
           return await Context.Termini.Where(p=>p.NazivTreninga==NazivTreninga ).ToListAsync();
       }
       [Route("ObrisiProsleTermine/{NazivTreninga}")]
       [HttpGet]
       public async Task  ObrisiProsleTermine(string NazivTreninga)
       {
           string trDatum= DateTime.Now.ToString("MM/dd/yyyy" );
           
           List<Termin> termini=await Context.Termini.Where(p=>p.NazivTreninga==NazivTreninga ).ToListAsync();
           foreach (var termin in termini)
           {
               string [] datumTermin=termin.Datum.Split("/");
               
               string [] datumDanas=trDatum.Split("-");
               if(Int16.Parse(datumTermin[0])<Int16.Parse(datumDanas[0]) || Int16.Parse(datumTermin[0])==Int16.Parse(datumDanas[0]) && Int16.Parse(datumTermin[1])<Int16.Parse(datumDanas[1]) )
                 {
                     Context.Termini.Remove(termin);
                 }
           }
           await Context.SaveChangesAsync();
       }
        [Route("DodajTermineClanova/{idTermina}/{idClana}")]
        [HttpPost]
        public async Task<IActionResult> DodajTermineClanova(int idTermina,int idClana)
        {
            Termin termin=await Context.Termini.FindAsync(idTermina);
            ClanTeretane clan = await Context.ClanoviTeretane.Include(p=>p.Clanarina).Where(p=>p.ID==idClana).FirstOrDefaultAsync();
            Trening trening= await Context.Treninzi.Where(p=>p.Naziv==termin.NazivTreninga).FirstOrDefaultAsync();
            if(clan.Clanarina.Placena==false && clan.ProbniTermin==false)
            {
                return StatusCode(451);
            }
          else  if(termin.TrOsoba>=termin.MaxOsoba)
            {
                return StatusCode(452);
            }
            else if(clan.Clanarina.Placena==false && clan.ProbniTermin==true)
            {
                termin.TrOsoba++;
              ClanoviTermini clanovitermini=new ClanoviTermini();
            clanovitermini.ClanoviId=idClana;
            clanovitermini.TerminId=idTermina;
            Context.ClanoviTermini.Add(clanovitermini);
            clan.ProbniTermin=false;
            await Context.SaveChangesAsync();
            return Ok();

            }
            else 
            {

            termin.TrOsoba++;
            ClanoviTermini clanovitermini=new ClanoviTermini();
            clanovitermini.ClanoviId=idClana;
            clanovitermini.TerminId=idTermina;
            Context.ClanoviTermini.Add(clanovitermini);
            clan.Clanarina.Iznos+=trening.Cena;
            await Context.SaveChangesAsync();
            return Ok();
            }

        }
        [Route("PreuzmiTermineClana/{id}")]
        [HttpGet]
        public async Task<List<Termin>> PreuzmiTermineClana(int id)
        {
            List<Termin> termini=new List<Termin>();
            string trDatum= DateTime.Now.ToString("MM/dd/yyyy" );
           List<ClanoviTermini> clanovitermini= await Context.ClanoviTermini.Where(p=>p.ClanoviId==id).ToListAsync();
            foreach (var ter in clanovitermini)
            {
                Termin termin= await Context.Termini.Where(p=>p.ID==ter.TerminId).FirstOrDefaultAsync();
                if(termin!=null)
                {
                string [] datumTermin=termin.Datum.Split("/");
               
               string [] datumDanas=trDatum.Split("-");
               if(Int16.Parse(datumTermin[0])<Int16.Parse(datumDanas[0]) || Int16.Parse(datumTermin[0])==Int16.Parse(datumDanas[0]) && Int16.Parse(datumTermin[1])<Int16.Parse(datumDanas[1]) )
                 {

                     termini.Add(termin);
                 }
               
                }
            }
           

            return termini;
        }

        [Route("PreuzmiClanoveTermina/{id}")]
        [HttpGet]
        public async Task<List<ClanTeretane>> PreuzmiClanoveTermina(int id)
        {
            List<ClanTeretane> clanovi=new List<ClanTeretane>();
           List<ClanoviTermini> clanovitermini= await Context.ClanoviTermini.Where(p=>p.TerminId==id).ToListAsync();
            foreach (var ter in clanovitermini)
            {
               ClanTeretane clan= await Context.ClanoviTeretane.Where(p=>p.ID==ter.ClanoviId).FirstOrDefaultAsync();
                clanovi.Add(clan);
                
            }
            return clanovi;
        }
        [Route("ObrisiClanoveTermina/{id}")]
        [HttpDelete]
        public async Task ObrisiClanoveTermina(int id)
        {
         ClanoviTermini clanoviTerm=await  Context.ClanoviTermini.FindAsync(id);
         Context.ClanoviTermini.Remove(clanoviTerm);
         await Context.SaveChangesAsync();
        }
        [Route("OtkaziTermin/{idClana}/{idTermina}")]
        [HttpDelete]
        public async Task ObrisiClanoveTermina(int idClana,int idTermina)
        {
         ClanoviTermini clanoviTerm=await  Context.ClanoviTermini.Where(p=>p.ClanoviId==idClana && p.TerminId==idTermina).FirstOrDefaultAsync();
         ClanTeretane clan= await Context.ClanoviTeretane.Include(p=>p.Clanarina).Where(p=>p.ID==idClana).FirstOrDefaultAsync();
         Termin termin =await Context.Termini.FindAsync(idTermina);
         Trening trening= await Context.Treninzi.Where(p=>p.Naziv==termin.NazivTreninga).FirstOrDefaultAsync();
          if(trening.Naziv=="Personalni trening")
          {
            Context.Termini.Remove(termin);
            clan.Clanarina.Iznos-=trening.Cena;
          }
          else
          {
              Context.ClanoviTermini.Remove(clanoviTerm);
            clan.Clanarina.Iznos-=trening.Cena;
              termin.TrOsoba--;

          }
         
         await Context.SaveChangesAsync();
        }

        [Route("PreuzmiClanoveITermine")]
        [HttpGet]
        public async Task<List<ClanoviTermini>> PreuzmiClanoveITermine()
        {
           return await Context.ClanoviTermini.ToListAsync();
        }
        [Route("PreuzmiSveZahteve")]
        [HttpGet]
        public async Task<List<Zahtev>> PreuzmiSveZahteve()
        {
           return await Context.Zahtevi.ToListAsync();
        }
        [Route("PosaljiZahtevTreneru/{id}")]
        [HttpPost]
        public async Task<IActionResult> PosaljiZahtevTreneru(int id,[FromBody]Zahtev zahtev)
        {
           Trener trener=await Context.Treneri.Include(p=>p.Zahtevi).Where(p=>p.ID==id).FirstOrDefaultAsync();
           ClanTeretane clan=await Context.ClanoviTeretane.Include(p=>p.Clanarina).Where(p=>p.ID==zahtev.ClanId).FirstOrDefaultAsync();
          if(clan.Clanarina.Placena==false && clan.ProbniTermin==false)
          {
              return StatusCode(451);
          }
          else if(clan.Clanarina.Placena==false && clan.ProbniTermin==true)
          {
            zahtev.ClanIme=clan.Ime;
           zahtev.ClanPrezime=clan.Prezime;
           zahtev.Prihvacen="Čekanje potvrde";
           clan.ProbniTermin=false;
           Context.Zahtevi.Add(zahtev);
           trener.Zahtevi.Add(zahtev);
           await Context.SaveChangesAsync();
           return Ok();
           
          }
          else if(clan.Clanarina.Placena==true)
          {
           zahtev.ClanIme=clan.Ime;
           zahtev.ClanPrezime=clan.Prezime;
           zahtev.Prihvacen="Čekanje potvrde";
           Context.Zahtevi.Add(zahtev);
           trener.Zahtevi.Add(zahtev);
           await Context.SaveChangesAsync();
           return Ok();
          }
          else return BadRequest();

        }
        
        [Route("ObrisiZahtev/{id}")]
        [HttpDelete]
        public async Task ObrisiZahtev(int id)
        {
            Zahtev zahtev= await Context.Zahtevi.FindAsync(id);
            Context.Zahtevi.Remove(zahtev);
            await Context.SaveChangesAsync();
        }
        [Route("OdbijZahtev/{idTrenera}/{idZahteva}")]
        [HttpPut]
        public async Task OdbijZahtev (int idTrenera,int idZahteva)
        {
           
           Zahtev zahtev= await Context.Zahtevi.FindAsync(idZahteva);
           zahtev.Prihvacen="Odbijen";
           await Context.SaveChangesAsync();
        }
        [Route("PreuzmiZahteveTrenera/{id}")]
        [HttpGet]
        public async Task<List<Zahtev>> PreuzmniZahteveTrenera(int id)
        {
            Trener trener=await Context.Treneri.Include(p=>p.Zahtevi).Where(p=>p.ID==id).FirstOrDefaultAsync();
            List<Zahtev> zahteviTrenera=new List<Zahtev>();
            foreach (var zahtev in trener.Zahtevi)
            {
                if(zahtev.Prihvacen!="Odbijen" && zahtev.Prihvacen!="Prihvaćen")
                {
                    zahteviTrenera.Add(zahtev);
                }
                
            }
            return  zahteviTrenera;
        }
        [Route("PreuzmiZahteveClana/{id}")]
        [HttpGet]
        public async Task<List<Zahtev>> PreuzmniZahteveClana(int id)
        {
            return await Context.Zahtevi.Where(p=>p.ClanId==id).ToListAsync();
        }
        [Route("PrihvatiZahtev/{idZahteva}")]
        [HttpPost]
        public async Task PrihvatiZahtev(int idZahteva,[FromBody]Zahtev zaht)
       {
           Zahtev zahtev= await Context.Zahtevi.FindAsync(idZahteva);
           Trening trening=await Context.Treninzi.FindAsync(zahtev.TreningId);
           Trener trener= await Context.Treneri.FindAsync(zahtev.TrenerId);
           ClanTeretane clan= await Context.ClanoviTeretane.Include(p=>p.Clanarina).Where(p=>p.ID==zahtev.ClanId).FirstOrDefaultAsync();
           Termin termin=new Termin();
           termin.NazivTreninga=trening.Naziv;
           termin.KorisnickoImeTr=trener.KorisnickoIme;
           termin.ImeTrenera=trener.Ime;
           termin.PrezimeTrenera=trener.Prezime;
           termin.Datum=zaht.Datum;
           termin.VremePocetka=zaht.VremeOd;
           termin.VremeKraja=zaht.VremeDo;


           Context.Termini.Add(termin);
           await Context.SaveChangesAsync();

           ClanoviTermini clanTermin= new ClanoviTermini();
           clanTermin.ClanoviId=zahtev.ClanId;
           clanTermin.TerminId=termin.ID;
           Context.ClanoviTermini.Add(clanTermin);

         //  Context.Zahtevi.Remove(zahtev);
           zahtev.Prihvacen="Prihvaćen";
           clan.Clanarina.Iznos+=trening.Cena;
           await Context.SaveChangesAsync();



       }

    }
    
}
