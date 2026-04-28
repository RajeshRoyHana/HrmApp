import { Component, signal } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { ToastComponent } from './shared/components/toast-component/toast-component';
import { ConfirmDialogComponent } from './shared/components/confirm-dialog-component/confirm-dialog-component';


@Component({
  selector: 'app-root',
  imports: [RouterOutlet,ToastComponent, ConfirmDialogComponent],
  templateUrl: './app.html',
  styleUrl: './app.css'
})
export class App {
  protected readonly title = signal('Hrm Application');
}
