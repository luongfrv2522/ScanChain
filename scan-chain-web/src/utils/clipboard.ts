/**
 * Copy text vào clipboard (yêu cầu https hoặc localhost)
 * @param text Chuỗi cần copy
 * @returns Promise<boolean> true nếu copy thành công
 */
export async function copyToClipboard(text: string): Promise<boolean> {
  try {
    await navigator.clipboard.writeText(text);
    return true;
  } catch (err) {
    console.error("Copy failed:", err);
    return false;
  }
}
