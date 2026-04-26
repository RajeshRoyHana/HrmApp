import { Component, signal } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { EmployeeForm } from './features/Employee/employee-form/employee-form';

@Component({
  selector: 'app-root',
  imports: [RouterOutlet, EmployeeForm],
  templateUrl: './app.html',
  styleUrl: './app.css'
})
export class App {
  protected readonly title = signal('Hrm Application');
}
