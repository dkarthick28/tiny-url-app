export default function ShortUrlResult({data}) {
  return (
    <div className="container mt-4">
<div className="result-box mt-4">
      <div>
          <span className="fw-semibold text-success me-2">
        Short URL:
      </span>

     <a
            href="#"
            className="text-primary text-decoration-underline"
          >
           {data}
          </a>
        </div>

      <button className="btn btn-primary btn-sm">
          Copy
        </button>
</div>
    </div>
  );
}