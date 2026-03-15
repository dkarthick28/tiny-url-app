import { useState } from "react";
import UrlList from "./UrlList";

export default function PublicUrls({urls}) {

  const [searchTerm,setSearchTerm]= useState("");
const filteredUrls= urls.filter((url)=>
  url.originalUrl.toLowerCase().includes(searchTerm.toLowerCase()) ||
    url.shortCode.toLowerCase().includes(searchTerm.toLowerCase())
);
 
 
 return (
<div className="tinyurl-listcontainer" style={{maxWidth:"1100px"}}>
      <div className="card shadow-sm p-4">

        <h4 className="text-center text-primary mb-4">
          Public URLs
        </h4> 

        <input
          type="text"
          placeholder="Search URLs..."
          className="form-control mb-4" value={searchTerm} onChange={(e)=>setSearchTerm(e.target.value)}
        />

        <UrlList urls={filteredUrls} />

      </div>

    </div>
  );
}