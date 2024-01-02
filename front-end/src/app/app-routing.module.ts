import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { CalcularcdbComponent } from './calcularcdb/calcularcdb.component';

const routes: Routes = [{
  path:'calcularcdb/',
  component: CalcularcdbComponent,
  data: {title: 'CalcularCDB'}
}];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
