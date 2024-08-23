import { Injectable } from '@angular/core';
import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import { catchError, map, Observable, of } from 'rxjs';
import * as config from '../../../../../config';
import { GetAllDoctorUsersResult } from '../list-doctor-users/classes/get-all-doctor-users-result';
import { GetAllDoctorUsersResponse } from '../list-doctor-users/classes/get-all-doctor-users-response';
import { CreateDoctorUserCommand } from '../create-doctor-user/classes/create-doctor-user-command';
import { CreateDoctorUserResult } from '../create-doctor-user/classes/create-doctor-user-result';
import { DoctorUserResponse } from '../update-doctor-user/classes/doctor-user-response';

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
  
  // #region Create doctor user
  createDoctorUser(command: CreateDoctorUserCommand) : Observable<CreateDoctorUserResult> {
    return this.http.post(this.DOCTORUSERS_ENDPOINT, command)
    .pipe(
      map (_ => {
        return new CreateDoctorUserResult(true);
      }),
      catchError((error: HttpErrorResponse) => {
        return of(new CreateDoctorUserResult(false, error.error.detail))
      })
    );
  }
  // #endregion

  // #region Get doctor user by Id
  getDoctorUserById(id: number): Observable<DoctorUserResponse | null>
  {
    return this.http.get<DoctorUserResponse>(`${this.DOCTORUSERS_ENDPOINT}/${id}`)
    .pipe(
      map((doctorUser: DoctorUserResponse) => {
        return doctorUser;
      }),
      catchError((error: HttpErrorResponse) => {
        return of(null);
      })
    )
  }
  // #endregion
  
  // #endregion
}