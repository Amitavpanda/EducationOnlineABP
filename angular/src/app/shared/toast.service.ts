import { Injectable } from '@angular/core';
import { BehaviorSubject } from 'rxjs';

export interface ToastMessage {
  type: 'success' | 'error' | 'info';
  message: string;
}

@Injectable({ providedIn: 'root' })
export class ToastService {
  private toastSubject = new BehaviorSubject<ToastMessage | null>(null);
  toast$ = this.toastSubject.asObservable();

  show(type: ToastMessage['type'], message: string) {
    this.toastSubject.next({ type, message });
    setTimeout(() => this.toastSubject.next(null), 3000);
  }
}
