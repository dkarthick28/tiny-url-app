import UrlItem from "./UrlItem";

export default function UrlList({urls}) {
  
  if (!urls || urls.length === 0) {
    return <p>No URLs found.</p>;
  }
  return (
    <div className="tinyurl-scrollable-list">
    {
     urls.map((url)=>(
      <UrlItem key={url.tinyURLId} data={url} />
))
    }
    </div>
  )};
