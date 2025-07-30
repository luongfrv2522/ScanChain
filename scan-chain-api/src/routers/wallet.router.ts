import { Router } from 'express';
import { getNativeBalance } from '@app/controllers/wallet.controller';

const router = Router();

router.get('/balance', getNativeBalance);

export default router;