import { HttpClient, HttpParams } from '@angular/common/http';
import { Injectable, inject } from '@angular/core';
import { Observable } from 'rxjs';
import { API_BASE_URL } from './api-base-url';
import { CreateSampleRequest, Paged, SampleItem } from './models';

@Injectable({ providedIn: 'root' })
export class SampleApi {
  private readonly http = inject(HttpClient);
  private readonly base = inject(API_BASE_URL) + '/api/v1/samples';

  list(page = 1, pageSize = 20): Observable<Paged<SampleItem>> {
    const params = new HttpParams().set('page', page).set('pageSize', pageSize);
    return this.http.get<Paged<SampleItem>>(`${this.base}/`, { params });
  }

  get(id: string): Observable<SampleItem> {
    return this.http.get<SampleItem>(`${this.base}/${id}`);
  }

  create(request: CreateSampleRequest): Observable<{ id: string }> {
    return this.http.post<{ id: string }>(`${this.base}/`, request);
  }
}