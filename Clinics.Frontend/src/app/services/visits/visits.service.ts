import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import { Injectable } from '@angular/core';
import * as config from '../../../../config';
import { catchError, map, Observable, of } from 'rxjs';
import { VisitView } from '../../classes/visit/visit-view';
import { VisitMedicine } from '../../classes/visit/visit-medicine/visit-medicine';

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

  create(doctorUserId: number, patientId: number, diagnosis: string, visitMedicines: VisitMedicine[]): 
  Observable<{status: boolean, errorMessage: string | null}> {
    var medicines: {medicineId: number, number: number} [] = [];
    visitMedicines.forEach(visitMedicine => {
      medicines.push({medicineId: visitMedicine.id, number: visitMedicine.number});
    });
    var body = {
      doctorUserId: doctorUserId,
      patientId: patientId,
      diagnosis: diagnosis,
      medicines: medicines
    };
    return this.http.post(this.VISITS_ENDPOINT, body)
    .pipe(
      map(_ => {
        return {status: true, errorMessage: null};
      }),
      catchError((error: HttpErrorResponse) => {
        console.error(error.error.detail);
        return of ({status: false, errorMessage: error.error.detail})
      })
    )
  }
}
