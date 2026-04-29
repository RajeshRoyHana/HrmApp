import { Injectable, inject, signal, computed } from '@angular/core';
import { EmployeeDto, EmployeeListDto, FormMode, PageStatus } from '../models/employee.models';
import { EmployeeApiService } from './employee-api.service';

import { environment } from '../../../../environments/environment';
import { ToastService } from '../../../shared/services/toast.service';

@Injectable({ providedIn: 'root' })
export class EmployeeStateService {
  private api   = inject(EmployeeApiService);
  private toast = inject(ToastService);

  readonly employeeList     = signal<EmployeeListDto[]>([]);
  readonly selectedEmployee = signal<EmployeeDto | null>(null);
  readonly mode             = signal<FormMode>('disabled');
  readonly status           = signal<PageStatus>('idle');
  readonly searchQuery      = signal('');

  readonly loading = computed(() => this.status() === 'loading');
  readonly saving  = computed(() => this.status() === 'saving');

  readonly filteredList = computed(() => {
    const q = this.searchQuery().toLowerCase();
    return this.employeeList().filter(e =>
      (e.employeeName ?? '').toLowerCase().includes(q) ||
      (e.designationName ?? '').toLowerCase().includes(q) ||
      String(e.id).includes(q)
    );
  });

  loadList(): void {
    this.status.set('loading');
    this.api.getEmployeeList().subscribe({
      next: list => { this.employeeList.set(list); this.status.set('idle'); },
      error: ()   => { this.toast.error('Failed to load employee list'); this.status.set('error'); }
    });
  }

  selectEmployee(id: number): void {
    this.status.set('loading');
    this.api.getEmployeeDetails(id).subscribe({
      next: emp => {
        this.selectedEmployee.set(emp);
        this.mode.set('view');
        this.status.set('idle');
      },
      error: () => { this.toast.error('Failed to load employee details'); this.status.set('error'); }
    });
  }

  // FIX: set null first, then mode — effect fires once with mode=add, emp=null
  startAdd(): void {
    this.selectedEmployee.set(null);
    this.mode.set('add');
  }

  startEdit(): void {
    this.mode.set('edit');
  }

  cancelAdd(): void {
    const prev = this.selectedEmployee();
    if (prev?.id) {
      this.selectEmployee(prev.id);
    } else {
      this.mode.set('disabled');
      this.selectedEmployee.set(null);
    }
  }

  // cancelWithRemove(): void{
  //      const prev = this.selectedEmployee();
  //   if (prev?.id) {
  //     this.selectEmployee(prev.id);
  //   } else {
  //     this.mode.set('disabled');
  //     this.selectedEmployee.set(null);
  //   }
  // }

  cancelEdit(): void {
    const prev = this.selectedEmployee();
    if (prev?.id) {
      this.selectEmployee(prev.id);
    } else {
      this.mode.set('disabled');
      this.selectedEmployee.set(null);
    }
  }

  save(dto: EmployeeDto): void {
    this.status.set('saving');
    const isEdit = this.mode() === 'edit' && !!dto.id;
    const call   = isEdit
      ? this.api.updateEmployee(dto.id!, dto)
      : this.api.addEmployee(dto);

    call.subscribe({
      next: (res: any) => {
        this.toast.success(isEdit ? 'Employee updated successfully' : 'Employee added successfully');
        this.status.set('idle');
        this.loadList();
        if (isEdit) {
          this.selectEmployee(dto.id!);
        } else {
          const newId = res?.employeeId ?? 0;
          if (newId) {
            this.selectEmployee(newId);
          } else {
            this.mode.set('disabled');
            this.selectedEmployee.set(null);
          }
        }
      },
      error: () => {
        this.toast.error('Failed to save employee. Please try again.');
        this.status.set('error');
      }
    });
  }

  deleteEmployee(id: number): void {
    this.api.deleteEmployee(id).subscribe({
      next: () => {
        this.toast.success('Employee deleted');
        this.employeeList.update(list => list.filter(e => e.id !== id));
        this.mode.set('disabled');
        this.selectedEmployee.set(null);
      },
      error: () => this.toast.error('Failed to delete employee')
    });
  }
}
