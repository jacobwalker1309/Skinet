import { IProduct } from './models/product';
import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { IPagination } from './models/pagination';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent implements OnInit{
  products:IProduct[];


  constructor(private http:HttpClient) {
    
    this.http.get('https://localhost:5001/api/products?pageSize=50').subscribe((response:IPagination)=> {
      this.products = response.data;
    }, error => {
      console.log(error);
    });

  }

  ngOnInit(): void {
    throw new Error('Method not implemented.');
  }

  title = 'client';
}
