import React,{useState,useEffect} from 'react';
import {Link,useHistory} from 'react-router-dom'
//import { Button } from './Button';
import './Nav.css'
function Navbar(){

    const history=useHistory();
    const [click,setClick] =useState(false)
    const [button,setButton]=useState(true)
    const [prikazAdmin,setPrikazAdmin]=useState(false)
    const [prikazi,setPrikazi]=useState(true)  
    const [prikaziOdjviSe,setPrikaziOdjaviSe]=useState(false)  
    const handleClick=()=>setClick(!click)
    const closeMobileMenu=()=>setClick(false)

    const handleHistory=()=>{
        history.push("/")
    }

    const prikaziDugme=()=>{
        if(window.innerWidth <=960)
        {
            setButton(false)
        }
        else
        {
            setButton(true)
        }
       
    }
    window.addEventListener('resize',prikaziDugme)
    useEffect(()=>{
        prikaziDugme()
        let tok=localStorage.getItem("jwt");
        if(tok!=null)
        {
            setPrikazi(false)
            setPrikaziOdjaviSe(true)

        }
        let tip=localStorage.getItem("tip")
        if(tip==1)
        {
            setPrikazAdmin(true)
            
        }
    },[])
   
    const odjaviSe=()=>{
          
         localStorage.clear()
         handleHistory()
         window.location.reload()
    }
    
   
return(
 
    <>
    <nav className="navbar">
        <div className="navbar-container">
        <Link to='/' className="navbar-logo" onClick={closeMobileMenu}>
            DreamTeamGym 
          </Link>
 
            <div className='menu-icon' onClick={handleClick}>
                <i className={click ? 'fas fa-times' :'fas fa-bars'}/>
            </div>
            <ul className={click? 'nav-menu active':'nav-menu'}>
            
            { prikaziOdjviSe?<li className='nav-item'>
                    <Link to='/Profil' className='nav-links' onClick={closeMobileMenu}>
                     Profil
                    </Link>
                </li>:null}
                {prikazAdmin?<li className='nav-item'>
                    <Link to='/Podaci' className='nav-links' onClick={closeMobileMenu}>
                     Članovi teretane
                    </Link>
                </li>:null}
                {prikazAdmin?<li className='nav-item'>
                    <Link to='/Treneri' className='nav-links' onClick={closeMobileMenu}>
                     Treneri
                    </Link>
                </li>:null}
                {prikaziOdjviSe?<li className='nav-item'>
                    <Link to='/Treninzi' className='nav-links' onClick={closeMobileMenu}>
                     Treninzi
                    </Link>
                </li>:null}
                <li className='nav-item'>
                    <Link to='/' className='nav-links' onClick={closeMobileMenu}>
                     Pocetna
                    </Link>
                </li>
                <li className='nav-item'>
                    <Link to='/oNama' className='nav-links' onClick={closeMobileMenu}>
                     O nama
                    </Link>
                </li>
                <li className='nav-item'>
                    <Link to='/Obavestenja' className='nav-links' onClick={closeMobileMenu}>
                     Obaveštenja
                    </Link>
                </li>
               
                
            { prikazi?<li className='nav-item'>
                    <Link to='/prijaviSe' className='nav-links' onClick={closeMobileMenu}>
                     Prijavi se
                    </Link>
                </li>:null}
              {prikazi?  <li className='nav-item'>
                    <Link to='/registrujSe' className='nav-links' onClick={closeMobileMenu}>
                     Registruj se
                    </Link>
                </li>:null}
                   
            { prikaziOdjviSe?<li className='nav-item'>
                    <Link to='/' className='nav-links' onClick={closeMobileMenu ,odjaviSe}>
                    Odjavi se
                    </Link>
                </li>:null}
            </ul>
           
        </div>
    </nav>
    </>
)

}
export default Navbar
