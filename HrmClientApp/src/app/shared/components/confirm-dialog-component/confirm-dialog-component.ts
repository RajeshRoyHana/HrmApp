import { Component, HostListener, inject } from '@angular/core';
import { ConfirmDialogService } from '../../services/confirm-dialog-service';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-confirm-dialog-component',
  imports: [CommonModule],
  templateUrl: './confirm-dialog-component.html',
  styleUrl: './confirm-dialog-component.css',
})
export class ConfirmDialogComponent {

confirmDialog = inject(ConfirmDialogService);

  dialogClass(type?: string): string {
    const map: Record<string, string> = {
      danger: 'dialog-danger',
      warning: 'dialog-warning',
      info: 'dialog-info'
    };
    return map[type ?? 'warning'] ?? 'dialog-warning';
  }

  iconClass(type?: string): string {
    const map: Record<string, string> = {
      danger: 'bi bi-trash-fill',
      warning: 'bi bi-exclamation-triangle-fill',
      info: 'bi bi-info-circle-fill'
    };
    return map[type ?? 'warning'] ?? 'bi bi-question-circle-fill';
  }

  @HostListener('document:keydown.escape')
  onEsc(): void {
    if (this.confirmDialog.dialog()?.open) {
      this.confirmDialog.cancel();
    }
  }

}
