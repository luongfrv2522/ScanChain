<script setup lang="ts">

import AsideSection from '@/layout/main/AsideSection.vue'
import NavSection from '@/layout/main/NavSection.vue'
</script>

<template>
  <div class="flex flex-row w-full min-h-screen">
    <AsideSection />
    <div class="flex-1 flex flex-col px-15">
      <NavSection />
      <main>
        <RouterView/>
      </main>
    </div>
  </div>
</template>

<style scoped>

</style>
