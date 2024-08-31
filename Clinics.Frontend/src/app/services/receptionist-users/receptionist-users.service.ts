import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import { Injectable } from '@angular/core';
import * as config from '../../../../config';
import { catchError, map, Observable, of } from 'rxjs';
import { GetAllReceptionistUsersResult } from '../../classes/usecases/admin-usecases/list-receptionist-users/get-all-receptionist-users-result';
import { ReceptionistUser } from '../../classes/usecases/admin-usecases/list-receptionist-users/receptionist-user';

@Injectable({
  providedIn: 'root'
})
export class ReceptionistUsersService {

  constructor(private http: HttpClient) { }

  private readonly RECEPTIONISTUSERS_ENDPOINT: string = `${config.apiUrl}/Users/Receptionists`;

  public getAllReceptionistUsers(): Observable<GetAllReceptionistUsersResult> {
    return this.http.get< {receptionistUsers: ReceptionistUser[]} >(this.RECEPTIONISTUSERS_ENDPOINT)
    .pipe(
      map((response: {receptionistUsers: ReceptionistUser[]}) => {
        return new GetAllReceptionistUsersResult(true,'', response.receptionistUsers);
      }),
      catchError( (error: HttpErrorResponse) => {
          return of(new GetAllReceptionistUsersResult(false, error.error.detail));
      })
    );
  }
}
