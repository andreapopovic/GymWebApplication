import React,{useState,useEffect} from 'react'
import './Profil.css'
import {Button,Modal, Row,Table,Alert} from 'react-bootstrap'
//import { makeStyles } from '@material-ui/core/styles';
import LoadingSpin from '../../komponente/LoadingSpin'
import axios from 'axios'
import TimePicker from 'react-time-picker'
import DatePicker from 'react-datepicker'

import 'react-datepicker/dist/react-datepicker.css'
import {useHistory} from "react-router-dom"
 

function Profil(){
  const history=useHistory()
  const handleHistory=()=>
  {
    history.push("/Treninzi")
  }
   const [ime,setIme]=useState("")
   
   const [prezime,setPrezime]=useState("")
   const [godine,setGodine]=useState("")
   const [telefon,setTelefon]=useState("")
   const [email,setEmail]=useState("")
 //  const [visina,setVisina]=useState("")
 //  const [tezina,setTezina]=useState("")
   const [tip,setTip]=useState("")
 //  const [id,setId]=useState("")
   const [korisnickoIme,setKorisnickoIme]=useState("")
   const [modal,setModal]=useState(false) 
   const [spin,setSpin]=useState(false)

   const [zahteviTrenera,setZahteviTrenera]=useState({pod:[]})
   const [treninzi,setTreninge]=useState({pod:[]})
   const [termini,setTermini]=useState({pod:[]})
   const [zahteviClan,setZahteviClan]=useState({pod:[]})
  // const [terminiClana,setTerminiClana]=useState({pod:[]})
   
   const [profilnaIme,setProfilnaIme]=useState("")
   const [profilnaSrc,setProfilnaSrc]=useState('/slike/profil.jpg')
   const [profilnaFile,setProfilnaFile]=useState(null)

  
   const [prikazClan,setPrikazClan]=useState(false)
   const [prikazTrener,setPrikazTrener]=useState(false)
   const [prikazFormeZaIzborSlike,setPrikazFormeZaIzborSlike]=useState(false)
   const [prikazDugmetaIzmeniSliku,setPrikazDugmetaIzmeniSliku]=useState(true)
   const [iznosClanarine,setIznos]=useState("")
   const [placenaClanarina,setPlacenaClanarina]=useState(false)
   const [datumPlacanja,setDatumPlacanja]=useState("")

   const [maksBrojOsoba,setMaksBrojOsoba]=useState("")
 
   const [godineIzmena,setGodineIzmena]=useState("")
   const [telefonIzmena,setTelefonIzmena]=useState("")
   const [emailIzmena,setEmailIzmena]=useState("")
 
   const [placenaCl,setPlacenaCl]=useState(false)

  const [terminiClan,setTerminiClan]=useState({pod:[]})
   const [idIzmenaTreninga,setIdIzmenaTreninga]=useState("")
   const[imeTreninga,setImeTreninga]=useState("")
  const [modalZakaziTermin,setModalZakaziTermin]=useState(false)
  const [datum,setDatum]=useState(new Date())

  const [modalUspesnoZakazanTermin,setModalUspesnoZakazanTermin]=useState(false)
  const [modalZakazanTerminGreska,setModalZakazanTerminGreska]=useState(false)
  const [modalTermini,setModalTermini]=useState(false)
  const [modalPotvrdiOtkazivanje,setModalPotvrdiOtkazivanje]=useState(false)
 
  const[vremePocetak,setVremePocetak]=useState('10:00')
  const[vremeKraj,setVremeKraj]=useState('10:00')
  const [idTerminaOtkazivanje,setIdTerminaOtkazivanje]=useState("")
  const [modalUspesnoOtkazivanje,setModalUspesnoOtkazivanje]=useState(false)
  const [modalOtkazivanjeGreska,setModalOtkazivanjeGreska]=useState(false)
  const [modalZahteviTrenera,setModalZahteviTrenera]=useState(false)
  const [modalPrihvatiZahtev,setModalPrihvatiZahtev]=useState(false)
  const [probniTermin,setProbniTermin]=useState("")
  const options = {
    year: "2-digit",
    month:"2-digit",
    day:"2-digit"
    }
 
   const dodajTermin=()=>{
    
     let idTreninga=treninzi.pod.filter(p=>p.naziv==imeTreninga).map(tr=>tr.id).toString()
     
     setSpin(true)
     setModalZakaziTermin(false)
     fetch("https://localhost:5001/Gym/KreirajNoviTermin/"+idTreninga,{
      method:"POST",
      headers:{'Content-Type':'application/json'},
      body:JSON.stringify(
        {
          nazivTreninga:imeTreninga.toString(),
          korisnickoImeTr:korisnickoIme,
          imeTrenera:ime,
          prezimeTrenera:prezime,
          datum:datum.toLocaleDateString("en-US",options),
          vremePocetka:vremePocetak.toString(),
          vremeKraja:vremeKraj.toString(),
          trOsoba:0,
          maxOsoba:maksBrojOsoba
          
        }
      )
    }).then(p=>{
      setSpin(false)
      if(p.ok)
      {
        setModalUspesnoZakazanTermin(true)
      }
      else
      {
        setModalZakazanTerminGreska(true)
        
      }
    })
   }
   const obrisiZahtev=(id)=>{
   
    setSpin(true)
    fetch("https://localhost:5001/Gym/ObrisiZahtev/"+id,{
        method:"DELETE",
        headers:{'Content-Type':'application/json'},
        credentials:'include'
    }).then(p=>{
        setSpin(false)
        if(p.ok)
           {
              window.location.reload()
           }
          
    })

   }
   
   const prikaziTermine=(id)=>{
    setSpin(true)
    let naziv= treninzi.pod.filter(p=>p.id==id).map(tr=>tr.naziv).toString()
   
   fetch("https://localhost:5001/Gym/PreuzmiTermine/"+korisnickoIme+"/"+naziv).then(pod=>{
       pod.json().then(term=>{
          setSpin(false)
          setTermini({pod:term})
         
         
          
        })
   })
   setModalTermini(true)
}
 
const odbijZahtev=(id)=>{
  
  setSpin(true)
  fetch("https://localhost:5001/Gym/OdbijZahtev/"+localStorage.getItem("ID")+"/"+id,{
      method:"PUT",
      headers:{'Content-Type':'application/json'},
      credentials:'include'
  }).then(p=>{
      setSpin(false)
      if(p.ok)
         {
            setModalZahteviTrenera(false)
             setModalUspesnoOtkazivanje(true)
             
         }
         else
         {
            setModalOtkazivanjeGreska(true)
         }
  })
}
  
     
  useEffect(() => {
     
    const token=localStorage.getItem("jwt")
           
            fetch("https://localhost:5001/Gym/PreuzmiClana", {
                headers:{'Content-Type':'application/json',
                'Authorization':token},
                credentials:'include',
            }).then(korisnik=>{
    
               korisnik.json().then(podaci=>{
                  
                  localStorage.setItem("tip",podaci.tip)
                  
                   setIme(podaci.ime)
                   setPrezime(podaci.prezime)
                   setGodine(podaci.godine)
                   setTelefon(podaci.telefon)
                   setEmail(podaci.email)
                   setKorisnickoIme(podaci.korisnickoIme)
                   
                   setTip(podaci.tip)
              
                   localStorage.setItem("ID",podaci.id)
                   if(podaci.slika!=null)
                   {
                    setProfilnaSrc(podaci.slika)
                   }               
          
                   if(localStorage.getItem("tip")==3)
                   {
                     
                     
                     setPrikazClan(true)
                     setDatumPlacanja(podaci.clanarina.datumPoslednjegPlacanja)
                     setPlacenaCl(podaci.clanarina.placena)
                     setProbniTermin(podaci.probniTermin)
                     
                     
                     if(podaci.clanarina.placena==true)
                     setPlacenaClanarina("Jeste")
                
                     else 
                     setPlacenaClanarina("Nije")
                     setIznos(podaci.clanarina.iznos)
                  fetch("https://localhost:5001/Gym/PreuzmiTermineClana/"+localStorage.getItem("ID")).then(pod=>{
                   if(pod.ok)
                   {  
                   pod.json().then(termini=>{
                      
                         setTerminiClan({pod:termini})
                         
                       })
                    }
                  })
                  fetch("https://localhost:5001/Gym/PreuzmiZahteveClana/"+localStorage.getItem("ID")).then(pod=>{
                   if(pod.ok)
                   {  
                   pod.json().then(termini=>{
                      
                         setZahteviClan({pod:termini})
                         
                       })
                    }
                  })

                   }
                   else if(localStorage.getItem("tip")==2)
                   {
                    
                     fetch("https://localhost:5001/Gym/PreuzmiTreningeTrenera/"+localStorage.getItem("ID")).then(p=>{
                       if(p.ok)
                       {
                         p.json().then(trening=>{
                          
                           setTreninge({pod:trening})
                           setPrikazTrener(true)
                           
                         })
                       }
                     })
                                   
                   }       
               })
          })
         
   
  },[])
  const otkaziTerminKorisnik=(id)=>{
    setSpin(true)
    setModalPotvrdiOtkazivanje(false)
    fetch("https://localhost:5001/Gym/OtkaziTermin/"+localStorage.getItem("ID")+"/"+idTerminaOtkazivanje,{
      method:"DELETE",
      headers:{'Content-Type':'application/json'},
      credentials:'include'
  }).then(p=>{
      setSpin(false)
      if(p.ok)
         {
          setModalUspesnoOtkazivanje(true)
         window.location.reload()
         }
         else
         {
             setModalOtkazivanjeGreska(true)
         }
  })

  }
  const otkaziTerminTrener=(id)=>{
    setSpin(true)
    setModalPotvrdiOtkazivanje(false)
    console.log(idTerminaOtkazivanje)
    fetch("https://localhost:5001/Gym/ObrisiTermin/"+idTerminaOtkazivanje,{
      method:"DELETE",
      headers:{'Content-Type':'application/json'},
      credentials:'include'
  }).then(p=>{
      setSpin(false)
      if(p.ok)
         {
          setModalUspesnoOtkazivanje(true)
             setModalTermini(false)
         }
         else
         {
             setModalOtkazivanjeGreska(true)
         }
      
  })
 }
  const potvrdiOtkazivanje=(id)=>{
    setIdTerminaOtkazivanje(id)
    setModalPotvrdiOtkazivanje(true)
  }
  
    
  const izmeni=(e)=>{
      setModal(false) 
      setSpin(true)
      console.log(tip)
      if(tip==3)
      {

          
        fetch("https://localhost:5001/Gym/IzmeniClana/"+localStorage.getItem("ID"),{
            method:"PUT",
            headers:{'Content-Type':'application/json'},
            credentials:'include',
            body:JSON.stringify(
              {
               
                ime:ime,
                prezime:prezime,
                godine:godineIzmena,
                email:email,
                telefon:telefonIzmena,
                
              }
            )
          }).then(p=>{
            setSpin(false)
              if(p.ok)
              {
                  
                  window.location.reload()
                  
              }
          })
      }
      else if(tip==2)
      {
        fetch("https://localhost:5001/Gym/IzmeniTrenera/"+localStorage.getItem("ID"),{
            method:"PUT",
            headers:{'Content-Type':'application/json'},
            credentials:'include',
            body:JSON.stringify(
              {
               
                ime:ime,
                prezime:prezime,
                godine:godineIzmena,
                email:email,
                telefon:telefonIzmena
               
              }
            )
          }).then(p=>{
            setSpin(false)
            if(p.ok)
            {
                window.location.reload()
            }
        })

      }
      else if(tip==1)
      {
        fetch("https://localhost:5001/Gym/IzmeniAdministratora/"+localStorage.getItem("ID"),{
            method:"PUT",
            headers:{'Content-Type':'application/json'},
            credentials:'include',
            body:JSON.stringify(
              {
               
                ime:ime,
                prezime:prezime,
                godine:godineIzmena,
                email:email,
                telefon:telefonIzmena
               
              }
            )
          }).then(p=>{
            setSpin(false)
            if(p.ok)
            {
                window.location.reload()
            }
        })

      }
    
  }
 
   const izmeniSliku=(e)=>{
     if(e.target.files && e.target.files[0])
     {
       let imgFile=e.target.files[0]
       const reader= new FileReader()
       reader.onload=x=>{
         
         setProfilnaSrc(x.target.result)
       }
       reader.readAsDataURL(imgFile)
       setProfilnaFile(imgFile)
       setProfilnaIme(imgFile.name)
     }

   }
   const izmeniTrajnoSliku=()=>{

    const formData=new FormData()
    formData.append("profilnaFile",profilnaFile)
    
    setSpin(true)
 
      axios.put("https://localhost:5001/Gym/IzmeniSliku/"+korisnickoIme,formData).then(p=>{
        if(p!=null)
        {
          setSpin(false)
        
         setPrikazDugmetaIzmeniSliku(true)
         setPrikazFormeZaIzborSlike(false) 
        }
      })
        

   }
   const podaciZaIzmenuTreninga=(id)=>{
    const trening=treninzi.pod.filter(p=>p.id===id)
     setIdIzmenaTreninga(id)
     setImeTreninga(trening.map((pod)=>pod.naziv))
     setModalZakaziTermin(true)
   }
   const izmeniDatum=datum=>{
     setDatum(datum)
   }
   const preuzmiZahteve=()=>{
    setSpin(true)
    
   fetch("https://localhost:5001/Gym/PreuzmiZahteveTrenera/"+localStorage.getItem("ID")).then(pod=>{
       pod.json().then(term=>{
          setSpin(false)
          setZahteviTrenera({pod:term})
         
          
         
          
        })
   })
   setModalZahteviTrenera(true)
     
   }
   const prihvatiZahtev=(id)=>{
     console.log(id)
     console.log(datum.toLocaleDateString("en-US",options))
     console.log(vremePocetak)
     console.log(vremeKraj)
    setSpin(true)
 /*   fetch("https://localhost:5001/Gym/PrihvatiZahtev/"+localStorage.getItem("ID")+"/"+id+"/"+datum.toLocaleDateString("en-US",options)+"/"+vremePocetak+"/"+vremeKraj,{
      method:"POST",
      headers:{'Content-Type':'application/json'}
   }).then(p=>{
     setSpin(false)
     setModalZahteviTrenera(false)
   })*/
   fetch("https://localhost:5001/Gym/PrihvatiZahtev/"+id,{
      method:"POST",
      headers:{'Content-Type':'application/json'},
      body:JSON.stringify(
        {
          datum:datum.toLocaleDateString("en-US",options),
          treningId:1,
          trenerId:localStorage.getItem("ID"),
          clanId:localStorage.getItem("ID"),
          vremeOd:vremePocetak.toString(),
          vremeDo:vremeKraj.toString(),
        
          
        }
      )
   }).then(p=>{
     setSpin(false)
     setModalZahteviTrenera(false)
   })
   }

    return(
        <div className='glavniDivProfil'>
          <div className='pomocniDivProfilll'>         
             <div className='pomocniDivProfil'>
           <img className='profilnaSlika' src={profilnaSrc} alt='profilna'/>
        {prikazFormeZaIzborSlike? 
           <input type='file'
         placeholder='Izaberi sliku'
         id='profilnaSlika'
          className='form-control-file chooseFile' onChange={izmeniSliku}/>:null}
          {prikazFormeZaIzborSlike?<Button className='btn btn-info btnIzmeniSliku'
          onClick={()=> izmeniTrajnoSliku()}>Sacuvaj izmenu</Button>:null}
          {prikazDugmetaIzmeniSliku? <Button className='btn btn-info btnIzmeniSliku' 
          onClick={()=>{setPrikazFormeZaIzborSlike(true) ;setPrikazDugmetaIzmeniSliku(false)}}>Izmeni sliku</Button>:null}
           <label>Ime: <label className='pomInfo'>{ime}</label></label>
           <label>Prezime: <label className='pomInfo'>{prezime}</label></label>
           <label>Godine: <label className='pomInfo'>{godine}</label> </label>
           <label>Broj telefona: <label className='pomInfo'>{telefon}</label> </label>
           <label>Email: <label className='pomInfo'>{email}</label></label>
          {godine==0 || telefon==null? <label style={{color:'red'}}>Molimo Vas da unesete sve podatke o sebi.</label>:null } 
          
           <Button className='btn btn-success dugmIzmeni' onClick={()=>setModal(true)}>Izmeni podatke</Button>
          
           {spin?<LoadingSpin/>:null}
           
         


        </div>
       {prikazClan? <div className='divClanarina'>
       <label className='naslovEvidencija'>Evidencija članarine</label>
        <Table striped bordered hover size="sm">
        
  <tbody>
    <tr>
      <td>Poslednji put plaćena</td>
      <td>{datumPlacanja}</td>
    
    </tr>
    <tr>
      <td>Trenutni iznos</td>
      <td>{iznosClanarine}</td>
     
    </tr>
    <tr>
      <td>Izmireno zaduženje za ovaj mesec</td>
      <td className={placenaCl?'placenaClanarina':'nijePlacena'}>{placenaClanarina}</td>
      
    </tr>
  </tbody>
</Table >
{placenaCl==false && probniTermin==false ?<Row style={{color:'red'}}>*Molimo vas da platite članarinu jer u suprotnom nećete moći da zakažete novi termin.</Row>:null}
{placenaCl==false && probniTermin==true ?<Row style={{color:'green'}}>*Iskoristite mogućnost i zakažite prvi probni besplatni trening.</Row>:null}
<label className='naslovEvidencija' style={{marginTop:"50px"}}>Vaši zakazani termini</label>
        <Table striped bordered hover size="sm">
        <thead>
          <tr>
            <td>Naziv treninga</td>
            <td>Datum</td>
            <td>Početak</td>
            <td>Kraj</td>
            <td>Ime trenera</td>
            <td>Prezime trenera</td>
          </tr>
        </thead>
  <tbody>
   { 
   terminiClan.pod.filter(obj=>obj!=null).map((termin)=>(
     
     <tr key={termin.id}>
       
      <td>{termin.nazivTreninga}</td>
      <td>{termin.datum}</td>
      <td>{termin.vremePocetka}</td>
      <td>{termin.vremeKraja}</td>
      <td>{termin.imeTrenera}</td>
      <td>{termin.prezimeTrenera}</td>
      <td><Button variant='danger' onClick={()=>potvrdiOtkazivanje(termin.id)} >Otkaži termin</Button></td>
     
    </tr>

   ))
    }
   
  </tbody>
</Table>
{probniTermin==true?<Button onClick={handleHistory}>Zakaži besplatni termin</Button>:<Button onClick={handleHistory}>Zakaži novi termin</Button>} 
 <label className='naslovEvidencija' style={{marginTop:"50px"}}>Vaši poslati zahtevi </label>
        <Table striped bordered hover size="sm">
        <thead>
          <tr>
            <td>Naziv treninga</td>
            <td>Datum</td>
            <td>Od:</td>
            <td>Do:</td>
            <td>Ime trenera</td>
            <td>Prezime trenera</td>
            <td>Status:</td>
          </tr>
        </thead>
  <tbody>
   { 
   zahteviClan.pod.filter(obj=>obj!=null).map((zahtev)=>(
     
     <tr key={zahtev.id}>
       
      <td>Personalni trening</td>
      <td>{zahtev.datum}</td>
      <td>{zahtev.vremeOd}</td>
      <td>{zahtev.vremeDo}</td>
      <td>{zahtev.trenerIme}</td>
      <td>{zahtev.trenerPrezime}</td>
    {zahtev.prihvacen=='Odbijen'?<td style={{color:'red'}}>{zahtev.prihvacen}</td>:null}
    {zahtev.prihvacen=='Prihvaćen'?<td style={{color:'green'}}>{zahtev.prihvacen}</td>:null} 
    {zahtev.prihvacen=='Čekanje potvrde'?<td style={{color:'blue'}}>{zahtev.prihvacen}</td>:null} 
      <td><Button onClick={()=>obrisiZahtev(zahtev.id)}>Obriši</Button></td>
     
    </tr>

   ))
    }
   
  </tbody>
</Table>

        </div>:null}





        {prikazTrener? <div className='divClanarina'>
       <label className='naslovEvidencija'>Vaši treninzi</label>
       
        <Table striped bordered hover size="sm">
     <tbody>
    {treninzi.pod.map((trening)=>(
      <tr key={trening.id}>
      <td>{trening.naziv}</td>
    {trening.naziv=='Personalni trening'? <td><Button onClick={preuzmiZahteve}>Prikaži zahteve</Button></td>:<td><Button onClick={()=>podaciZaIzmenuTreninga(trening.id)}>Zakaži novi termin</Button></td>}
      <td><Button  onClick={()=>prikaziTermine(trening.id)}>Prikazi termine</Button></td>
      <td><Button className='btn btn-danger'>Obrisi</Button></td>

    </tr>

    )
    
  )}
    
    

  </tbody>
</Table>
        </div>:null}

     
        </div>
       
        <Modal show={modalUspesnoZakazanTermin}>
              <Modal.Header >Uspešno brisanje</Modal.Header>
              <Modal.Body>
              <Alert className='alert alert-success'>Uspešno ste zakazali novi termin<i className="far fa-check-circle ikonica"></i></Alert>
             </Modal.Body>
              <Modal.Footer>
                  <Button onClick={()=>setModalUspesnoZakazanTermin(false)}>Ok</Button>
              </Modal.Footer>
          </Modal>

          <Modal show={modalZakazanTerminGreska}>
              <Modal.Header >Greška</Modal.Header>
              <Modal.Body>
              <Alert className='alert alert-danger'>Žao nam je, došlo je do greške prilikom zakazivanja termina.Molimo Vas pokušajte ponovo.</Alert>
             </Modal.Body>
              <Modal.Footer>
                  <Button onClick={()=>setModalZakazanTerminGreska(false) }>Ok</Button>
              </Modal.Footer>
          </Modal>
          <Modal show={modalPotvrdiOtkazivanje}>
              
              <Modal.Body>
              <Alert className='alert alert-info'>Da li ste sigurni da želite da otkažetr ovaj termin?</Alert>
             </Modal.Body>
              <Modal.Footer>
               { localStorage.getItem("tip")=='3'?<Button onClick={otkaziTerminKorisnik}  >Potvrdi</Button>:null}
               { localStorage.getItem("tip")=='2'?<Button onClick={otkaziTerminTrener}  >Potvrdi</Button>:null}
                  <Button onClick={()=>setModalPotvrdiOtkazivanje(false)}>Poništi</Button>
              </Modal.Footer>
          </Modal>

          <Modal show={modalTermini}>
        
          <Modal.Header>Termini</Modal.Header> 
              <Modal.Body>
                  {
                   termini.pod.map((termin)=>(
                        <div key={termin.id} className='divModal'>
                          

                            <Row>Datum: {termin.datum}</Row>
                            <Row>Vreme pocetka: {termin.vremePocetka} </Row>
                            <Row>Vreme kraja: {termin.vremeKraja}</Row>
                           
                         
                           {termin.nazivTreninga== 'Personalni trening' ? null : <Row>Trenutni broj ljudi: {termin.trOsoba}</Row>} 
                          
                           {termin.nazivTreninga== 'Personalni trening' ? null : <Row>Maksimalni broj ljudi: {termin.maxOsoba} </Row>}
                            <Row><Button className='btn-danger' onClick={()=>potvrdiOtkazivanje(termin.id)}>Otkaži</Button></Row>

                        </div>
                    ))
                  }
              
             </Modal.Body>
             <Modal.Footer>
                  <Button onClick={()=>setModalTermini(false) }>Ok</Button>
              </Modal.Footer>
             </Modal>
             <Modal show={modalUspesnoOtkazivanje}>
              <Modal.Header >Uspešno brisanje</Modal.Header>
              <Modal.Body>
              <Alert className='alert alert-success'>Uspešno ste otkazali ovaj termin<i className="far fa-check-circle ikonica"></i></Alert>
             </Modal.Body>
              <Modal.Footer>
                  <Button onClick={()=>setModalUspesnoOtkazivanje(false)}>Ok</Button>
              </Modal.Footer>
          </Modal>

          <Modal show={modalOtkazivanjeGreska}>
              <Modal.Header >Greška</Modal.Header>
              <Modal.Body>
              <Alert className='alert alert-danger'>Žao nam je, došlo je do greške prilikom otkazivanja termina.Molimo Vas pokušajte ponovo.</Alert>
             </Modal.Body>
              <Modal.Footer>
                  <Button onClick={()=>setModalOtkazivanjeGreska(false) }>Ok</Button>
              </Modal.Footer>
          </Modal>
          <Modal show={modal}>
               <Modal.Header >Izmenite podatke o sebi</Modal.Header>
               <Modal.Body>
               <Row>Ime: <input className='unosIzmena' defaultValue={ime} disabled /></Row>
               <Row>Prezime: <input className='unosIzmena' defaultValue={prezime} disabled /></Row>
               <Row>Godine: <input className='unosIzmena' defaultValue={godine}  onChange={e=>setGodineIzmena(e.target.value)}/></Row>
               <Row>Broj telefona: <input className='unosIzmena' defaultValue={telefon}  onChange={e=>setTelefonIzmena(e.target.value)}/></Row>
               <Row>Email: <input className='unosIzmena' defaultValue={email}  onChange={e=>setEmailIzmena(e.target.value)}/></Row>
               </Modal.Body>
               <Modal.Footer>
                   <Button onClick={izmeni}>Potvrdi</Button>
                   <Button onClick={()=>setModal(false)}>Poništi</Button>
               </Modal.Footer>
           </Modal>
           <Modal show={modalZakaziTermin}>
               <Modal.Header >Zakaži novi termin</Modal.Header>
               <Modal.Body>
               <Row className='redZakazi'>Naziv treninga: <h5 style={{color:"blue"}}>{imeTreninga}</h5></Row>
              <Row>Datum:</Row>
              <Row>
              <DatePicker
               closeOnScroll={true}
               selected={datum}
               onChange={(date) => setDatum(date)}
                />
               </Row>
              

               <Row>Od:</Row> 
               <Row>     
                <TimePicker
                 onChange={(vreme)=>setVremePocetak(vreme)}
                value={vremePocetak}
                timeIntervals={30}
                 />
                </Row>
                 
                 <Row>Do:</Row>
                 <Row>
                   <TimePicker
                 onChange={(vreme)=>setVremeKraj(vreme)}
                 value={vremeKraj}
                 timeIntervals={30}
                  />
                 </Row>
                
                 <Row>Maksimalni broj osoba:</Row>
                 <Row>
                   <input type='number' onChange={e=>setMaksBrojOsoba(e.target.value)}></input>
                 </Row>

               </Modal.Body>
               <Modal.Footer>
                   <Button onClick={()=>dodajTermin()}>Potvrdi</Button>
                   <Button onClick={()=>setModalZakaziTermin(false)}>Poništi</Button>
               </Modal.Footer>
           </Modal>
           <Modal show={modalZahteviTrenera}>
        
        <Modal.Header>Zahtevi</Modal.Header> 
            <Modal.Body>
                {
                 zahteviTrenera.pod.map((zahtev)=>(
                      <div key={zahtev.id} className='divModal'>
                        
                           <Row>Član: {zahtev.clanIme} {zahtev.clanPrezime}</Row>
                          <Row>Datum: {zahtev.datum}</Row>
                          <Row>Vreme od: {zahtev.vremeOd} </Row>
                          <Row>Vreme do: {zahtev.vremeDo}</Row>
                          <Row style={{marginBottom:'10px'}}>Opis: {zahtev.opis}</Row>
                          <Row style={{color:'blue'}}>* U slučaju da Vam odgovara ovaj termin izaberite datum i vreme i prihvatite zahtev.</Row>
                          <Row>Datum:</Row>
              <Row>
              <DatePicker
               closeOnScroll={true}
               selected={datum}
               onChange={(date) => setDatum(date)}
                />
               </Row>
              

               <Row>Od:</Row> 
               <Row>     
                <TimePicker
                 onChange={(vreme)=>setVremePocetak(vreme)}
                value={vremePocetak}
                timeIntervals={30}
                 />
                </Row>
                 
                 <Row>Do:</Row>
                 <Row>
                   <TimePicker
                 onChange={(vreme)=>setVremeKraj(vreme)}
                 value={vremeKraj}
                 timeIntervals={30}
                  />
                 </Row>
                


                           <Row className='redDugmiciPrihvOtkazi'><Button onClick={()=>prihvatiZahtev(zahtev.id)}>Prihvati</Button><Button onClick={()=>odbijZahtev(zahtev.id)}>Odbij</Button></Row>
                          

                      </div>
                  ))
                }
            
           </Modal.Body>
           <Modal.Footer>
                <Button onClick={()=>setModalZahteviTrenera(false) }>Ok</Button>
            </Modal.Footer>
           </Modal>
           



          
          
           

  

        </div>
    )
}
export default Profil