import React, { useState } from "react";
import {createShortUrl} from "../Services/urlService";

function UrlGenerator() {
    const[url,setUrl] =useState("");
    const[isPrivate,setIsPrivate] =useState(false);
    
    const handleGenerate= async()=>{
      const data= {
        OriginalUrl: url,
        IsPrivate:isPrivate
      };
      try{
            const result= await createShortUrl(data);
            console.log(result);
      }
catch(error)
{
  console.error(error);
}
    };
    
  return (
    <div className="container mt-4">

      <div className="card p-4 shadow-sm">

     
        <div className="row align-items-centtinyurl-uier">
            <input
              type="text"
              className="form-control"
              placeholder="Enter URL to shorten" value={url} onChange={(e)=>setUrl(e.target.value)}
            />
          </div>

          <div className="col-md-2 text-end">
            <div className="form-check">
              <input
                type="checkbox"
                className="form-check-input"
                id="isPrivate" checked={isPrivate} onChange={(e)=>setIsPrivate(e.target.checked)}
              />
              <label className="form-check-label" htmlFor="isPrivate">
                IsPrivate
              </label>
            </div>
          </div>

        </div>

        {/* Generate Button */}
       
          <button onClick={handleGenerate}  className="btn generate-btn mt-3 w-100"
  style={{
    background: "linear-gradient(90deg,#ff416c,#7b2ff7)",
    border: "none"
  }}
>
            Generate
          </button>
       

      </div>
  );
}

export default UrlGenerator;