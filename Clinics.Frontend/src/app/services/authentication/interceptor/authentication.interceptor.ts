import { Injectable } from '@angular/core';
import { HttpInterceptor, HttpRequest, HttpHandler, HttpEvent, HttpHeaders } from '@angular/common/http';
import { JWTHandler } from '../jwtHandler';
import { Observable } from 'rxjs';

@Injectable()
export class AuthenticationInterceptor implements HttpInterceptor {

  //#region HTTP headers
  private readonly HTTP_HEADERS: HttpHeaders = this.getHeaders();
  getHeaders(): HttpHeaders {
    return new HttpHeaders().set('Content-Type', 'application/json');
  }
  //#endregion

  intercept(req: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {
    const jwt = JWTHandler.getJwtFromCookie();
    console.log(req);
    req = req.clone({
      headers: this.HTTP_HEADERS
    });
    if (jwt !== null) {
      req = req.clone({
        setHeaders: {
          Authorization: `Bearer ${jwt}`
        }
      });
    }
    console.log(req);
    return next.handle(req);
  }
}