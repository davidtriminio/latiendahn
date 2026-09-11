import { ChangeDetectionStrategy, Component } from '@angular/core';
import { RouterLink } from '@angular/router';

@Component({
  selector: 'app-header',
  changeDetection: ChangeDetectionStrategy.OnPush,
  imports: [RouterLink],
  template: `
    <header style="padding:1rem;border-bottom:1px solid #eee">
      <a routerLink="/samples"><strong>latiendahn</strong></a>
    </header>
  `,
})
export class Header {}