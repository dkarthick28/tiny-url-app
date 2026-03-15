import React, { useState } from "react";
import {createShortUrl} from "../Services/urlService";

function UrlGenerator({setShortUrlData,refreshUrls}) {
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
            refreshUrls();
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
   <>

      <div className="tiny-url-box">

     
        <div className="tinyurl-input-row">
            <input
              type="text"
              className="tinyurl-url-input"
              placeholder="Enter URL to shorten" value={url} onChange={(e)=>setUrl(e.target.value)}
            />
              
              <label className="tinyurl-checkbox-label" htmlFor="isPrivate">
                <input
                type="checkbox"
                className="form-check-input"
                id="isPrivate" checked={isPrivate} onChange={(e)=>setIsPrivate(e.target.checked)}
              />
                IsPrivate
              </label>
          

          </div>

         
           
             <button onClick={handleGenerate}  className="tiny-GenrateButton">
            Generate
          </button>
 

        </div>

{errorMessage && (<div className="tinyurl-error-msg">        
  {errorMessage}
      </div>
      )}
      </>
  );
}

export default UrlGenerator;