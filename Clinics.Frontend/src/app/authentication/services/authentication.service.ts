import { Injectable } from '@angular/core';
import { AppModule } from '../../app.module';
import { HttpClient, HttpErrorResponse, HttpHeaders, HttpResponse } from '@angular/common/http';
import * as config from "../../../../config";
import { LoginCommand } from '../classes/Login/login-command';
import { LoginResponse } from '../classes/Login/login-response';
import { catchError, map, Observable, of } from 'rxjs';
import { LoginResult } from '../classes/Login/login-result';
import { JWTHandler } from './jwtHandler';
import { UserData } from '../classes/user-data';
import { Roles } from '../classes/roles';

@Injectable({
  providedIn: AppModule
})
export class AuthenticationService {

  //#region CTOR DI
  constructor(private http: HttpClient) { }
  //#endregion

  //#region Constants

  private readonly USERS_ENDPOINT: string = `${config.apiUrl}/Users`

  //#endregion

  //#region Login
  private postLogin(loginCommand: LoginCommand): Observable<LoginResponse> {
    return this.http.post<LoginResponse>(
        this.USERS_ENDPOINT, loginCommand);
  }

  login(loginCommand: LoginCommand): Observable<LoginResult> {
    return this.postLogin(loginCommand).pipe(
      map((loginResponse: LoginResponse) => {
        JWTHandler.storeJWT(loginResponse.jwt);
        return new LoginResult(true, '');
      }),
      catchError((error: HttpErrorResponse) => {
        return of(new LoginResult(false, error.error.detail));
      })
    );
  }
  //#endregion

  //#region Logout
  logout(): void {
    JWTHandler.deleteJwtCookie();
  }
  //#endregion

  //#region Get user data
  getUserData(): UserData | null{
    let jwt = JWTHandler.getJwtFromCookie();
    if (jwt)
    {
      let jwtJson = JWTHandler.decodeJWT(jwt);

      let id = jwtJson.id;
      let userName = jwtJson.userName;
      let role = jwtJson.role;
      let fullName = jwtJson.fullName;

      if (fullName)
        return new UserData(id, userName, role, fullName);
      if (role == Roles.Admin)
        return new UserData(id, userName, role, Roles.Admin);
      return null;
    }
    return null;
  }
  //#endregion


}
