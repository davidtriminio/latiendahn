import { ChangeDetectionStrategy, Component, OnInit, inject, input, signal } from '@angular/core';
import { SampleApi } from '@app/api/sample.api';
import { SampleItem } from '@app/api/models';
import { problemMessage } from '@app/util/problem';

@Component({
  selector: 'app-sample-detail',
  changeDetection: ChangeDetectionStrategy.OnPush,
  template: `
    @if (error()) { <p style="color:#dc2626">{{ error() }}</p> }
    @if (loading()) { <p>Cargando…</p> }
    @if (item(); as s) {
      <h1>{{ s.name }}</h1>
      <p>{{ s.description }}</p>
      <small>Creado: {{ s.createdOn }}</small>
    }
  `,
})
export class SampleDetail implements OnInit {
  private readonly api = inject(SampleApi);

  // Binding del parametro de ruta :id (requiere withComponentInputBinding()).
  readonly id = input.required<string>();

  readonly item = signal<SampleItem | null>(null);
  readonly loading = signal(false);
  readonly error = signal<string | null>(null);

  ngOnInit(): void {
    this.loading.set(true);
    this.api.get(this.id()).subscribe({
      next: (s) => {
        this.item.set(s);
        this.loading.set(false);
      },
      error: (e) => {
        this.error.set(problemMessage(e));
        this.loading.set(false);
      },
    });
  }
}