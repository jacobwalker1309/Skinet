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
  constructor(private shopService: ShopService, private activateRoute:ActivatedRoute,
    private bcService:BreadcrumbService) { 
      this.bcService.set('@productDetails',' ');
    }

  ngOnInit(): void {
    this.loadProduct();
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
