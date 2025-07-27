import { createRouter, createWebHistory } from 'vue-router'
import DefaultLayout from '@/layout/default/DefaultLayout.vue'

const router = createRouter({
  history: createWebHistory(import.meta.env.BASE_URL),
  routes: [
    {
      path: '/',
      component: DefaultLayout,
      children: [
        {
          path: '/',
          name: 'search',
          component: () => import('@/features/search/components/SearchPage.vue'),
        },
      ]
    }
  ],
})

export default router
