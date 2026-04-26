import { inject, Injectable } from '@angular/core';
import { environment } from '../../../environments/environment';
import { HttpClient, HttpParams } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Employee, EmployeeList } from '../models/employee.model';

@Injectable({
  providedIn: 'root',
})
export class EmployeeService {
  private readonly baseUrl = `${environment.apiBaseUrl}employee`;
  private http = inject(HttpClient);

  getEmployees(idClient: number): Observable<EmployeeList[]> {
    return this.http.get<EmployeeList[]>(
      `${this.baseUrl}`,
      { params: new HttpParams().set('idClient', idClient) }
    );
  }

  getEmployeeDetails(idClient: number, id: number): Observable<Employee> {
    return this.http.get<Employee>(
      `${this.baseUrl}/details`,
      {
        params: new HttpParams()
          .set('idClient', idClient)
          .set('id', id)
      }
    );
  }

  createEmployee(dto: Employee): Observable<any> {
    return this.http.post(`${this.baseUrl}`, dto);
  }

  updateEmployee(idClient: number, id: number, dto: Employee): Observable<any> {
    return this.http.put(
      `${this.baseUrl}`,
      dto,
      {
        params: new HttpParams()
          .set('idClient', idClient)
          .set('id', id)
      }
    );
  }

  deleteEmployee(idClient: number, id: number): Observable<any> {
    return this.http.delete(
      `${this.baseUrl}`,
      {
        params: new HttpParams()
          .set('idClient', idClient)
          .set('id', id)
      }
    );
  }

}
