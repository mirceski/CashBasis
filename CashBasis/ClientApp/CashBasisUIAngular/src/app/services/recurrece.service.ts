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

  getRecurencesById(id: number): Observable<Recurrence>{
    return this.http.get<Recurrence>(this.recurrencesEndPoint + 'GetRecurrenceById/' + id);
  }

  createRecurrence(recurrence: Recurrence) {
    this.http.post<Recurrence>(this.recurrencesEndPoint + 'CreateRecurrence', recurrence);
  }

  updateRecurrence(id: number, recurrence: Recurrence) {
    this.http.put<Recurrence>(this.recurrencesEndPoint + 'UpdateRecurrence/' + id, recurrence);
  }

  deleteRecurrence(id: number) {
    this.http.delete<Recurrence>(this.recurrencesEndPoint + 'DeleteRecurrence/' + id);
  }
}
