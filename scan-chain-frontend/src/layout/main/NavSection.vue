<script setup lang="ts">

</script>

<template>
  <nav class="flex justify-end items-center gap-1 h-15 w-full">
    <div class="flex-1 relative w-full">
      <!-- Icon -->
      <div class="absolute inset-y-0 left-0 flex items-center pl-3 pointer-events-none">
        <svg class="w-5 h-5 text-gray-400" fill="none" viewBox="0 0 24 24" stroke="currentColor">
          <path stroke-width="2" d="M21 21l-4.35-4.35M11 18a7 7 0 1 1 0-14 7 7 0 0 1 0 14z" />
        </svg>
      </div>
      <!-- Input -->
      <input
        type="search"
        placeholder="Nhập địa chỉ ví..."
        class="w-full text-base p-3 pl-10 text-gray-900 border border-gray-300 rounded-lg bg-gray-50 focus:outline-none focus:ring-0 focus:border-blue-500"
      />
    </div>
  </nav>
</template>

<style scoped>

</style>
