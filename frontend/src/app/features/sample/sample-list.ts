import { ChangeDetectionStrategy, Component, OnInit, inject, signal } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { RouterLink } from '@angular/router';
import { SampleApi } from '@app/api/sample.api';
import { Paged, SampleItem } from '@app/api/models';
import { problemMessage } from '@app/util/problem';

@Component({
  selector: 'app-sample-list',
  changeDetection: ChangeDetectionStrategy.OnPush,
  imports: [FormsModule, RouterLink],
  template: `
    <h1>Samples</h1>

    <div style="display:flex;gap:0.5rem;margin:1rem 0">
      <input
        [ngModel]="newName()"
        (ngModelChange)="newName.set($event)"
        placeholder="Nombre del nuevo item"
        style="flex:1"
      />
      <button (click)="create()" [disabled]="!newName().trim()">Agregar</button>
    </div>

    @if (error()) { <p style="color:#dc2626">{{ error() }}</p> }
    @if (loading()) { <p>Cargando…</p> }

    @if (result(); as r) {
      @if (r.items.length === 0) {
        <p>Aun no hay items.</p>
      } @else {
        <ul>
          @for (s of r.items; track s.id) {
            <li><a [routerLink]="['/samples', s.id]">{{ s.name }}</a></li>
          }
        </ul>
      }
    }
  `,
})
export class SampleList implements OnInit {
  private readonly api = inject(SampleApi);

  readonly result = signal<Paged<SampleItem> | null>(null);
  readonly loading = signal(false);
  readonly error = signal<string | null>(null);
  readonly newName = signal('');

  ngOnInit(): void {
    this.load();
  }

  load(): void {
    this.loading.set(true);
    this.error.set(null);
    this.api.list().subscribe({
      next: (r) => {
        this.result.set(r);
        this.loading.set(false);
      },
      error: (e) => {
        this.error.set(problemMessage(e));
        this.loading.set(false);
      },
    });
  }

  create(): void {
    const name = this.newName().trim();
    if (!name) return;
    this.api.create({ name }).subscribe({
      next: () => {
        this.newName.set('');
        this.load();
      },
      error: (e) => this.error.set(problemMessage(e)),
    });
  }
}