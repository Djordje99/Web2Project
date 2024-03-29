import { Component, EventEmitter, OnInit, Output } from '@angular/core';
import { UntypedFormBuilder, Validators } from '@angular/forms';
import { ToastrService } from 'ngx-toastr';
import { ProductDto } from 'src/app/models/product.model';
import { ConsumerService } from '../consumer.service';

@Component({
  selector: 'app-pick-products',
  templateUrl: './pick-products.component.html',
  styleUrls: ['./pick-products.component.css']
})
export class PickProductsComponent implements OnInit {

  products:ProductDto[] = [];

  constructor(private consumerService: ConsumerService,
              private formBuilder: UntypedFormBuilder,
              private toastr: ToastrService) { }

  form = this.formBuilder.group({
    amount: ['', {
      validators: [Validators.required, Validators.max(999), Validators.min(1)]
    }]}
  )

  ngOnInit(): void {
    this.consumerService.getProductsAll().subscribe( data => {
      this.products = data;
    });
  }

  addToCart(index:number){
    console.log(index);
    let selectedProduct = this.products[index];
    selectedProduct.amount = this.form.controls['amount'].value;
    this.consumerService.addProduct(selectedProduct);

    this.form.reset()

    this.toastr.info('Product ' + selectedProduct.name + ' is added to cart.')
  }
}
