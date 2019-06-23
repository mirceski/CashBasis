import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { RecurrencesComponent} from  'src/app/components/recurrences/recurrences.component'

const routes: Routes = [
  { path: '', redirectTo: 'home', pathMatch: 'full' },
  { path: 'recurrences', component: RecurrencesComponent }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
