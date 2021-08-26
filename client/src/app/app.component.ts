import { AccountService } from './account/account.service';
import { BasketService } from './basket.service';
import { IProduct } from './shared/models/product';
import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent implements OnInit{
  
  constructor(private basketService:BasketService, private accountService:AccountService) {
  }

  ngOnInit(): void {
    this.loadBasket();
    this.loadCurrentUser();
  }

  loadCurrentUser(){
    const token = localStorage.getItem('token');
   
      this.accountService.loadCurrentUser(token).subscribe(() => {
        console.log('loaded user');
      }, error => {
        console.log(error);
      })
    
  }

  loadBasket(){
    const basketId = localStorage.getItem('basket_id');
    if(basketId)
    {
      this.basketService.getBasket(basketId).subscribe(()=> {
        console.log('initialized basket');
      },error => {
        console.log(error);
      })
    }
  }
}
