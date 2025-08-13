import { Configuration,  WalletApi} from "./api-client";

const config = new Configuration({
  basePath: 'https://localhost:5002',
  headers: {

  }
});

export const walletApi = new WalletApi(config);
