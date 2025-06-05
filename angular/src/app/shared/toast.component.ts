import { Component, OnDestroy } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ToastService, ToastMessage } from './toast.service';
import { Subscription } from 'rxjs';

@Component({
  selector: 'app-toast',
  standalone: true,
  imports: [CommonModule],
  template: `
    <div *ngIf="toast" class="toast-container position-fixed bottom-0 end-0 p-3" style="z-index: 1100;">
      <div class="toast show align-items-center text-white bg-{{toast.type}} border-0" role="alert">
        <div class="d-flex">
          <div class="toast-body">{{ toast.message }}</div>
        </div>
      </div>
    </div>
  `,
  styles: [`
    .toast-container { min-width: 250px; }
    .bg-success { background-color: #28a745 !important; }
    .bg-error { background-color: #dc3545 !important; }
    .bg-info { background-color: #17a2b8 !important; }
  `]
})
export class ToastComponent implements OnDestroy {
  toast: ToastMessage | null = null;
  private sub: Subscription;

  constructor(private toastService: ToastService) {
    this.sub = this.toastService.toast$.subscribe(t => this.toast = t);
  }

  ngOnDestroy() {
    this.sub.unsubscribe();
  }
}
