// apiBaseUrl vacio en dev: el dev-server hace proxy de "/api" (ver proxy.conf.json).
// Para produccion, define aqui el origen del API o usa fileReplacements.
export const environment = {
  production: false,
  apiBaseUrl: '',
};