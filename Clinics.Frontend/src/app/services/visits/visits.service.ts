import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import { Injectable } from '@angular/core';
import * as config from '../../../../config';
import { catchError, map, Observable, of } from 'rxjs';
import { VisitView } from '../../classes/visit/visit-view';

@Injectable({
  providedIn: 'root'
})
export class VisitsService {

  constructor(private http: HttpClient) { }
  private readonly VISITS_ENDPOINT: string = `${config.apiUrl}/Visits`

  getAllByPatientId(patientId: number):
    Observable<{status: boolean, errorMessage: string | null, visits: VisitView[] | null}> {
      return this.http.get<{visits: VisitView[]}>(`${this.VISITS_ENDPOINT}/${patientId}`)
      .pipe(
        map((response: {visits: VisitView[]}) => {
          return {status: true, errorMessage: null, visits: response.visits};
        }),
        catchError((error: HttpErrorResponse) => {
          console.error(error.error.detail);
          return of ({status: false, errorMessage: error.error.detail, visits: null});
        })
      )
    }
}
