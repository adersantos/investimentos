import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { HttpClient, HttpHeaders, HttpResponse } from '@angular/common/http';
import { catchError, tap, map } from 'rxjs/operators';
import { InvestimentoCDB } from 'src/model/investimentoCDB';

const apiUrl = 'https://localhost:7230/CalculoCDB/calcular_investimento';
var httpOptions = {headers: new HttpHeaders({"Content-Type": "application/json"})};

@Injectable({
  providedIn: 'root'
})
export class ApiService {

  constructor(private http: HttpClient) {}
    getCalcularCDB(vi: number, cdi: number, tb: number, periodo: number): Observable<InvestimentoCDB>{
      const url = apiUrl;
      return this.http.post<InvestimentoCDB>(url, httpOptions).pipe(
        tap(),
        catchError(error => { 
          console.log('Ocorreu um erro!')
          throw new Error(error)})
      );
    }
  }

