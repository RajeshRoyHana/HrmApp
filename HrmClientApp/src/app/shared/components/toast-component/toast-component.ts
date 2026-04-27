import { Component, inject } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ToastService } from '../../services/toast.service';

@Component({
  selector: 'app-toast-component',
  imports: [CommonModule],
  templateUrl: './toast-component.html',
  styleUrl: './toast-component.css',
})
export class ToastComponent {
 toast = inject(ToastService);

  toastClass(type: string): string {
    const map: Record<string, string> = {
      success: 'text-bg-success',
      error: 'text-bg-danger',
      warning: 'text-bg-warning',
      info: 'text-bg-info'
    };
    return map[type] ?? 'text-bg-secondary';
  }

  iconClass(type: string): string {
    const map: Record<string, string> = {
      success: 'bi bi-check-circle-fill',
      error: 'bi bi-x-circle-fill',
      warning: 'bi bi-exclamation-triangle-fill',
      info: 'bi bi-info-circle-fill'
    };
    return map[type] ?? 'bi bi-bell-fill';
  }
}
