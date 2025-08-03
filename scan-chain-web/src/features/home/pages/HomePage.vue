<script setup lang="ts">
  import { ref } from 'vue'

  const chains = [
    {
      label: 'Everybody\'s Got Something to Hide Except Me and My Monkey',
      value: 'song0',
      disabled: true
    },
    {
      label: 'Drive My Car',
      value: 'song1'
    },
    {
      label: 'Norwegian Wood',
      value: 'song2'
    },
    {
      label: 'You Won\'t See',
      value: 'song3',
      disabled: true
    },
    {
      label: 'Nowhere Man',
      value: 'song4'
    },
    {
      label: 'Think For Yourself',
      value: 'song5'
    },
    {
      label: 'The Word',
      value: 'song6'
    },
    {
      label: 'Michelle',
      value: 'song7',
      disabled: true
    },
    {
      label: 'What goes on',
      value: 'song8'
    },
    {
      label: 'Girl',
      value: 'song9'
    },
    {
      label: 'I\'m looking through you',
      value: 'song10'
    },
    {
      label: 'In My Life',
      value: 'song11'
    },
    {
      label: 'Wait',
      value: 'song12'
    }
  ]
  const defaultVal = ref('song2')
</script>

<template>
  <n-flex justify="center" vertical align="center">
    <n-flex align="center" vertical justify="center" wrap style="gap: 16px;">
      <n-gradient-text type="info" size="56" style="margin-top: 40px; text-align: center; white-space: normal;">
        Check Crypto Address
      </n-gradient-text>
      <n-text style="text-align: center">Validate crypto wallet address</n-text>
    </n-flex>
    <n-card title="Tra cứu thông tin ví" style="max-width: 900px; margin-top: 80px;">
      <n-flex align="center" justify="center">
        <n-select size="large" v-model:value="defaultVal" :options="chains" />
        <n-input size="large" placeholder="Nhập địa chỉ ví" />
        <n-button size="large" style="margin-top: 20px">Tìm kiếm</n-button>
      </n-flex>
    </n-card>
  </n-flex>
</template>

<style scoped>

</style>
