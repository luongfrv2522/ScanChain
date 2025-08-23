<script setup lang="ts">
import { computed, nextTick, ref } from 'vue'
import { isAddress } from 'ethers'
import { walletApi } from '@/api'
import type { WalletInfo, WalletToken } from '@/api/api-client'
import { formatCurrency, formatCurrencySmart } from '@/utils/number.ts'
import { ContentCopyFilled } from '@vicons/material'
import { copyToClipboard } from '@/utils/clipboard.ts'
import type { DataTableColumns } from 'naive-ui'
import { shorten } from '@/utils'
import data from './data.json'
import { useCancelableRequest } from '@/composables/useCancelableRequest.ts'

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
  const walletInfo = ref<WalletInfo>();
  const searching = ref(false);
  const targetResult = ref<HTMLElement | null>(null)

  const walletTokensTableData = computed(() => {
    const tokens = walletInfo.value?.result
    if (!tokens) return [];
    return tokens.map( vals => ({
      name: `${vals.name} (${shorten(vals.symbol??"")})`,
      balanceFormatted: formatCurrencySmart(Number(vals.balanceFormatted)),
      usdPrice: formatCurrency(Number(vals.usdPrice)),
      usdValue: formatCurrency(Number(vals.usdValue)),
      possibleSpam: vals.possibleSpam ? "Rủi do" : "-",
      verifiedContract: vals.verifiedContract ? "Đã xác minh" : "-",
      securityScore: vals.securityScore ?? "-"
    }));
  })
  const netWorth = computed(() => {
    const netWorthVal = walletInfo.value?.result?.reduce(
      (sum, t) => sum + (t.usdValue ?? 0),
      0
    );
    return formatCurrency(netWorthVal ?? 0)
  });
  const onSearch = async () => {
    if (!searchVal.value || searching.value) return;
    searching.value = true;
    if (!isAddress(searchVal.value)) {
      console.error('Address search must be a valid address.')
      return;
    }
    const signal = useCancelableRequest();
    const response = await walletApi.getWalletInfoQuery(searchVal.value, { signal })
    if (response.status != 200) throw Error(response.statusText);
    walletInfo.value = response.data;
    searching.value = false;
    await nextTick(() => {
      targetResult.value?.scrollIntoView({ behavior: 'smooth' })
    });
  }
  const columns: DataTableColumns<WalletToken> = [
    {
      title: 'Token',
      key: 'name'
    },
    {
      title: 'Giá',
      key: 'usdPrice'
    },
    {
      title: 'Số dư',
      key: 'balanceFormatted'
    },
    {
      title: 'Trị giá',
      key: 'usdValue'
    },
    {
      title: 'Scam',
      key: 'possibleSpam'
    },
    {
      title: 'Verified',
      key: 'verifiedContract'
    },
    {
      title: 'Điểm tin cậy',
      key: 'securityScore'
    }
  ]
</script>

<template>
  <n-flex justify="center" vertical align="center" style="gap: 16px;">
    <n-flex align="center" vertical justify="center" wrap style="gap: 16px;">
      <n-gradient-text type="info" size="56" style="margin-top: 40px; text-align: center; white-space: normal;">
        Check Crypto Address
      </n-gradient-text>
      <n-text style="text-align: center">Validate crypto wallet address</n-text>
    </n-flex>
    <n-card title="Tra cứu thông tin ví" style="max-width: 900px; margin-top: 80px; margin-bottom: 80px;">
      <n-flex align="center" justify="center">
        <n-select size="large" v-model:value="chainVal" :options="moralisChains" />
        <n-input size="large" placeholder="Nhập địa chỉ ví" v-model:value="searchVal" />
        <n-button :loading="searching" size="large" style="margin-top: 20px" @click="onSearch">Tìm kiếm</n-button>
      </n-flex>
    </n-card>
    <div ref="targetResult">
      <template v-if="walletInfo">
        <n-card style="margin-bottom: 16px;">
          <n-flex align="center" justify="space-between">
            <n-flex vertical>
              <h2>Địa chỉ ví</h2>
              <n-flex align="center" >
                {{walletInfo?.address}}
                <n-tooltip trigger="click" >
                  <template #trigger>
                    <n-button text @click="copyToClipboard(walletInfo.address ?? '')">
                      <n-icon>
                        <ContentCopyFilled />
                      </n-icon>
                    </n-button>
                  </template>
                  <span>Copied</span>
                </n-tooltip>
              </n-flex>
            </n-flex>
            <n-flex vertical align="end">
              <div>Tài sản dòng</div>
              <h2>{{netWorth}}</h2>
            </n-flex>
          </n-flex>
        </n-card>
        <n-card>
          <n-tabs
            type="line"
            size="large"
            pane-wrapper-style="margin: 0 -4px"
            pane-style="padding-left: 4px; padding-right: 4px; box-sizing: border-box;"
            animated>
            <n-tab-pane name="walletInfo" tab="Wallet info">
              <n-data-table
                :columns="columns"
                :data="walletTokensTableData"
                :pagination="false"
                :bordered="false"
              />
            </n-tab-pane>
            <n-tab-pane name="transactions" tab="Transactions">
              <n-data-table
                :columns="columns"
                :data="walletTokensTableData"
                :pagination="false"
                :bordered="false"
              />
            </n-tab-pane>
          </n-tabs>
        </n-card>
      </template>
    </div>
  </n-flex>
</template>

<style scoped>
  h2 {
    margin-top: 0;
    margin-bottom: 0;
  }
</style>
