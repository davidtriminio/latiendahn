import { InjectionToken } from '@angular/core';

/** Origen base para llamadas al API (vacio en dev; el dev-server hace proxy de "/api"). */
export const API_BASE_URL = new InjectionToken<string>('API_BASE_URL');