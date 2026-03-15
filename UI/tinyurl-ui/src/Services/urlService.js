const API_BASE_URL = "https://tinyurl-api-c0g8ade0gnf9gzfb.southindia-01.azurewebsites.net/api/TinyURL";

export const createShortUrl = async (data) => {
  const response = await fetch(`${API_BASE_URL}/add`, {
    method: "POST",
    headers: {
      "Content-Type": "application/json"
    },
    body: JSON.stringify(data)
  });

  if (!response.ok) {
    throw new Error("Failed to create URL");
  }

  return await response.json();
};

export const getUrlByCode = async (code) => {
  const response = await fetch(`${API_BASE_URL}/get/${code}`);

  if (!response.ok) {
    throw new Error("Failed to fetch URLs");
  }

  return await response.json();
};


export const getAllPublicUrls = async () => {
  const response = await fetch(`${API_BASE_URL}/public`);

  if (!response.ok) {
    throw new Error("Failed to fetch URLs");
  }

  return await response.json();
};

export const deleteUrl = async (code) => {
  const response = await fetch(`${API_BASE_URL}/delete/${code}`, {
    method: "DELETE"
  });

  if (!response.ok) {
    throw new Error("Delete failed");
  }
};

export const updateCountUrl = async (code) => {
  const response = await fetch(`${API_BASE_URL}/update/${code}`, {
    method: "PUT",
    headers: {
      "Content-Type": "application/json"
    },
  });

  if (!response.ok) {
    throw new Error("Update failed");
  }

  return await response.json();
};