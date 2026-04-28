import { CommonModule } from '@angular/common';
import { Component, inject, OnInit } from '@angular/core';
import { RouterModule } from '@angular/router';
import { EmployeeStateService } from '../../../services/employee-state.service';


@Component({
  selector: 'app-employee-list-component',
  imports: [CommonModule, RouterModule],
  templateUrl: './employee-list-component.html',
  styleUrl: './employee-list-component.css',
})
export class EmployeeListComponent implements OnInit {
  employeeService = inject(EmployeeStateService);

  ngOnInit() {
    this.employeeService.loadList();
  }

  selectEmployee(id: number) {
    this.employeeService.selectEmployee(id);
  }

  addNew() {
    this.employeeService.startNew();
  }

  deleteEmployee(emp: any) {
    if (confirm(`Delete "${emp.employeeName}"? This action cannot be undone.`)) {
      this.employeeService.deleteEmployee(emp.id);
    }
  }

  getInitials(name: string | null): string {
    if (!name) return '?';
    return name.split(' ').map(w => w[0]).join('').substring(0, 2).toUpperCase();
  }
}
