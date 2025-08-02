import Moralis from 'moralis';

export default defineNuxtPlugin(async () => {
  const config = useRuntimeConfig();

  if (!Moralis.Core.isStarted) {
    await Moralis.start({ apiKey: config.moralisApiKey });
  }

  return {
    provide: {
      moralis: Moralis,
    },
  };
});