export function formatNumber(value: number, decimals: number = 2, locales: string = "en-US"): string {
  return new Intl.NumberFormat(locales, {
    minimumFractionDigits: decimals,
    maximumFractionDigits: decimals,
  }).format(value);
}

export function formatCrypto(value: number, symbol: string, decimals: number = 6, locales: string = "en-US"): string {
  return `${new Intl.NumberFormat(locales, {
    minimumFractionDigits: 0,
    maximumFractionDigits: decimals,
  }).format(value)} ${symbol}`;
}
/**
 * Format số thành currency (USD mặc định)
 * @param value số
 * @param currency ký hiệu tiền tệ (USD, VND, EUR...)
 * @param decimals Số số 0 sau dấu thập phân
 * @param locales Quốc gia
 */
export function formatCurrency(value: number, currency: string = "USD", decimals: number = 2, locales: string = "en-US"): string {
  return new Intl.NumberFormat(locales, {
    style: "currency",
    currency,
    minimumFractionDigits: 0,
    maximumFractionDigits: decimals,
  }).format(value);
}
/**
 * Format số dư thông minh:
 * - Số lớn: rút gọn thành K/M/B/T
 * - Số nhỏ: có dấu phẩy nghìn
 * - Giữ tối đa `decimals` số lẻ
 */
export function formatCurrencySmart(
  value: number,
  currency: string = "USD",
  decimals: number = 2,
  locales: string = "en-US",
): string {
  if (!value) return "0";

  // Nếu quá lớn, dùng compact notation (K, M, B, T)
  if (Math.abs(value) >= 1e6) {
    return new Intl.NumberFormat(locales, {
      currency,
      style: "currency",
      notation: "compact",
      maximumFractionDigits: decimals,
    }).format(value);
  }

  // Nếu nhỏ hơn 1e-6 (rất nhỏ) → scientific notation
  if (Math.abs(value) < 1e-6) {
    return value.toExponential(decimals);
  }

  // Ngược lại: format bình thường
  return formatCurrency(value, currency, decimals, locales);
}
