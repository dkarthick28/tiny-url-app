export default function ShortUrlResult() {
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
            https://tiny-url-demo.azurewebsites.net/0a5350
          </a>
        </div>

      <button className="btn btn-primary btn-sm">
          Copy
        </button>
</div>
    </div>
  );
}