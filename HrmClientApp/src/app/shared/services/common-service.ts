import { inject, Injectable } from '@angular/core';
import { environment } from '../../environments/environment';
import { Observable } from 'rxjs';
import { Dropdown } from '../models/dropdown';
import { HttpClient, HttpParams } from '@angular/common/http';

@Injectable({
  providedIn: 'root',
})
export class CommonService {
  private readonly baseUrl = `${environment.apiBaseUrl}common`;

  private http = inject(HttpClient);


  private withClient(idClient: number): HttpParams {
    return new HttpParams().set('idClient', idClient);
  }

  getDepartments(idClient: number): Observable<Dropdown[]> {
    return this.http.get<Dropdown[]>(
      `${this.baseUrl}/departmentdropdown`,
      { params: this.withClient(idClient) }
    );
  }

  getDesignations(idClient: number): Observable<Dropdown[]> {
    return this.http.get<Dropdown[]>(
      `${this.baseUrl}/designationdropdown`,
      { params: this.withClient(idClient) }
    );
  }

  getSections(idClient: number): Observable<Dropdown[]> {
    return this.http.get<Dropdown[]>(
      `${this.baseUrl}/sectionsdropdown`,
      { params: this.withClient(idClient) }
    );
  }

  getGenders(idClient: number): Observable<Dropdown[]> {
    return this.http.get<Dropdown[]>(
      `${this.baseUrl}/gendersdropdown`,
      { params: this.withClient(idClient) }
    );
  }

  getReligions(idClient: number): Observable<Dropdown[]> {
    return this.http.get<Dropdown[]>(
      `${this.baseUrl}/religionsdropdown`,
      { params: this.withClient(idClient) }
    );
  }

  getMaritalStatuses(idClient: number): Observable<Dropdown[]> {
    return this.http.get<Dropdown[]>(
      `${this.baseUrl}/maritalstatusesdropdown`,
      { params: this.withClient(idClient) }
    );
  }

  getRelationships(idClient: number): Observable<Dropdown[]> {
    return this.http.get<Dropdown[]>(
      `${this.baseUrl}/relationshipsdropdown`,
      { params: this.withClient(idClient) }
    );
  }

  getJobTypes(idClient: number): Observable<Dropdown[]> {
    return this.http.get<Dropdown[]>(
      `${this.baseUrl}/jobtypesdropdown`,
      { params: this.withClient(idClient) }
    );
  }

  getEmployeeTypes(idClient: number): Observable<Dropdown[]> {
    return this.http.get<Dropdown[]>(
      `${this.baseUrl}/employeetypesdropdown`,
      { params: this.withClient(idClient) }
    );
  }

  getEducationLevels(idClient: number): Observable<Dropdown[]> {
    return this.http.get<Dropdown[]>(
      `${this.baseUrl}/educationlevelsdropdown`,
      { params: this.withClient(idClient) }
    );
  }

  getEducationExams(idClient: number): Observable<Dropdown[]> {
    return this.http.get<Dropdown[]>(
      `${this.baseUrl}/educationexaminationsdropdown`,
      { params: this.withClient(idClient) }
    );
  }

  getWeekOffs(idClient: number): Observable<Dropdown[]> {
    return this.http.get<Dropdown[]>(
      `${this.baseUrl}/weekoffsdropdown`,
      { params: this.withClient(idClient) }
    );
  }

}
