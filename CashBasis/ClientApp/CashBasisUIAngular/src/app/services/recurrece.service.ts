import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Recurrence } from '../models/recurrence';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class RecurreceService {
  
  readonly recurrencesEndPoint: string = "http://localhost:51148/api/Recurrences/";

  httpOptions = {
    headers: new HttpHeaders({
    'Content-Type': 'application/json'
    })
    }

    constructor(private http: HttpClient) { }

  getRecurences(): Observable<Recurrence[]>{
    return this.http.get<Recurrence[]>(this.recurrencesEndPoint + 'GetRecurrences');
  }
}
