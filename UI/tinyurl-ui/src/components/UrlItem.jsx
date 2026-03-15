export default function UrlItem() {
  return (
    <div className="card p-3 shadow-sm">

      <div className="d-flex align-items-center flex-wrap gap-2 mb-2">

        <a
          href="#"
          className="text-primary text-decoration-none fw-semibold"
        >
          https://tiny-url-demo.azurewebsites.net/5ee87d
        </a>

        <button className="btn btn-primary">
          Copy
        </button>

        <span className="badge bg-success">
          3 clicks
        </span>

        <button className="btn btn-danger">
          Delete
        </button>

      </div>

      <div className="text-muted small">
        https://www.example.com/products/category1/subcategory2/item1234
      </div>

    </div>
  );
}