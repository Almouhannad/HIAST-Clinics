import { Injectable } from '@angular/core';
import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import { catchError, map, Observable, of } from 'rxjs';
import * as config from '../../../../../config';
import { DoctorUser } from '../list-doctor-users/classes/doctor-user';
import { GetAllDoctorUsersResult } from '../list-doctor-users/classes/get-all-doctor-users-result';
import { GetAllDoctorUsersResponse } from '../list-doctor-users/classes/get-all-doctor-users-response';

@Injectable({
  providedIn: 'root'
})
export class DoctorUsersService {

  // #region DI CTOR
  constructor(private http: HttpClient) { }
  // #endregion

  // #region Constants
  private readonly DOCTORUSERS_ENDPOINT: string = `${config.apiUrl}/Users/Doctors`;
  // #endregion

  // #region Methods

  // #region Get all doctor users
  getDoctorUsers(): Observable<GetAllDoctorUsersResult> {
    return this.http
    .get<GetAllDoctorUsersResponse>(this.DOCTORUSERS_ENDPOINT)
    .pipe(
      map((getAllDoctorUsersResponse: GetAllDoctorUsersResponse) => {
        return new GetAllDoctorUsersResult(true, '', getAllDoctorUsersResponse.doctorUsers);
      }),
      catchError((error: HttpErrorResponse) => {
        return of(new GetAllDoctorUsersResult(false, error.error.detail))
      })
    )
  }
  // #endregion
  
  // #endregion
}