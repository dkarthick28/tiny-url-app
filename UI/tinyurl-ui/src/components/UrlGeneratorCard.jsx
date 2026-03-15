import React, { useState } from "react";
import {createShortUrl} from "../Services/urlService";

function UrlGenerator({setShortUrlData}) {
    const[url,setUrl] =useState("");
    const[isPrivate,setIsPrivate] =useState(false);
    const [errorMessage, setErrorMessage] = useState("");
    const handleGenerate= async()=>{
      const data= {
        OriginalUrl: url,
        IsPrivate:isPrivate
      };
 if (!url.startsWith("http://") && !url.startsWith("https://")) {
  setShortUrlData("");
    setErrorMessage("Please enter a valid URL (must start with http:// or https://)");
    return;
 }
  setErrorMessage("");

      try{
            console.log(data);
            const result= await createShortUrl(data);
            const shortUrl= `${window.location}/${result.shortCode}`;
            setShortUrlData(shortUrl);
            console.log(result);
      }
catch(error)
{
  setShortUrlData("");
  setErrorMessage("Failed to generate short URL. Please try again.");
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

          {errorMessage && (
  <p className="error-message">{errorMessage}</p>
)}
       

      </div>
  );
}

export default UrlGenerator;