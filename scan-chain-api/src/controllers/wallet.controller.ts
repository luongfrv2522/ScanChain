import { Request, Response } from 'express';
import Moralis from 'moralis';
import { EvmChain } from "@moralisweb3/common-evm-utils";
export async function getNativeBalance(req: Request, res: Response) {
  const address = req.query.address as string;
  const chain = req.query.chain as string;

  if (!address) return res.status(400).json({ error: 'Missing address' });

  try {
    const reponse = await Moralis.EvmApi.balance.getNativeBalance({
      chain: EvmChain.ETHEREUM,
      address,
    });

    res.json({ balance: reponse.result.balance.ether });
  } catch (err) {
    console.error(err);
    res.status(500).json({ error: 'Failed to fetch balance' });
  }
}