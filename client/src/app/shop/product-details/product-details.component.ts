import { BasketService } from './../../basket.service';
import { ShopService } from './../shop.service';
import { Component, OnInit } from '@angular/core';
import { IProduct } from 'src/app/shared/models/product';
import { ActivatedRoute } from '@angular/router';
import { BreadcrumbService } from 'xng-breadcrumb';

@Component({
  selector: 'app-product-details',
  templateUrl: './product-details.component.html',
  styleUrls: ['./product-details.component.scss']
})
export class ProductDetailsComponent implements OnInit {
  product:IProduct;
  quantity = 1;
  constructor(private shopService: ShopService, private activateRoute:ActivatedRoute,
    private bcService:BreadcrumbService,private basketService:BasketService) { 
      this.bcService.set('@productDetails',' ');
    }

  ngOnInit(): void {
    this.loadProduct();
  }

  addItemToBasket(){
    this.basketService.addItemToBasket(this.product,this.quantity);
  }

  incrementQuantity(){
    if(this.quantity > 1)
    this.quantity++;
  }

  DecrementQuantity(){
    this.quantity--;
  }

  loadProduct(){
    this.shopService.getProduct(+this.activateRoute.snapshot.paramMap.get('id')).subscribe(product => {
      console.log(+this.activateRoute.snapshot.paramMap.get('id'));
      this.bcService.set('@productDetails',product.name);
      this.product = product;
      console.log(this.product);
    }, error => {
      console.log(error);
    }) 
  }

}
