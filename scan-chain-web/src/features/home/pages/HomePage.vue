<script setup lang="ts">
  import { ref } from 'vue'
  import { isAddress } from 'ethers'
  import { walletApi } from '@/api'
  import type { GetWalletInfoEndpointRequest, WalletInfo } from '@/api/api-client'

  const moralisChains = [
    { label: 'Ethereum Mainnet', value: '0x1' },
    { label: 'Ethereum Sepolia (Testnet)', value: '0xaa36a7' },
    { label: 'Ethereum Holesky (Testnet)', value: '0x4268' },
    { label: 'Polygon Mainnet', value: '0x89' },
    { label: 'Polygon Amoy (Testnet)', value: '0x13882' },
    { label: 'Binance Smart Chain Mainnet', value: '0x38' },
    { label: 'BSC Testnet', value: '0x61' },
    { label: 'Arbitrum One', value: '0xa4b1' },
    { label: 'Base Mainnet', value: '0x2105' },
    { label: 'Base Sepolia (Testnet)', value: '0x14a34' },
    { label: 'Optimism Mainnet', value: '0xa' },
    { label: 'Linea Mainnet', value: '0xe708' },
    { label: 'Linea Sepolia (Testnet)', value: '0xe705' },
    { label: 'Avalanche Mainnet', value: '0xa86a' },
    { label: 'Fantom Mainnet', value: '0xfa' },
    { label: 'Cronos Mainnet', value: '0x19' },
    { label: 'Palm Mainnet', value: '0x2a15c308d' },
    { label: 'Gnosis Mainnet', value: '0x64' },
    { label: 'Gnosis Chiado (Testnet)', value: '0x27d8' },
    { label: 'Chiliz Mainnet', value: '0x15b38' },
    { label: 'Chiliz Testnet', value: '0x15b32' },
    { label: 'Moonbeam Mainnet', value: '0x504' },
    { label: 'Moonriver (Testnet)', value: '0x505' },
    { label: 'Moonbase (Testnet)', value: '0x507' },
    { label: 'Flow Mainnet', value: '0x2eb' },
    { label: 'Flow Testnet', value: '0x221' },
    { label: 'Ronin Mainnet', value: '0x7e4' },
    { label: 'Ronin Saigon (Testnet)', value: '0x7e5' },
    { label: 'Lisk Mainnet', value: '0x46f' },
    { label: 'Lisk Sepolia (Testnet)', value: '0x106a' },
    { label: 'Pulsechain Mainnet', value: '0x171' }
  ];
  const chainVal = ref('0x1')
  const searchVal = ref('')
  const onSearch = async () => {
    if (!searchVal.value) return;
    if (!isAddress(searchVal.value)) {
      console.error('Address search must be a valid address.')
      return;
    }

    const request: GetWalletInfoEndpointRequest = {
      address: searchVal.value
    }
    const response: WalletInfo = await walletApi.getWalletInfoEndpoint(request)
    console.log(response)
  }
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
        <n-select size="large" v-model:value="chainVal" :options="moralisChains" />
        <n-input size="large" placeholder="Nhập địa chỉ ví" v-model:value="searchVal" />
        <n-button size="large" style="margin-top: 20px" @click="onSearch">Tìm kiếm</n-button>
      </n-flex>
    </n-card>
  </n-flex>
</template>

<style scoped>

</style>
