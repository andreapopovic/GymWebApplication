//import React from "react"
import './Button.css'
//import{Link} from 'react-router-dom'
const STIL =['btn--prymary','btn--outline']
const VELICINA=['btn--medium','btn--large']
export const Button=({children,type,onClick,BStyle,BSize})=>{
    const checkButtonStyle=STIL.includes(BStyle)? BStyle:STIL[0]
    const checkButtonSize=STIL.includes(BSize)? BSize:VELICINA[0]

    return(
     //   <Link className='btn-mobile' to='/#'>
            <button className={`btn ${checkButtonStyle} ${checkButtonSize}`}
            onClick={onClick}
            type={type}>
                {children}
            </button>
      //  </Link>
    )
}