// Example only. The backend must approve this authorization header before use.
export async function getMyProfile(
  rawInitData: string,
  signal?: AbortSignal,
): Promise<unknown> {
  const baseUrl = import.meta.env.VITE_API_BASE_URL

  if (!baseUrl) {
    throw new Error('Укажи VITE_API_BASE_URL после согласования с бэкендером.')
  }
  if (!rawInitData) {
    throw new Error('Для запроса профиля нужны данные запуска Telegram.')
  }

  const response = await fetch(`${baseUrl.replace(/\/+$/, '')}/me`, {
    method: 'GET',
    headers: {
      Accept: 'application/json',
      Authorization: `tma ${rawInitData}`,
    },
    signal,
  })

  if (!response.ok) {
    throw new Error(`Не удалось получить профиль: HTTP ${response.status}`)
  }

  // unknown is deliberate: the response schema has not been agreed yet.
  return response.json()
}
