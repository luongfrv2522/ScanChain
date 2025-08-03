import { createRouter, createWebHistory } from 'vue-router'
import DefaultLayout from '@/components/layouts/DefaultLayout.vue'
import { setupTitleGuard } from '@/router/title.guard.ts'

const router = createRouter({
  history: createWebHistory(import.meta.env.BASE_URL),
  routes: [
    {
      path: '/',
      component: DefaultLayout,
      children: [
        {
          path: '',
          alias: '/home',
          name: 'Home',
          component: () => import('@/features/home/pages/HomePage.vue'),
        },
      ]
    },
  ],
})

setupTitleGuard(router);
export default router
