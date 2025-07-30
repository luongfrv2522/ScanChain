import express from 'express';
import {initMoralis} from "@app/serivces/moralis.service";
import walletRouter from "@app/routers/wallet.router";
import 'dotenv/config';

const app = express();

app.use(express.json());
app.use('/api/wallet', walletRouter);

await initMoralis();
const port = process.env.PORT;
if (process.env.NODE_ENV === 'production') {
  app.listen(port, () => {
    console.log(`🚀 Production server running at http://localhost:${port}`);
  });
}

export { app };