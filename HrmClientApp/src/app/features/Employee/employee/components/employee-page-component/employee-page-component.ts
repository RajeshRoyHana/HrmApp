import { Component, inject, signal } from '@angular/core';
import { EmployeeStateService } from '../../../services/employee-state.service';
import { CommonModule } from '@angular/common';
import { EmployeeFormComponent } from '../employee-form-component/employee-form-component';
import { EmployeeListComponent } from '../employee-list-component/employee-list-component';

@Component({
  selector: 'app-employee-page-component',
  imports: [CommonModule,EmployeeListComponent,EmployeeFormComponent],
  templateUrl: './employee-page-component.html',
  styleUrl: './employee-page-component.css',
})
export class EmployeePageComponent {
}
