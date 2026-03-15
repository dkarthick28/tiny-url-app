import {useEffect} from "react";
import {useParams} from "react-router-dom";
import {getUrlByCode} from "..Services/urlService.js";

export default function RedirectPage{

    const{code}=useParams();

    useEffect(()=>{
   
    const redirect= async()=>{
        try{
            const result= await getUrlByCode(code);
        window.location.href = result.originalUrl;
        }
        catch(error){

        }
    };

redirect();
    },[code]);

 return <p>Redirecting...</p>;
}