import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import { Injectable } from '@angular/core';
import * as config from '../../../../config';
import { catchError, map, Observable, of } from 'rxjs';
import { MedicineSearchResult } from '../../classes/usecases/doctor-usecases/search-for-medicine/medicine-search-result';
@Injectable({
  providedIn: 'root'
})
export class MedicinesService {

  constructor(private http: HttpClient) { }
  private readonly MEDICINES_ENDPOINT: string = `${config.apiUrl}/Medicines`;
  

  getAll(prefix: string) :
  Observable<{status: boolean, errorMessage: string | null, medicines: MedicineSearchResult[] | null}> {
    return this.http.get<{medicines: MedicineSearchResult[]}>(`${this.MEDICINES_ENDPOINT}?prefix=${prefix}`)
    .pipe(
      map((result: {medicines: MedicineSearchResult[]}) => {
        return {status: true, errorMessage: null, medicines: result.medicines};
      }),
      catchError ((error: HttpErrorResponse) => {
        console.error(error.error.detail);
        return of({status: false, errorMessage: error.error.detail, medicines: null});
      })
    );
  }
}
