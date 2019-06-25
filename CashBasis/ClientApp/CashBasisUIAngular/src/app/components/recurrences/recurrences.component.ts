import { Component, OnInit } from '@angular/core';
import { Recurrence } from 'src/app/models/recurrence';
import { RecurreceService } from 'src/app/services/recurrece.service';

@Component({
  selector: 'app-recurrences',
  templateUrl: './recurrences.component.html',
  styleUrls: []
})
export class RecurrencesComponent implements OnInit {
  recurrences: Recurrence[];

  constructor(private recurrenceService: RecurreceService) {
   }

  ngOnInit() {
    this.recurrenceService.getRecurences()
      .subscribe(data => this.recurrences = data);
  }
}
