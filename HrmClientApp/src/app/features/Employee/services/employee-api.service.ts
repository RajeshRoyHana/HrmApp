import { Injectable, inject } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';
import { Observable } from 'rxjs';
import { environment } from '../../../../environments/environment';
import {
  DropdownDto, EmployeeDto, EmployeeListDto
} from '../models/employee.models';

@Injectable({ providedIn: 'root' })
export class EmployeeApiService {
  private http = inject(HttpClient);
  private base = environment.apiBaseUrl;
  private idClient = environment.idClient;

  // ── Common dropdowns ──────────────────────────────────────────
  getDepartments(): Observable<DropdownDto[]> {
    return this.http.get<DropdownDto[]>(`${this.base}common/departmentdropdown`, {
      params: { idClient: this.idClient }
    });
  }
  getSections(): Observable<DropdownDto[]> {
    return this.http.get<DropdownDto[]>(`${this.base}common/sectionsdropdown`, {
      params: { idClient: this.idClient }
    });
  }
  getDesignations(): Observable<DropdownDto[]> {
    return this.http.get<DropdownDto[]>(`${this.base}common/designationdropdown`, {
      params: { idClient: this.idClient }
    });
  }
  getGenders(): Observable<DropdownDto[]> {
    return this.http.get<DropdownDto[]>(`${this.base}common/gendersdropdown`, {
      params: { idClient: this.idClient }
    });
  }
  getReligions(): Observable<DropdownDto[]> {
    return this.http.get<DropdownDto[]>(`${this.base}common/religionsdropdown`, {
      params: { idClient: this.idClient }
    });
  }
  getMaritalStatuses(): Observable<DropdownDto[]> {
    return this.http.get<DropdownDto[]>(`${this.base}common/maritalstatusesdropdown`, {
      params: { idClient: this.idClient }
    });
  }
  getJobTypes(): Observable<DropdownDto[]> {
    return this.http.get<DropdownDto[]>(`${this.base}common/jobtypesdropdown`, {
      params: { idClient: this.idClient }
    });
  }
  getEmployeeTypes(): Observable<DropdownDto[]> {
    return this.http.get<DropdownDto[]>(`${this.base}common/employeetypesdropdown`, {
      params: { idClient: this.idClient }
    });
  }
  getWeekOffs(): Observable<DropdownDto[]> {
    return this.http.get<DropdownDto[]>(`${this.base}common/weekoffsdropdown`, {
      params: { idClient: this.idClient }
    });
  }
  getRelationships(): Observable<DropdownDto[]> {
    return this.http.get<DropdownDto[]>(`${this.base}common/relationshipsdropdown`, {
      params: { idClient: this.idClient }
    });
  }
  getEducationLevels(): Observable<DropdownDto[]> {
    return this.http.get<DropdownDto[]>(`${this.base}common/educationlevelsdropdown`, {
      params: { idClient: this.idClient }
    });
  }
  getEducationExaminations(): Observable<DropdownDto[]> {
    return this.http.get<DropdownDto[]>(`${this.base}common/educationexaminationsdropdown`, {
      params: { idClient: this.idClient }
    });
  }

  getEducationResults(): Observable<DropdownDto[]> {
    return this.http.get<DropdownDto[]>(`${this.base}common/educationresultsdropdown`, {
      params: { idClient: this.idClient }
    });
  }

  // ── Employee CRUD ─────────────────────────────────────────────
  getEmployeeList(): Observable<EmployeeListDto[]> {
    return this.http.get<EmployeeListDto[]>(`${this.base}employee`, {
      params: { idClient: this.idClient }
    });
  }

  getEmployeeDetails(id: number): Observable<EmployeeDto> {
    return this.http.get<EmployeeDto>(`${this.base}employee/details`, {
      params: { idClient: this.idClient, id }
    });
  }

  addEmployee(dto: EmployeeDto): Observable<any> {
    return this.http.post(`${this.base}employee`, dto);
  }

  updateEmployee(id: number, dto: EmployeeDto): Observable<any> {
    return this.http.put(`${this.base}employee`, dto, {
      params: { idClient: this.idClient, id }
    });
  }

  deleteEmployee(id: number): Observable<any> {
    return this.http.delete(`${this.base}employee`, {
      params: { idClient: this.idClient, id }
    });
  }
}
