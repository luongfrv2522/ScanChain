/// <reference types="vite/client" />
interface ImportMetaEnv {
  readonly VITE_MORALIS_API_KEY: string
  readonly VITE_MORALIS_API_DOMAIN: string
}

interface ImportMeta {
  readonly env: ImportMetaEnv
}
