import { onUnmounted } from 'vue'

export function useCancelableRequest() {
  const controller = new AbortController()

  onUnmounted(() => {
    controller.abort()
  })

  return controller.signal
}
