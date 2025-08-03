export function pascalToWords(str: string) {
  return str.replace(/([A-Z])/g, ' $1').trim();
}

export function camelToWords(str: string): string {
  return str.replace(/([a-z])([A-Z])/g, '$1 $2').replace(/([A-Z])([A-Z][a-z])/g, '$1 $2');
}

export function kebabToWords(str: string): string {
  return str.replace(/-/g, ' ');
}

export function snakeToWords(str: string): string {
  return str.replace(/_/g, ' ');
}

export function capitalize(str: string): string {
  return str.charAt(0).toUpperCase() + str.slice(1);
}

export function titleCase(str: string): string {
  return str
    .toLowerCase()
    .split(/[\s_-]+/)
    .map(capitalize)
    .join(' ');
}
