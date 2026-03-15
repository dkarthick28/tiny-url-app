import {API_BASE_URL,updateCountUrl} from "./Services/urlService.js";

export default function UrlItem({data}) {
console.log('data got is ' , data);
 
const handleRedirect=async()=>{
  try{
 
  await updateCountUrl(data.shortCode);
}
catch(error){
  console.error(error);
}
}



const shortURL= `${window.location.origin}/${data.shortCode}`;
  return (
    <div className="card p-3 shadow-sm">

      <div className="d-flex align-items-center flex-wrap gap-2 mb-2">

        <a
          href={shortURL}
          className="text-primary text-decoration-none fw-semibold"
        >
          {shortURL}
        </a>

        <button className="btn btn-primary" onClick={()=>navigator.clipboard.writeText(shortURL)}>
          Copy
        </button>

        <span className="badge bg-success">
         {data.totalClickCount}
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