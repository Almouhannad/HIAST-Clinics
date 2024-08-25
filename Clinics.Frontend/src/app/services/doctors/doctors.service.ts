import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import { Injectable } from '@angular/core';
import * as config from '../../../../config';
import { catchError, map, Observable, of } from 'rxjs';
import { Doctor } from '../../classes/doctor/doctor';

@Injectable({
  providedIn: 'root'
})
export class DoctorsService {

  constructor(private http: HttpClient) { }
  private readonly DOCTORS_ENDPOINT: string = `${config.apiUrl}/Doctors`;

  getAll(): Observable<Doctor[] | null> {
    return this.http.get<{doctors: Doctor[]}>(this.DOCTORS_ENDPOINT)
    .pipe(
      map((response : {doctors: Doctor[]}) => {
        console.log(response.doctors);
        return response.doctors;
      }),
      catchError((error: HttpErrorResponse) => {
        console.error(error);
        return of (null);
      })
    )
  }

  getAvailable(): Observable< {id: number, name: string}[] | null > {
    return this.http.get<{availableDoctors: {id: number, name: string}[] }>(`${this.DOCTORS_ENDPOINT}/Available`)
    .pipe(
      map((result) => {
        return result.availableDoctors;
      }),
      catchError((error: HttpErrorResponse) => {
        console.error(error.error.detail);
        return of (null);
      })
    );
  }
}
