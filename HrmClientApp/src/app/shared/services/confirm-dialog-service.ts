import { Injectable, signal } from '@angular/core';


export interface ConfirmDialogOptions {
  title?: string;
  message: string;
  confirmText?: string;
  cancelText?: string;
  type?: 'danger' | 'warning' | 'info';
}


interface ConfirmDialogState extends ConfirmDialogOptions {
  open: boolean;
}


@Injectable({
  providedIn: 'root',
})
export class ConfirmDialogService {

  readonly dialog = signal<ConfirmDialogState | null>(null);

  private resolver: ((value: boolean) => void) | null = null;

  confirm(options: ConfirmDialogOptions): Promise<boolean> {
    return new Promise<boolean>((resolve) => {
      this.resolver = resolve;
      this.dialog.set({
        open: true,
        title: options.title ?? 'Confirm',
        message: options.message,
        confirmText: options.confirmText ?? 'Yes',
        cancelText: options.cancelText ?? 'Cancel',
        type: options.type ?? 'warning'
      });
    });
  }

  confirmDelete(message = 'Are you sure you want to delete this item?'): Promise<boolean> {
    return this.confirm({
      title: 'Delete Confirmation',
      message,
      confirmText: 'Delete',
      cancelText: 'Cancel',
      type: 'danger'
    });
  }

  confirmOk(): void {
    this.resolver?.(true);
    this.close();
  }

  cancel(): void {
    this.resolver?.(false);
    this.close();
  }

  close(): void {
    this.dialog.set(null);

  }
}
