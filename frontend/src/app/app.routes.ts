import { Routes } from '@angular/router';

export const routes: Routes = [
  { path: '', pathMatch: 'full', redirectTo: 'samples' },
  {
    path: 'samples',
    loadComponent: () => import('./features/sample/sample-list').then((m) => m.SampleList),
  },
  {
    path: 'samples/:id',
    loadComponent: () => import('./features/sample/sample-detail').then((m) => m.SampleDetail),
  },
  { path: '**', redirectTo: 'samples' },
];