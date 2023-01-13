import React,{useState,useEffect,useMemo} from 'react'
import PaginationComponent from '../../komponente/PaginationComponent'
import {Table,Button,Modal,Alert,Row} from 'react-bootstrap'
import TimePicker from 'react-time-picker'
import DatePicker from 'react-datepicker'
import LoadingSpin from '../../komponente/LoadingSpin'
import Search from '../../komponente/Search'
import './Treninzi.css'
export default function Treninzi() {
    const [podaci,setPodaci]=useState({pod:[]})
    const [treneri,setTreneri]=useState({pod:[]})
    const [termini,setTermini]=useState({pod:[]})
    const [spin,setSpin]=useState(false)


    const [ukupnoStavki,setUkupnoStavki]=useState(0)
    const [trStranica,setTrStranica]=useState(1)
    const [pretrazi,setPretrazi] =useState("")
    const STAVKE_PO_STRANICI=5

    const [modalUspesnoBrisanje,setModalUspesnoBrisanje]=useState(false)
    const [modalBrisanjeGreska,setModalBrisanjeGreska]=useState(false)
    const [modalObrisi,setModalObrisi]=useState(false)

    const [modalUspesnoZakazivanjeClan,setModalUspesnoZakazivanjeClan]=useState(false)
    const [modalZakazivanjeGreskaBroj,setModalZakazivanjeGreskaBroj]=useState(false)
    const [modalZakazivanjeGreskaClanarina,setModalZakazivanjeGreskaClanarina]=useState(false)
    const [modalPosaljiZahtev,setModalPosaljiZahtev]=useState(false)


    const [idBrisanje,setIdBrisanje]=useState("")

    const [modalDodajTrening,setModalDodajTrening]=useState(false)

    const [naziv,setNaziv]= useState("")
    const [tip,setTip]= useState("")
    const [cena,setCena] =useState("")

    const [prikazClan,setPrikazClan]=useState(false)

    const [validacijaNaziv,setValidacijaNaziv]=useState(false)
    const [validacijaCena,setValidacijaCena]=useState(false)
    const [validacijaTip,setValidacijaTip]=useState(false)
    
    
    const [modalUspesnoDodavanje,setModalUspesnoDodavanje]=useState(false)
    const [modalDodavanjeGreska,setModalDodavanjeGreska] =useState(false)

    const [idIzmena,setIdIzmena]=useState("")
    const [cenaIzmena,setCenaIzmena]=useState("")
    const [trCena,setTrCena]=useState("")
    const [modalIzmeni,setModalIzmeni]=useState(false)
    const [tipIzmena,setTipIzmena]=useState("")
    const [nazivIzmena,setNazivIzmena]=useState("")
    const [prikaziAdmin,setPrikaziAdmin]=useState(false)

    const [modalTreneri,setModalTreneri]=useState(false)
    const [modalTermini,setModalTermini]=useState(false)
    const [modalUspesnoPoslatZahtev,setModalUspesnoPoslatZahtev]=useState(false)
    const [modalPoslatZahtevGreska,setModalPoslatZahtevGreska]=useState(false)

    const [datum,setDatum]=useState("")
    const [vremePocetak,setVremePocetak]=useState("")
    const [vremeKraj,setVremeKraj]=useState("")
    const[trenerZahtev,setTrenerZahtev]=useState("")
    const[opisZahteva,setOpisZahteva]=useState("")
    const [trenerZahtevaId,setTrenerZahtevaId]=useState("")
    useEffect(() => {
        
           
        
        fetch("https://localhost:5001/Gym/PreuzmiTreninge").then(pod=>{
            pod.json().then(treninzi=>{
               
                setPodaci({pod:treninzi})
                setUkupnoStavki(podaci.pod.length)
                let tip=localStorage.getItem("tip")
                if(tip==1)
                {
                    setPrikaziAdmin(true)
                }
             })
        })
        console.log(localStorage.getItem("tip"))
        if(localStorage.getItem("tip")==3)
        {
            setPrikazClan(true)
        }
        else
        {
            setPrikazClan(false)
        }
        
     },[])
     const sviTreninzi=useMemo(()=>{

        let obv=podaci.pod;
        
        if(pretrazi)
        {
            obv=obv.filter(
                obav=>
                obav.naziv.toLowerCase().includes(pretrazi.toLowerCase()) ||
                obav.tip.toLowerCase().includes(pretrazi.toLowerCase())
            )
        }
        setUkupnoStavki(obv.length)
        return obv.slice((trStranica-1)*STAVKE_PO_STRANICI,(trStranica-1)*STAVKE_PO_STRANICI+STAVKE_PO_STRANICI)
     },[podaci,trStranica,pretrazi])
     const izmeniCenuModal=(id)=> {
         
        
        setIdIzmena(id)
        const trening=podaci.pod.filter(p=>p.id===id)
         setNazivIzmena(trening.map((pod)=>pod.naziv))
         setTipIzmena(trening.map((pod)=>pod.tip))
         setTrCena(trening.map((pod)=>pod.cena))
       
        setModalIzmeni(true)    
  }
  const izmeniCenuTreninga=()=>
  {
      
      setModalIzmeni(false)
      setSpin(true)
      fetch("https://localhost:5001/Gym/IzmeniCenuTreninga/"+idIzmena+"/"+cenaIzmena,{
            method:"PUT",
            headers:{'Content-Type':'application/json'},
            credentials:'include'
      }).then(p=>{
          setSpin(false)
          window.location.reload()
      })

  }
  
  const potvrdiBrisanje=(id)=> {
         
    setModalObrisi(true)
    setIdBrisanje(id)

  }
  const obrisiClana=()=>
     {
         setModalObrisi(false)
         setSpin(true)
         fetch("https://localhost:5001/Gym/ObrisiTrening/"+idBrisanje,{
             method:"DELETE",
             headers:{'Content-Type':'application/json'},
             credentials:'include'
         }).then(p=>{
             setSpin(false)
             if(p.ok)
                {
                    setModalUspesnoBrisanje(true)
                }
                else
                {
                   setModalBrisanjeGreska(true)
                }
         })

     }
  const uspesnoBrisanje=()=>{
    setModalUspesnoBrisanje(false)
    window.location.reload()
}
const dodajNoviTrening=()=>{
    console.log(naziv,cena,tip)
    if(!naziv)
    {
        setValidacijaNaziv(true)
    }
    else if(!cena)
    {
        setValidacijaCena(true)
    }
    else if(!tip)
    {
        setValidacijaTip(true)
    }
    else
    {
        let noviTip=''
        setModalDodajTrening(false)
        setValidacijaTip(false)
        setValidacijaCena(false)
        setValidacijaNaziv(false)
        if(tip==0)
        {
            console.log("Grupni je tip")
            noviTip='Grupni'
            console.log(noviTip)
        }
        else if(tip==1)
        {
           noviTip='Idividualni'
        }
        console.log(tipIzmena)
          setSpin(true)
        fetch("https://localhost:5001/Gym/DodajTrening",{
            method:"POST",
            headers:{'Content-Type':'application/json'},
            body:JSON.stringify(
              {
                naziv:naziv,
                tip:noviTip,
                cena:cena
              }
            )
          }).then(p=>{
            setSpin(false)
              if(p.ok)
              {
                 
                  setModalUspesnoDodavanje(true)
              }
              else
              {
                  setModalDodavanjeGreska(true)

              }
          })

    }
}

const [treneriPersonal,setTreneriPersonal]=useState({pod:[]})
const prikaziModalZakaziTrening=()=>{

    fetch("https://localhost:5001/Gym/PreuzmiTrenereTreninga/1").then(p=>{
        p.json().then(treneri=>{
          setTreneriPersonal({pod:treneri})
        })
       
        
    })
    
    setModalPosaljiZahtev(true)
    }
    const posaljiZahtev=()=>{
        
     
        setSpin(true)
        fetch("https://localhost:5001/Gym/PosaljiZahtevTreneru/"+trenerZahtev.split(' ')[0],{
         method:"POST",
         headers:{'Content-Type':'application/json'},
         body:JSON.stringify(
           {
             datum:datum.toLocaleDateString("en-US",options),
             treningId:1,
             trenerId:trenerZahtev.split(' ')[0],
             trenerIme: trenerZahtev.split(' ')[1],
            trenerPrezime: trenerZahtev.split(' ')[2],
             clanId:localStorage.getItem("ID"),
             vremeOd:vremePocetak.toString(),
             vremeDo:vremeKraj.toString(),
             opis:opisZahteva
             
           }
         )
       }).then(p=>{
         setSpin(false)
         if(p.ok)
         {
           setModalUspesnoPoslatZahtev(true)
         }
         else if(p.status==451)
         {
            setModalZakazivanjeGreskaClanarina(true)
         }
        else
         {
           setModalPoslatZahtevGreska(true)
           
         }
       })
    }
    const options = {
        year: "2-digit",
        month:"2-digit",
        day:"2-digit"
        }

const uspesnoDodavanje=()=>{
    setModalUspesnoDodavanje(false)
    window.location.reload()
}
 const prikaziTrenere=(id)=>{
     setSpin(true)
    fetch("https://localhost:5001/Gym/PreuzmiTrenereTreninga/"+id).then(pod=>{
        pod.json().then(treneri=>{
           setSpin(false)
           setTreneri({pod:treneri})
           setModalTreneri(true)
           
         })
    })
 }
 const prikaziTermine=(id)=>{
    setSpin(true)
    let naziv= podaci.pod.filter(p=>p.id==id).map(tr=>tr.naziv).toString()
   fetch("https://localhost:5001/Gym/PreuzmiTermine/"+naziv).then(pod=>{
       pod.json().then(termini=>{
          setSpin(false)
          setTermini({pod:termini})
          setModalTermini(true)
          
        })
   })
}
const zakaziTermin=(terminId)=>{
    setSpin(true)
    fetch("https://localhost:5001/Gym/DodajTermineClanova/"+terminId+"/"+localStorage.getItem("ID"),{
        method:"POST",
        headers:{'Content-Type':'application/json'}
   }).then(p=>{
       setSpin(false)
       setModalTermini(false)
       if(p.ok)
       {
           setModalUspesnoZakazivanjeClan(true)

       }
       else if(p.status==451)
       {
           setModalZakazivanjeGreskaClanarina(true)

       }
       else if(p.status==452)
       {
           setModalZakazivanjeGreskaBroj(true)

       }
   })
}
const uspesnoZakazivanje=()=>{
    setModalUspesnoZakazivanjeClan(false)
       
}
    

    return (
        <div>
           
            <Search 
             pretrazi={(value)=>{
               setPretrazi(value)
               setTrStranica(1)
           }}/>
            <div className='pomRedDodajTrening'>
          <PaginationComponent
            ukupno={ukupnoStavki}
            stavkePoStranici={STAVKE_PO_STRANICI}
            trenutnaStranica={trStranica}
            promeniStranicu={page=>setTrStranica(page)}/>
          
          {prikaziAdmin?
          <Button onClick={()=>setModalDodajTrening(true)}>Dodaj novi trening</Button>:null}
           </div>
            
  <Table striped bordered hover >
  <thead>
    <tr>
      <th>ID</th>
      <th>Naziv</th>
      <th>Tip</th>
      <th>Cena</th>
      
    </tr>
  </thead>
  <tbody>
      {
        sviTreninzi.map((trening)=>(
            <tr key={trening.id}>
            <td>{trening.id}</td>
            <td>{trening.naziv}</td>
            <td>{trening.tip}</td>
            <td>{trening.cena}</td>
        <td><Button onClick={()=>prikaziTrenere(trening.id)}>Prikaži trenere</Button></td>
  {trening.naziv=='Personalni trening' && localStorage.getItem("tip")=='3'?  <td><Button onClick={()=>prikaziModalZakaziTrening()} >Pošalji zahtev treneru</Button></td>:  <td><Button onClick={()=>prikaziTermine(trening.id)}>Prikaži termine</Button></td>}    
       
        {prikaziAdmin?<td><Button onClick={()=>izmeniCenuModal(trening.id)}>Izmeni</Button></td>:null}
        {prikaziAdmin? <td><Button className='btn btn-danger'  onClick={()=>potvrdiBrisanje(trening.id)}>Obriši</Button></td>:null}
        
          </tr>
          ))
      }
   
  </tbody>
</Table>
        <Modal show={modalTreneri}>
          <Modal.Header>Treneri</Modal.Header> 
              <Modal.Body>
                  {
                    treneri.pod.map((trener)=>(
                        <div key={trener.id} className='divModal'>
                             <img className='profilnaSlikaTrenera' src={trener.slika} alt='profilna'/>
                            <Row>Ime: {trener.ime} </Row>
                            <Row>Prezime: {trener.prezime} </Row>
                            <Row>Email: {trener.email} </Row>

                        </div>
                    ))
                  }
              
             </Modal.Body>
              <Modal.Footer>
                 
                  <Button onClick={()=>setModalTreneri(false)}>Ok</Button>
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
                            <Row>Ime trenera:{termin.imeTrenera}</Row>
                            <Row>Prezime trenera:{termin.prezimeTrenera}</Row>
                            {prikazClan? <Row><Button onClick={()=>zakaziTermin(termin.id)}>Zakazi termin</Button></Row>:null}

                        </div>
                    ))
                  }
              
             </Modal.Body>
              <Modal.Footer>
                 
                  <Button onClick={()=>setModalTermini(false)}>Ok</Button>
              </Modal.Footer>
          </Modal>
         <Modal show={modalIzmeni}>
          <Modal.Header>Izmeni cenu treninga</Modal.Header> 
              <Modal.Body>
              <Row>Naziv: <input className='unosIzmena' defaultValue={nazivIzmena} disabled /></Row>
              <Row>Tip: <input className='unosIzmena' defaultValue={tipIzmena} disabled /></Row>
              <Row>Cena: <input className='unosIzmena' defaultValue={trCena}
               onChange={(e)=>{
                const novaCena=e.target.value
                setCenaIzmena(novaCena)  
              }}/>
                </Row>
    
             </Modal.Body>
              <Modal.Footer>
                  <Button onClick={()=>izmeniCenuTreninga() }>Potvrdi</Button>
                  <Button onClick={()=>setModalIzmeni(false)}>Poništi</Button>
              </Modal.Footer>
          </Modal>

          <Modal show={modalDodajTrening}>
          <Modal.Header>Dodaj novi trening</Modal.Header> 
              <Modal.Body>
              <Row>Naziv: <input  className='unosIzmena' onChange={e=>setNaziv(e.target.value)} /></Row>
              {validacijaNaziv?<Row style={{color:'red'}} className='redValidacija' >Morate uneti naziv.</Row>:null}
              <Row>Cena: <input className='unosIzmena' onChange={e=>setCena(e.target.value)}/> </Row>
              {validacijaCena?<Row style={{color:'red'}} className='redValidacija'>Morate uneti cenu.</Row>:null}
              <Row>Tip:  <select className='unosIzmena'
              onChange={(e)=>{
               const daLiJePlacena=e.target.value
               setTip(daLiJePlacena)
               
             }}>
               <option value= '1'>Individualni trening</option>
               <option value= '0'>Grupni trening</option>
             </select></Row>
             {validacijaTip?<Row style={{color:'red'}} className='redValidacija'>Morate uneti tip.</Row>:null}
    
             </Modal.Body>
              <Modal.Footer>
                  <Button onClick={()=>dodajNoviTrening() }>Potvrdi</Button>
                  <Button onClick={()=>setModalDodajTrening(false)}>Poništi</Button>
              </Modal.Footer>
          </Modal>

          <Modal show={modalObrisi}>
              
              <Modal.Body>
              <Alert className='alert alert-info'>Da li ste sigurni da želite da obrišete ovaj trening iz ponude?</Alert>
             </Modal.Body>
              <Modal.Footer>
                  <Button onClick={()=>obrisiClana() }>Potvrdi</Button>
                  <Button onClick={()=>setModalObrisi(false)}>Poništi</Button>
              </Modal.Footer>
          </Modal>



          <Modal show={modalUspesnoBrisanje}>
              <Modal.Header >Uspešno brisanje</Modal.Header>
              <Modal.Body>
              <Alert className='alert alert-success'>Uspešno ste obrisali ovaj trening<i className="far fa-check-circle ikonica"></i></Alert>
             </Modal.Body>
              <Modal.Footer>
                  <Button onClick={uspesnoBrisanje}>Ok</Button>
              </Modal.Footer>
          </Modal>

          <Modal show={modalBrisanjeGreska}>
              <Modal.Header >Greška</Modal.Header>
              <Modal.Body>
              <Alert className='alert alert-danger'>Žao nam je, došlo je do greške prilikom brisanja treninga.Molimo Vas pokušajte ponovo.</Alert>
             </Modal.Body>
              <Modal.Footer>
                  <Button onClick={()=>setModalBrisanjeGreska(false) }>Ok</Button>
              </Modal.Footer>
          </Modal>
          <Modal show={modalPosaljiZahtev}>
              <Modal.Header >Pošalji zahtev</Modal.Header>
              <Modal.Body>
              <Row>Izaberite trenera:</Row>
              <Row><select 
              onChange={(e)=>{
                const izabraniTrener=e.target.value
                
                setTrenerZahtev(izabraniTrener)
                
               }}>
                {
                    treneriPersonal.pod.map((trener)=>(
                        <option key={trener.id}>{trener.id} {trener.ime} {trener.prezime}</option>
                    ))
                
                }
                  </select></Row>
              <Row>Datum:</Row>
              <Row>
              <DatePicker
               closeOnScroll={true}
               selected={datum}
               onChange={(date) => setDatum(date)}
                />
               </Row>
               <Row>Izaberite okvirno vreme koje vam odgovara:</Row>
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
                 
                  />
                 </Row>
                 <Row>Dodajte dodatne informacije ako želite:</Row>
                 <Row><input onChange={e=>setOpisZahteva(e.target.value)}/></Row>
             
             </Modal.Body>
              <Modal.Footer>
                  <Button onClick={()=>posaljiZahtev()}>Pošalji</Button>
                  <Button onClick={()=>setModalPosaljiZahtev(false) }>Otkaži</Button>
              </Modal.Footer>
          </Modal>

          <Modal show={modalUspesnoZakazivanjeClan}>
              <Modal.Header >Uspešno zakazivanje</Modal.Header>
              <Modal.Body>
              <Alert className='alert alert-success'>Uspešno ste zakazali novi termin<i className="far fa-check-circle ikonica"></i></Alert>
             </Modal.Body>
              <Modal.Footer>
                  <Button onClick={uspesnoZakazivanje}>Ok</Button>
              </Modal.Footer>
          </Modal>

          <Modal show={modalZakazivanjeGreskaBroj}>
              <Modal.Header >Greška</Modal.Header>
              <Modal.Body>
              <Alert className='alert alert-danger'>Žao nam je,ne možete zakazati ovaj termin, maksimalni kapacitet je popunjen.</Alert>
             </Modal.Body>
              <Modal.Footer>
                  <Button onClick={()=>setModalZakazivanjeGreskaBroj(false) }>Ok</Button>
              </Modal.Footer>
          </Modal>
          <Modal show={modalUspesnoPoslatZahtev}>
              <Modal.Header >Uspešno poslat zahtev</Modal.Header>
              <Modal.Body>
              <Alert className='alert alert-success'>Uspešno ste poslali zahtev<i className="far fa-check-circle ikonica"></i></Alert>
             </Modal.Body>
              <Modal.Footer>
                  <Button onClick={()=>setModalUspesnoPoslatZahtev(false)}>Ok</Button>
              </Modal.Footer>
          </Modal>

          <Modal show={modalPoslatZahtevGreska}>
              <Modal.Header >Greška</Modal.Header>
              <Modal.Body>
              <Alert className='alert alert-danger'>Žao nam je, došlo je do greške.Molimo Vas pokušajte ponovo.</Alert>
             </Modal.Body>
              <Modal.Footer>
                  <Button onClick={()=>setModalPoslatZahtevGreska(false) }>Ok</Button>
              </Modal.Footer>
          </Modal>
          <Modal show={modalZakazivanjeGreskaClanarina}>
              <Modal.Header >Greška</Modal.Header>
              <Modal.Body>
              <Alert className='alert alert-danger'>Žao nam je, ovu funkciju ne možete izvršiti jer niste platili članarinu.</Alert>
             </Modal.Body>
              <Modal.Footer>
                  <Button onClick={()=>setModalZakazivanjeGreskaClanarina(false) }>Ok</Button>
              </Modal.Footer>
          </Modal>

          <Modal show={modalUspesnoDodavanje}>
              <Modal.Header >Uspešno dodavanje</Modal.Header>
              <Modal.Body>
              <Alert className='alert alert-success'>Uspešno ste dodali novi trening<i className="far fa-check-circle ikonica"></i></Alert>
             </Modal.Body>
              <Modal.Footer>
                  <Button onClick={uspesnoDodavanje}>Ok</Button>
              </Modal.Footer>
          </Modal>

          <Modal show={modalDodavanjeGreska}>
              <Modal.Header >Greška</Modal.Header>
              <Modal.Body>
              <Alert className='alert alert-danger'>Žao nam je, došlo je do greške prilikom dodavanja treninga.Molimo Vas pokušajte ponovo.</Alert>
             </Modal.Body>
              <Modal.Footer>
                  <Button onClick={()=>setModalDodavanjeGreska(false) }>Ok</Button>
              </Modal.Footer>
          </Modal>


          {spin?<LoadingSpin/>:null}
            
        </div>
    )
}
