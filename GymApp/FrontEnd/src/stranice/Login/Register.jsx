import React,{useState} from "react"
import loginImg from "./workout.svg"
import {useHistory,Link} from 'react-router-dom'
import LoadingSpin from '../../komponente/LoadingSpin'

export  function Register () {
  const history =useHistory();
  
  const handleHistory=()=>
  {
    history.push("/Dobrodosli")
  }
 
  const [ime,setIme] = useState("")
  const [prezime,setPrezime] = useState("")
  const [korisnickoIme,setKorisnickoIme] = useState("")
  const [email,setEmail] = useState("")
  const [sifra,setSifra] = useState("")
  const [potvrdaSifre,setPotvrdaSifre] = useState("")
  const [tip,setTip]=useState("")

  const [spin,setSpin]=useState(false)

  const [imeGreska,setImeGreska] = useState({})//prazan objekat
  const [prezimeGreska,setPrezimeGreska] = useState({})
  const [korisnickoImeGreska,setKorisnickoImeGreska] = useState({})
  const [korisnickoImeDuplikat,setKorisnickoImeDuplikat] = useState({})
  const [emailGreska,setEmailGreska] = useState({})
  const [emailDuplikat,setEmailDuplikat]=useState({})
  const [sifraGreska,setSifraGreska] = useState({})
  const [potvrdaSifreGreska,setPotvrdaSifreGreska] = useState({})
  const [tipGreska,setTipGreska]=useState({})
  
 
  
  
  const submit=(e)=>{
    setSpin(true)
    const validan=validacija()
    if(!validan)
    {
      setSpin(false)
    }
      else if(validan)
      {
          fetch("https://localhost:5001/Gym/RegisterKorisnik",{
      method:"POST",
      headers:{'Content-Type':'application/json'},
      body:JSON.stringify(
        {
          ime:ime,
          prezime:prezime,
          korisnickoIme:korisnickoIme,
          email:email,
          sifra:sifra,
          potvrdaSifre:potvrdaSifre,
          tip:tip
        }
      )
    }).then(p=>{
      setSpin(false)
      let val=true
      let val2=true
      if(p.ok)
      {
        console.log("Dodali ste novog clana.")
       
         
          handleHistory()
          
        
      }
      else if(p.status==400)
      {
       
         val=validacija2(p.status)
         val2=validacija3(p.status)

      }
      else if(p.status==409)
      {
        
        val=validacija2(p.status)
        val2=validacija3(p.status)
      }
     
     
    })
    

          

        }
      
      
    

  }
 const validacija=()=>
{
  const imeGreska={}
   let validno=true
  if(!ime)
  {
    
    imeGreska.PraznoPolje="Morate uneti va??e ime."
    
    validno=false
  }
  const prezimeGreska={}
  
  if(!prezime)
  {
    prezimeGreska.PraznoPoljePrezime="Morate uneti va??e prezime."
    validno=false
  }
  const emailGreska={}
  if(!email)
  {
    emailGreska.PraznoPoljeEmail="Morate uneti va?? email."
    validno=false
  }
  else if(!/\S+@\S+\.\S+/.test(email))
  {
    emailGreska.Forma="Email mora biti zadat u formi: email@domain.com"
    validno=false
  }
 
  const korisnickoImeGreska={}
  if(!korisnickoIme)
  {
    korisnickoImeGreska.PraznoPoljeKorisnickoIme="Morate uneti va??e korisni??ko ime."
    validno=false
  }
  else if(korisnickoIme.length<6)
  {
    korisnickoImeGreska.Duzina="Korisni??no ime mora imati bar 6 karaktera."
    validno=false
  }
 
  const sifraGreska={}
  if(!sifra)
  {
    sifraGreska.PraznoPoljeSifra="Morate uneti ??ifru."
    validno=false
  }
  else if(sifra.length<5)
  {
    sifraGreska.DuzinaSifre="??ifra mora imati bar 5 karaktera."
    validno=false
  }
  
  const potvrdaSifreGreska={}
  if(!potvrdaSifre)
  {
    potvrdaSifreGreska.PraznoPoljeSifrePotvrde="Morate uneti potvrdu ??ifre."
    validno=false
  }
  else if(potvrdaSifre!==sifra)
  {
    potvrdaSifreGreska.DuzinaPotvrde="??ifre se ne poklapaju."
    validno=false
  }
  const tipGreska={}
  if(!tip)
  {
    tipGreska.PraznoPoljeTip="Morate izabrati tip."
    validno=false
  }
  setImeGreska(imeGreska)
  setPrezimeGreska(prezimeGreska)
  setEmailGreska(emailGreska)
  setSifraGreska(sifraGreska)
  setPotvrdaSifreGreska(potvrdaSifreGreska)
  setKorisnickoImeGreska(korisnickoImeGreska)
  setTipGreska(tipGreska)
  setEmailDuplikat(emailDuplikat)
  setKorisnickoImeDuplikat(korisnickoImeDuplikat)
  return validno

}
const validacija2=(status)=>
{
  let validno2=true
  
  const emailDuplikat={}
  console.log(status)
  if(status==400)
  {

    
    emailDuplikat.Duplikat="Ovaj email ve?? postoji"
    validno2=false

  }
  setEmailDuplikat(emailDuplikat)
   
  return validno2

}
const validacija3=(status)=>
{
  let validno2=true
  
  const korisnickoImeDuplikat={}
  console.log(status)
  if(status==409)
  {

    
    korisnickoImeDuplikat.DuplikatIme="Ovo korisni??ko ime ve?? postoji"
    validno2=false

  }
  setKorisnickoImeDuplikat(korisnickoImeDuplikat)
   
  return validno2

}

   
    

    return (
       <form >
         <div className="base-container"/*ref={this.props.containerRef}*/ >
        <div className="header"> Pridru??i se na??em timu!</div>
        <div className="content">
          <div className="image">
            <img src={loginImg} alt="register" />
          </div>
          <div className="form">
          <div className="form-group">
              <label htmlFor="username">Ime</label>
              <input type="text" name="username" placeholder="Ime" onChange={e=>setIme(e.target.value)}/>
             {Object.keys(imeGreska).map((key)=>{
               return <div style={{color:"red"}}>{imeGreska[key]}</div>
             })}
            </div>
            <div className="form-group">
              <label htmlFor="username">Prezime</label>
              <input type="text" name="username" placeholder="Prezime" onChange={e=>setPrezime(e.target.value)}/>
              {Object.keys(prezimeGreska).map((key)=>{
               return <div style={{color:"red"}}>{prezimeGreska[key]}</div>
             })}
            </div>
            <div className="form-group">
              <label htmlFor="username">Korisni??ko ime</label>
              <input type="text" name="username" placeholder="Korisni??ko ime" onChange={e=>setKorisnickoIme(e.target.value)} />
              {Object.keys(korisnickoImeGreska).map((key)=>{
               return <div style={{color:"red"}}>{korisnickoImeGreska[key]}</div>
             })}
              {Object.keys(korisnickoImeDuplikat).map((key)=>{
               return <div style={{color:"red"}}>{korisnickoImeDuplikat[key]}</div>
             })}
            
            </div>
            <div className="form-group">
              <label htmlFor="username">Email</label>
              <input id='email'type="email" name="username" placeholder="Email" onChange={e=>setEmail(e.target.value)} />
              {Object.keys(emailGreska).map((key)=>{
               return <div style={{color:"red"}}>{emailGreska[key]}</div>
             })}
              {Object.keys(emailDuplikat).map((key)=>{
               return <div style={{color:"red"}}>{emailDuplikat[key]}</div>
             })}
            </div>
          
            <div className="form-group">
              <label htmlFor="password">??ifra</label>
              <input type="password" name="password" placeholder="??ifra" onChange={e=>setSifra(e.target.value)}/>
              {Object.keys(sifraGreska).map((key)=>{
               return <div style={{color:"red"}}>{sifraGreska[key]}</div>
             })}
            </div>
            <div className="form-group">
              <label htmlFor="password">Potvrdi ??ifru</label>
              <input type="password" name="password" placeholder="??ifra" onChange={e=>setPotvrdaSifre(e.target.value)}/>
              {Object.keys(potvrdaSifreGreska).map((key)=>{
               return <div style={{color:"red"}}>{potvrdaSifreGreska[key]}</div>
             })}
            </div>
            <div className="form-group">
              <label htmlFor="username">Registruj se kao:</label>
             <select onChange={(e)=>{
               const izabraniTip=e.target.value
               setTip(izabraniTip)
             }}>
               <option value='2'>Trener</option>
               <option value='3'>??lan teretane</option>
             </select>
             {Object.keys(tipGreska).map((key)=>{
               return <div style={{color:"red"}}>{tipGreska[key]}</div>
             })}

            </div>
          </div>
          {spin?<LoadingSpin/>:null}
        </div>
       
        <div className="form-group">
          <button type="button" className="btn" onClick={submit}  >
           Registruj se
          </button>
         
          <label className='labela'>Ve?? imate nalog? <Link to='/prijaviSe'  onClick={handleHistory}>
                     Prijavi se
               </Link></label>
        </div>
        
      </div>
      </form>
     
  
    );
  
}