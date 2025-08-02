import Moralis from 'moralis';

export default defineEventHandler(async (event) => {
  const config = useRuntimeConfig();
  const query = getQuery(event);
  const address = query.address as string;

  if (!address) {
    throw createError({ statusCode: 400, message: 'Missing address' });
  }

  if (!Moralis.Core.isStarted) {
    await Moralis.start({ apiKey: config.moralisApiKey });
  }

  const result = await Moralis.EvmApi.nft.getWalletNFTs({
    address,
    chain: '0x1', // Mainnet
  });

  return result.toJSON();
});