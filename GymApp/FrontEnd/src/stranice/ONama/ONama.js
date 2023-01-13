import React from 'react'
import About from './About'
import './About.css'
import { Slider } from './Slider'
import "bootstrap/dist/css/bootstrap.min.css"
export default function oNama() {
    return (
        <div className="badge-dark" >
              <h3 className='onama'color="black"> O nama</h3>
              
              <div className="divText">  
              <div className="jumbotron" > 
                Čisti, klimatizovani, prostrani, moderno opremljeni ambijenti i odlična, uvek pozitivna atmosfera za vežbanje i kvalitetno druženje vas očekuje ovde!
               Imamo pristupačne cene, brojne pogodnosti, česte popuste koje ne smete propustiti.Dodjite i uverite se u kvalitet naših usluga!
              </div>
              <div className="pom">
              <h4 ><span>Intenzitet treninga</span><span> 100%</span></h4>
              <div className="scala" ></div>
              </div>
              <div className="pom">
              <h4 ><span>Stručnost trenera</span><span> 100%</span></h4>
              <div className="scala" ></div>
              </div>
              <div className="pom">
              <h4 ><span>Najbolje ponude</span><span> 100%</span></h4>
              <div className="scala" ></div>
              
              </div>
              <div className="pom">
              <h4 ><span>Kvalitet usluga</span><span> 100%</span></h4>
              <div className="scala" ></div>
              
              </div>
              </div>
             <About slides={Slider}/>
        </div>
    )
}
