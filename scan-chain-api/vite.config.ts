import { defineConfig } from 'vite';
import { VitePluginNode } from 'vite-plugin-node';

export default defineConfig({
  plugins: [
    VitePluginNode({
      adapter: 'express',
      appPath: './src/index.ts',
      exportName: 'app', // export từ index.ts
    }),
  ],
  resolve: {
    alias: {
      '@app': '/src',
    },
  },
  build: {
    outDir: 'dist',
    target: 'node22',
    rollupOptions: {
      external: ['express'],
    },
  },
});