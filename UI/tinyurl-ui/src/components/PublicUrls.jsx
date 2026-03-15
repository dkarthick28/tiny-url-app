import UrlList from "./UrlList";

export default function PublicUrls() {
  return (
<div className="tinyurl-listcontainer" style={{maxWidth:"1100px"}}>
      <div className="card shadow-sm p-4">

        <h4 className="text-center text-primary mb-4">
          Public URLs
        </h4> 

        <input
          type="text"
          placeholder="Search URLs..."
          className="form-control mb-4"
        />

        <UrlList />

      </div>

    </div>
  );
}