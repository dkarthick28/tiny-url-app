import { useState } from "react";
import {API_BASE_URL,updateCountUrl} from "../Services/urlService";


export default function UrlItem({data}) {

const [copied, setCopied] = useState(false);
  const [clickCount, setClickCount] = useState(data.totalClickCount);

 const handleCopy = (url) => {
  navigator.clipboard.writeText(url);
  setCopied(true);

  setTimeout(() => {
    setCopied(false);
  }, 2000);
};
const handleUrlClick = async (e) => {
    e.preventDefault(); // prevent immediate navigation

    try {
      
      const result = await updateCountUrl(data.shortCode);
     
      // API returns updated count
      setClickCount(result.totalClickCount);

      // open the original URL after updating count
     window.open(shortURL, "_blank");

    } catch (err) {
      console.error("Failed to update count", err);
      window.open(shortURL, "_blank"); // fallback
    }
  };



const shortURL= `${window.location.origin}/${data.shortCode}`;
  return (
    <div className="tinyurl-list-item">

      <div className="tinyurl-list-main">
<div className="tinyurl-short-url-row">
        <a href={shortURL}  onClick={handleUrlClick} className="tinyurl-short-url-link">
          {shortURL}
        </a>

        <button className="tinyurl-copy-btn tinyurl-copy-btn-small" onClick={() => handleCopy(shortURL)}>
           {copied ? "Copied!" : "Copy"}
        </button>

        <span className="tinyurl-clicks-badge">
         {clickCount}
        </span>
     </div>
        <div className="tinyurl-original-url">
      {data.originalUrl}
      </div>
       

      </div>

    <button className="tinyurl-delete-btn">
          Delete
        </button>

    </div>
  );
}