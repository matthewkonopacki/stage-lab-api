const API_BASE_URL = 'http://localhost:5215';

async function fetchApi<T>(
  endpoint: string,
  token?: string,
  options?: RequestInit
): Promise<T> {
  const res = await fetch(`${API_BASE_URL}${endpoint}`, {
    ...options,
    headers: {
      'Content-Type': 'application/json',
      ...(token && { Authorization: `Bearer ${token}` }),
      ...options?.headers,
    },
  });

  if (!res.ok) {
    throw new Error(`API error: ${res.status}`);
  }

  return res.json();
}
// Get user events
export async function getUserEvents(token: string, userId: string) {
  return fetchApi<Array<{description: string; id: number; }>>(`/event/query?UserId=${parseInt(userId)}`, token);
}

export async function getProductions(token: string) {
  return fetchApi<Array<{description: string; id: number; }>>(`/project/query?PageNumber=1&PageSize=5`, token);
}