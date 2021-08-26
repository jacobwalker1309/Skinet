import { AccountService } from './../account/account.service';
import { Observable } from 'rxjs';
import { BasketService } from './../basket.service';
import { Component, OnInit } from '@angular/core';
import { IBasket } from '../shared/models/basket';
import { IUser } from '../shared/models/user';

@Component({
  selector: 'app-nav-bar',
  templateUrl: './nav-bar.component.html',
  styleUrls: ['./nav-bar.component.scss']
})
export class NavBarComponent implements OnInit {

  basket$: Observable<IBasket>;
  currentUser$:Observable<IUser>;

  constructor(private basketService:BasketService, private accountService:AccountService) { }

  ngOnInit(): void {
    this.basket$ = this.basketService.basket$;
    this.currentUser$ = this.accountService.currentUser$
  }

  logout(){
    this.accountService.logout();
  }

}
