<script setup lang="ts">
import { RouterView } from 'vue-router'
import Moralis from 'moralis'

await Moralis.start({
  apiKey: import.meta.env.MORALIS_API_KEY,
})

</script>

<template>
  <RouterView />
</template>
