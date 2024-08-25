import { Injectable } from '@angular/core';
import * as config from '../../../../config'
import { catchError, map, Observable, of } from 'rxjs';
import { WaitingListRecord } from '../../classes/waitingList/waiting-list-record';
import { HttpClient, HttpErrorResponse } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class WaitingListService {

  constructor (private http: HttpClient) {}

  private readonly WAITINGLIST_ENDPOINT: string = `${config.apiUrl}/WaitingList`;

  public getAll(): Observable<WaitingListRecord[] | null> {
    return this.http.get<{waitingListRecords: WaitingListRecord[]}>(this.WAITINGLIST_ENDPOINT)
    .pipe(
      map((response: {waitingListRecords: WaitingListRecord[]}) => {
        return response.waitingListRecords;
      }),
      catchError((error: HttpErrorResponse) => {
        console.error(error.error.detail);
        return of (null);
      })
    );
  }

  public delete(id: number): Observable<{status: boolean, errorMessage: string | null}> {
    return this.http.delete(`${this.WAITINGLIST_ENDPOINT}/${id}`)
    .pipe(
      map((_ => {
        return {status: true, errorMessage: null}
      })),
      catchError((error: HttpErrorResponse) => {
        console.error(error.error.detail)
        return of ( {status: false, errorMessage: error.error.detail} )
      })
    );
  }

  public createBySerialNumber(serialNumber: string) : Observable<{status: boolean, errorMessage: string | null}> {
    return this.http.post(this.WAITINGLIST_ENDPOINT, {serialNumber: serialNumber.toString()})
    .pipe(
      map(_ => {
        return {status: true, errorMessage: null}
      }),
      catchError((error: HttpErrorResponse) => {
        return of ( {status: false, errorMessage: error.error.detail} )
      })
    );
  }

}
