import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import { Injectable } from '@angular/core';
import * as config from '../../../../config';
import { EmployeeData } from '../../classes/employeeData/employee-data';
import { catchError, map, Observable, of } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class EmployeesDataService {

  constructor(private http: HttpClient) { }
  private readonly EMPLOYEES_ENDPOINT: string = `${config.apiUrl}/Employees`;

  create(employeeData: EmployeeData): Observable<{ status: boolean, errorMessage: string | null, id: number | null }> {
    const body: any = { // No id in create method
      firstName: employeeData.firstName,
      middleName: employeeData.middleName,
      lastName: employeeData.lastName,
      dateOfBirth: employeeData.dateOfBirth,
      gender: employeeData.gender,
      serialNumber: employeeData.serialNumber.toString(),
      centerStatus: employeeData.centerStatus,
    };
    console.log(body);
    return this.http.post<{id: number}>(this.EMPLOYEES_ENDPOINT, body)
      .pipe(
        map((response: {id: number}) => {
          return { status: true, errorMessage: null, id: response.id};
        }),
        catchError((error: HttpErrorResponse) => {
          console.error(error);
          return of({ status: false, errorMessage: error.error.detail, id: null })
        })
      );
  }

  getBySerialNumber(serialNumber: string): Observable<{ status: boolean, errorMessage: string | null, employeeData: EmployeeData | null }> {
    const body = {serialNumber: serialNumber.toString()};
    return this.http.post<EmployeeData>(`${this.EMPLOYEES_ENDPOINT}/SerialNumber`, body)
    .pipe(
      map((response: EmployeeData) => {
        return {status: true, errorMessage: null, employeeData: response};
      }),
      catchError((error: HttpErrorResponse) => {
        return of ({status: false, errorMessage: error.error.detail, employeeData: null});
      })
    );
  }

  getById(id: number): Observable<{ status: boolean, errorMessage: string | null, employeeData: EmployeeData | null }> {
    return this.http.get<EmployeeData>(`${this.EMPLOYEES_ENDPOINT}/${id}`,)
    .pipe(
      map((response: EmployeeData) => {
        return {status: true, errorMessage: null, employeeData: response};
      }),
      catchError((error: HttpErrorResponse) => {
        return of ({status: false, errorMessage: error.error.detail, employeeData: null});
      })
    );
  }
}
