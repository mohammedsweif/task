import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { ItemInvoicesComponent } from './Invoices/item-invoices/item-invoices.component';


const routes: Routes = [
  {path:"Invoices",component:ItemInvoicesComponent},
  {path:"",component:ItemInvoicesComponent}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
