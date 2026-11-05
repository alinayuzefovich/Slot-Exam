import { init, initData, isTMA, miniApp, themeParams, type User, } from '@telegram-apps/sdk'

// This is client-side display data, not a server-authenticated profile.
export interface TelegramContext {
  mode: 'browser' | 'telegram' | 'unavailable'
  firstName: string | null
  userInfo: User | undefined
}

export function initializeTelegram(): TelegramContext {
  console.log('init th, isTma:', isTMA())
  try {
    if (!isTMA()) {
      return { mode: 'browser', firstName: null, userInfo: undefined }
    }

    const cleanup = init()
    if (import.meta.hot) import.meta.hot.dispose(cleanup)

    initData.restore()
    const user = initData.user()

    // SDK updates these CSS variables when Telegram's theme changes.
    themeParams.mountSync()
    const unbind = themeParams.bindCssVars()
    if (import.meta.hot) {
      import.meta.hot.dispose(() => {
        unbind()
        themeParams.unmount()
      })
    }

    miniApp.ready.ifAvailable()
    console.log(user)
    return { mode: 'telegram', firstName: user?.first_name ?? null, userInfo: user }
  } catch {
    // An invalid launch must not leave the user with a blank screen.
    console.error('init fail')
    return { mode: 'unavailable', firstName: null, userInfo: undefined }
  }
}
