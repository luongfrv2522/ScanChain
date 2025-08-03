import type { Router } from 'vue-router';
import { pascalToWords } from '@/utils'

export function setupTitleGuard(router: Router) {
  router.beforeEach((to, from, next) => {
    const title = `${to.meta.title ?? pascalToWords(to.name as string)} | Scan Chain`;
    if (title) {
      document.title = title;
    }
    next();
  });
}
