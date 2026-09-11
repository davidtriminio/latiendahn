import { ChangeDetectionStrategy, Component } from '@angular/core';

@Component({
  selector: 'app-footer',
  changeDetection: ChangeDetectionStrategy.OnPush,
  template: `
    <footer style="padding:1rem;border-top:1px solid #eee;color:#6b7280;font-size:0.85rem">
      latiendahn — base .NET 10 + Angular 22
    </footer>
  `,
})
export class Footer {}