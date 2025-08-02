// https://nuxt.com/docs/api/configuration/nuxt-config
export default defineNuxtConfig({
  compatibilityDate: '2025-07-15',
  devtools: { enabled: true },
  modules: [
    '@nuxt/eslint',
    '@nuxt/ui',
    '@pinia/colada-nuxt',
    '@pinia/nuxt',
    'dayjs-nuxt'
  ],
  runtimeConfig: {
    public: {
      appName: process.env.PUBLIC_APP_NAME
    },
    moralisApiKey: process.env.MORALIS_API_KEY,
  }
})