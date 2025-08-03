export * from './string.ts';

export function delay(ms: number = 300): Promise<void> {
  return new Promise((resolve) => setTimeout(resolve, ms));
}
export function handleError(e: unknown) {
  console.error(e);
  return e instanceof Error ? e.message : typeof e === 'string' ? e : 'Unknow error';
}
