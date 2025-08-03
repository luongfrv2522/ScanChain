<template>
  <n-config-provider :theme="isDark ? darkTheme : lightTheme">
    <n-layout style="min-height: 100vh">
      <n-layout-header bordered >
        <div class="logo">🚀 ScanChain</div>
        <n-switch :value="isDark" @update:value="toggleTheme">
          <template #checked>🌙</template>
          <template #unchecked>☀️</template>
        </n-switch>
      </n-layout-header>
      <n-layout-content>
        <n-flex justify="space-between" align="stretch">
          <!-- Quảng cáo trái -->
          <div class="ad-side">
            <n-card title="Quảng cáo trái" size="small">Banner A</n-card>
          </div>
          <!-- Nội dung chính -->
          <div class="main-content">
            <RouterView />
          </div>
          <!-- Quảng cáo phải -->
          <div class="ad-side">
            <n-card title="Quảng cáo phải" size="small">Banner B</n-card>
          </div>
        </n-flex>
      </n-layout-content>
      <n-layout-footer bordered>
        <p>© 2025 ScanChain. All rights reserved.</p>
      </n-layout-footer>
    </n-layout>
  </n-config-provider>
</template>

<script setup lang="ts">
import { ref } from 'vue'
import { darkTheme, lightTheme } from 'naive-ui'

const isDark = ref(localStorage.getItem('theme') === 'dark')
const toggleTheme = () => {
  isDark.value = !isDark.value
  localStorage.setItem('theme', isDark.value ? 'dark' : 'light')
}
</script>

<style scoped>
.n-layout {
  display: flex;
  flex-direction: column;
  min-height: 100vh;
}

.n-layout-header {
  display: flex;
  justify-content: space-between;
  align-items: center;
  padding: 16px 24px;
}

.logo {
  font-size: 20px;
  font-weight: bold;
}

.n-layout-content {
  flex: 1;
  padding: 24px;
}

.n-layout-footer {
  text-align: center;
  padding: 16px;
}

.ad-side {
  width: 200px;
}

.main-content {
  flex: 1;
  padding: 0 16px;
  min-width: 200px;
}
</style>
