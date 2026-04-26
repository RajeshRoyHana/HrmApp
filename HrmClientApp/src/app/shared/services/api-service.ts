import { HttpClient, HttpParams } from '@angular/common/http';
import { inject, Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from '../../environments/environment';

@Injectable({
  providedIn: 'root',
})
export class ApiService {
  
private baseUrl = environment.apiBaseUrl;

  private http = inject(HttpClient);

  get<T = any>(url: string, params?: any): Observable<T> {
    return this.http.get<T>(this.baseUrl + url, {
      params: this.buildParams(params)
    });
  }

  post<T = any>(url: string, body: any, params?: any): Observable<T> {
    return this.http.post<T>(this.baseUrl + url, body, {
      params: this.buildParams(params)
    });
  }

  put<T = any>(url: string, body: any, params?: any): Observable<T> {
    return this.http.put<T>(this.baseUrl + url, body, {
      params: this.buildParams(params)
    });
  }

  delete<T = any>(url: string, params?: any): Observable<T> {
    return this.http.delete<T>(this.baseUrl + url, {
      params: this.buildParams(params)
    });
  }

  private buildParams(params?: any): HttpParams {
    let httpParams = new HttpParams();
    if (params) {
      Object.keys(params).forEach(key => {
        if (params[key] !== null && params[key] !== undefined) {
          httpParams = httpParams.set(key, params[key]);
        }
      });
    }
    return httpParams;
  }

}
