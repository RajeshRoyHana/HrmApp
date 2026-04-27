import { Routes } from '@angular/router';

export const routes: Routes = [
      {
    path: '',
    redirectTo: 'employee',
    pathMatch: 'full'
  },
  {
    path: 'employee',
    loadComponent: () =>
      import('./features/Employee/employee/components/employee-page-component/employee-page-component')
        .then(m => m.EmployeePageComponent),
    title: 'Employee Management — HRM'
  },
  {
    path: '**',
    redirectTo: 'employee'
  }
];
