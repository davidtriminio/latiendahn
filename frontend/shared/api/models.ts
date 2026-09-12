export interface Paged<T> {
  items: T[];
  page: number;
  pageSize: number;
  totalItems: number;
  totalPages: number;
  hasNext: boolean;
  hasPrevious: boolean;
}

export interface SampleItem {
  id: string;
  name: string;
  description: string | null;
  createdOn: string;
}

export interface CreateSampleRequest {
  name: string;
  description?: string | null;
}

export interface ProblemDetails {
  title?: string;
  detail?: string;
  status?: number;
  errors?: Record<string, string[]>;
}