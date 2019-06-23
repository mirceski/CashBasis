import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Recurrence } from '../models/recurrence';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class RecurreceService {
  recurrencesEndPoint: "http://localhost:51148/api/Recurrences/";

  constructor(private http: HttpClient) { }

  httpOptions = {
    headers: new HttpHeaders({
    'Content-Type': 'application/json'
    })
    }

  getRecurences(): Observable<Recurrence[]>{
    return this.http.get<Recurrence[]>(this.recurrencesEndPoint + 'GetRecurrences');
  }
}
