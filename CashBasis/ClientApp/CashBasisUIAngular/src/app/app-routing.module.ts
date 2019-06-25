import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { RecurrencesComponent} from  'src/app/components/recurrences/recurrences.component'
import { ExpenceCategoriesComponent } from './components/expence-categories/expence-categories.component';


const routes: Routes = [
  { path: '', redirectTo: 'home', pathMatch: 'full' },
  { path: 'recurrences', component: RecurrencesComponent },
  { path: 'expencecategories', component: ExpenceCategoriesComponent }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
