import { ChangeDetectionStrategy, Component } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { Header } from './shared/layout/header';
import { Footer } from './shared/layout/footer';

@Component({
  selector: 'app-root',
  changeDetection: ChangeDetectionStrategy.OnPush,
  imports: [RouterOutlet, Header, Footer],
  template: `
    <app-header />
    <main style="padding:1rem;max-width:900px;margin:0 auto">
      <router-outlet />
    </main>
    <app-footer />
  `,
})
export class App {}