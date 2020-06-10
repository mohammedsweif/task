import { Component, OnInit } from '@angular/core';
import { ItemInvoicesService } from 'src/app/_service/item-invoices.service';
import { Invoice } from 'src/app/_Model/invoice';
import { Product } from 'src/app/_Model/product';
import { Allinvoice } from 'src/app/_Model/Allinvoices';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
 

@Component({
  selector: 'app-item-invoices',
  templateUrl: './item-invoices.component.html',
  styleUrls: ['./item-invoices.component.css']
})

export class ItemInvoicesComponent implements OnInit {
  
  
  
  constructor(private fb:FormBuilder,public serv: ItemInvoicesService) { }
  InvoiceForm:FormGroup;
  massageValidator={
    Product:{
     required:"this fild must be enter",
   },
   quantityy:{
     required:"this fild must be enter value more than zero" }
    }


/********************************************************************** */
  ngOnInit(): void {
    this.getallproducts();
    this.config = {
      itemsPerPage: 3,
      currentPage: 1
    }
    this.InvoiceForm=this.fb.group({
      Product:["",[Validators.required ]],
      quantityy:["",[Validators.required ]],
      
      });
  }
 

/********************************************************************** */
   config:any;//for pagination
   products: Product[];
  keyword = 'proName';
  data: Product[] = [];
  product: Product = new Product(0, "", 0, 0);
  invoice: Invoice = new Invoice(0, 0, "", 0, 0, 0);
  ShowHide: boolean = false;
  allinvices: Allinvoice[] = [];
  quantity: number = 0;
/********************************************************************** */
 /***/ 
 pageChanged(event){//pagination
  this.config.currentPage = event;
 }
  selectEvent(item) {
    this.product = item;
    console.log(this.product)
  }
  
  getallproducts() {
    this.serv.getall().subscribe(a => {  this.data = a; this.product = new Product(0, "", 0, 0) })
  }

  addinvoice() {
    this.invoice.Quantity = this.quantity;
    this.invoice.Total = this.quantity * this.product.unitprice;
    this.invoice.ItemId = this.product.id;
    this.invoice.UnitPrice = this.product.unitprice;
    console.log(this.invoice);
    this.serv.addinvoice(this.invoice).subscribe(a =>{this.getallproducts();this.ShowAllData();});
  }
  
  ShowAllData() {
    this.ShowHide = !this.ShowHide;
    if (this.ShowHide) {
      this.serv.getinvoices().subscribe(a => this.allinvices = a);
    }
  }

 //to check for the quantity
  checkme() {
    console.log(this.product.quantity, this.quantity);
    if (this.quantity < this.product.quantity && this.quantity > 0) {
      return true;
    }
    return false;
  }


  onChangeSearch(val: string) {
    this.getallproducts();
 
  }

  onFocused(e) {
  
  }
  /***/
}
