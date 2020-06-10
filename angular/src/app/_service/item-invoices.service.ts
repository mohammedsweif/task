import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Invoice } from '../_Model/invoice';
import { Product } from '../_Model/product';
import { Allinvoice } from '../_Model/Allinvoices';

@Injectable({
  providedIn: 'root'
})

export class ItemInvoicesService {
  header= { 
    headers:new HttpHeaders({
      "Content-Type":"application/json"})
  };
 
  constructor(private http: HttpClient) { }
  getall(){
    return this.http.get<Product[]>("http://localhost:50383/product/getall",this.header)
  }
  addinvoice(invoice){
    return this.http.post<Invoice>("http://localhost:50383/invoice/postone",invoice,this.header)
  }
  getinvoices(){//get all data about invoices with name of product
    return this.http.get<Allinvoice[]>("http://localhost:50383/invoice/getallinvoices",this.header)
  }
  
}
