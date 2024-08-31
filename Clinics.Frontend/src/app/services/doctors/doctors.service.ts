import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import { Injectable } from '@angular/core';
import * as config from '../../../../config';
import { catchError, map, Observable, of } from 'rxjs';
import { Doctor } from '../../classes/doctor/doctor';
import { AuthenticationService } from '../authentication/authentication.service';
import { DoctorPhone } from '../../classes/doctor/phones/doctor-phone';
import { HttpError } from '@microsoft/signalr';

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

  getStatusByUserId(userId: number): Observable<{status: boolean, errorMessage: string | null, doctorStatus: string | null}> {
    return this.http.get<{status: string}>(`${this.DOCTORS_ENDPOINT}/Status/${userId}`)
    .pipe(
      map((response: {status: string}) => {
        return {status: true, errorMessage: null, doctorStatus: response.status};
      }),
      catchError((error: HttpErrorResponse) => {
        console.error(error.error.detail);
        return of ({status: false, errorMessage: error.error.detail, doctorStatus: null});
      })
    );
  }

  changeStatusByUserId(userId: number, doctorStatus: string): Observable<{status: boolean, errorMessage: string | null}> {
    var body = {userId: userId, status: doctorStatus};
    return this.http.post(`${this.DOCTORS_ENDPOINT}/Status`, body)
    .pipe(
      map(_ => {
        return {status: true, errorMessage: null};
      }),
      catchError((error: HttpErrorResponse) => {
        return of ({status: false, errorMessage: error.error.detail});
      })
    );
  }

  getPhoneByUserId(userId: number)
  : Observable<{status: boolean, errorMessage: string | null, phones: DoctorPhone[] | null}> {
    return this.http.get<{phones: DoctorPhone[]}>(`${this.DOCTORS_ENDPOINT}/Phones/${userId}`)
    .pipe(
      map((response: {phones: DoctorPhone[]}) => {
        return {status: true, errorMessage: null, phones: response.phones}
      }),
      catchError ((error: HttpErrorResponse) => {
        console.error(error.error.detail);
        return of({status: false, errorMessage: error.error.detail, phones: null});
      })
    )
  }

  addPhoneByUserId(userId: number, doctorPhone: DoctorPhone)
  : Observable<{status: boolean, errorMessage: string | null}> {
    var body = {
      doctorUserId: userId,
      name: doctorPhone.name,
      phone: doctorPhone.phone
    };
    return this.http.post(`${this.DOCTORS_ENDPOINT}/phones`, body)
    .pipe(
      map(_ => {
        return {status: true, errorMessage: null};
      }),
      catchError((error: HttpErrorResponse) => {
        return of ({status: false, errorMessage: error.error.detail});
      })
    )

  }
}
