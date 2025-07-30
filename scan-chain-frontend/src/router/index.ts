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
          name: 'Search',
          component: () => import('@/features/search/components/SearchPage.vue'),
        },
        {
          path: '/test',
          name: 'Test',
          component: () => import('@/features/search/components/TestPage.vue'),
        },
      ]
    }
  ],
})

export default router
