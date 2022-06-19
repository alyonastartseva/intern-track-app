export class LocalStorageHelper {
  static getData(key) {
    const result = localStorage.getItem(key);
    return result || null;
  }

  static setData(key, value) {
    localStorage.setItem(key, value);
  }
}
