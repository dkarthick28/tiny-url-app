import { useState } from "react";
import {API_BASE_URL,updateCountUrl} from "../Services/urlService";


export default function UrlItem({data}) {
console.log('data got is ' , data);
  const [clickCount, setClickCount] = useState(data.totalClickCount);

 
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
    <div className="card p-3 shadow-sm">

      <div className="d-flex align-items-center flex-wrap gap-2 mb-2">

        <a
          href={shortURL}     onClick={handleUrlClick}

          className="text-primary text-decoration-none fw-semibold"
        >
          {shortURL}
        </a>

        <button className="btn btn-primary" onClick={()=>navigator.clipboard.writeText(shortURL)}>
          Copy
        </button>

        <span className="badge bg-success">
         {clickCount}
        </span>

        <button className="btn btn-danger">
          Delete
        </button>

      </div>

      <div className="text-muted small">
      {data.originalUrl}
      </div>

    </div>
  );
}